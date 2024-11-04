using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ModelLayer.Entities;
using ModelLayer.Entities.Momo;
using Newtonsoft.Json;
using RepositoryLayer.UnitOfWork;
using RestSharp;
using ServiceLayer.Helpers;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class MomoService : IMomoService
    {
        private IConfiguration _config;
        private readonly IOptions<MomoOptionModel> _options;
        private readonly IUnitOfWork _unitOfWork;

        public MomoService(IOptions<MomoOptionModel> options, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _options = options;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        // Thêm _paymentTracker để theo dõi giao dịch
        private static Dictionary<string, (int UserId, decimal Amount)> _paymentTracker
            = new Dictionary<string, (int UserId, decimal Amount)>();
        public async Task<MomoPay> CreatePaymentAsync(MomoOrderRequest model)
        {

            model.OrderId = DateTime.UtcNow.Ticks.ToString();
            model.OrderInfo = "Khách hàng: " + model.FullName + ". Nội dung: " + model.OrderInfo;

            var rawData =
                $"partnerCode={_options.Value.PartnerCode}&accessKey={_options.Value.AccessKey}&requestId={model.OrderId}&amount={model.Amount}&orderId={model.OrderId}&orderInfo={model.OrderInfo}&returnUrl={_options.Value.ReturnUrl}&notifyUrl={_options.Value.NotifyUrl}&extraData=";

            var signature = ComputeHmacSha256(rawData, _options.Value.SecretKey);

            var client = new RestClient(_options.Value.MomoApiUrl);
            var request = new RestRequest() { Method = Method.Post };
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            var requestData = new
            {
                userId = model.userID,
                accessKey = _options.Value.AccessKey,
                partnerCode = _options.Value.PartnerCode,
                requestType = _options.Value.RequestType,
                notifyUrl = _options.Value.NotifyUrl,
                returnUrl = _options.Value.ReturnUrl,
                orderId = model.OrderId,
                amount = model.Amount.ToString(),
                orderInfo = model.OrderInfo,
                requestId = model.OrderId,
                extraData = "",
                signature = signature
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(requestData), ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<MomoPay>(response.Content);

            //if (response.IsSuccessful)
            //{
            //    var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);

            //    var momoPay = new MomoPay()
            //    {
            //        RequestId = model.OrderId,
            //        RequestType = _options.Value.RequestType,
            //        UserId = model.userID,
            //        OrderId = model.OrderId,
            //        Message = responseData?.message,
            //        LocalMessage = responseData?.localMessage,
            //        Amount = (decimal)model.Amount,
            //        PayUrl = responseData?.payUrl,
            //        Signature = signature,
            //        QrCodeUrl = responseData?.qrCodeUrl,
            //        Deeplink = responseData?.deeplink,
            //        DeeplinkWebInApp = responseData?.deeplinkWebInApp,
            //        CreatedDate = DateTime.UtcNow.AddHours(7)
            //    };
            //    await _unitOfWork.Repository<MomoPay>().InsertAsync(momoPay);
            //    await _unitOfWork.CommitAsync();
            //    return momoPay;
            //}
            //else
            //{
            //    throw new Exception("Không thể tạo thanh toán Momo: " + response.ErrorMessage);
            //}
        }

        public MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection)
        {
            var momo = new MomoLibrary(); 

            // Lấy tất cả các giá trị từ IQueryCollection và thêm vào momo
            foreach (var (key, value) in collection)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    momo.AddResponseData(key, value.ToString());
                }
            }
            var orderId = momo.GetResponseData("orderId");
            var amount = momo.GetResponseData("amount");
            var orderInfo = momo.GetResponseData("orderInfo");
            var requestId = momo.GetResponseData("requestId");
            var requestType = momo.GetResponseData("requestType");
            var message = momo.GetResponseData("message");
            var localMessage = momo.GetResponseData("localMessage");
            var payUrl = momo.GetResponseData("payUrl");
            var signature = momo.GetResponseData("signature");
            var qrCodeUrl = momo.GetResponseData("qrCodeUrl");
            var deeplink = momo.GetResponseData("deeplink");
            var deeplinkWebInApp = momo.GetResponseData("deeplinkWebInApp");

            // Lấy userId từ hệ thống theo dõi giao dịch (ví dụ: từ _paymentTracker)
            var userId = 0;
            if (collection.TryGetValue("orderId", out var orderIdValue))
            {
                var orderTicket = orderIdValue.ToString();
                (userId, _) = _paymentTracker.GetValueOrDefault(orderTicket);
                _paymentTracker.Remove(orderTicket);
            }

            // Kiểm tra chữ ký xác thực nếu có
            bool checkSignature = momo.ValidateSignature(signature, _config["Momo:HashSecret"]);
            if (!checkSignature)
            {
                return new MomoExecuteResponseModel
                {
                    Success = false,
                    Message = "Invalid signature"
                };
            }

            // Trả về đầy đủ thông tin giao dịch từ Momo
            return new MomoExecuteResponseModel
            {
                Success = true,
                OrderId = orderId,
                Amount = amount,
                OrderInfo = orderInfo,
                UserId = userId,
                RequestId = requestId,
                RequestType = requestType,
                Message = message,
                LocalMessage = localMessage,
                PayUrl = payUrl,
                Signature = signature,
                QrCodeUrl = qrCodeUrl,
                Deeplink = deeplink,
                DeeplinkWebInApp = deeplinkWebInApp
            };
        }


        // Hàm kiểm tra tính hợp lệ của chữ ký từ Momo
        private bool ValidateMomoSignature(IQueryCollection collection, string receivedSignature)
        {
            // Sắp xếp các tham số và tạo chuỗi để kiểm tra chữ ký
            var parameters = collection
                .Where(p => p.Key != "signature")
                .OrderBy(p => p.Key)
                .Select(p => $"{p.Key}={p.Value}")
                .ToArray();

            var rawData = string.Join("&", parameters);

            // Tạo chữ ký (signature) từ dữ liệu và bí mật (hash secret)
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_config["Momo:HashSecret"])))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var computedSignature = BitConverter.ToString(computedHash).Replace("-", "").ToLower();
                return computedSignature == receivedSignature;
            }
        }

        public async Task<MomoPay> SaveTransactionAsync(MomoExecuteResponseModel responseModel)
        {
            // Parse amount to decimal
            if (!decimal.TryParse(responseModel.Amount, out var amount))
            {
                throw new Exception("Invalid amount format in response.");
            }

            var momoPay = new MomoPay
            {
                OrderId = responseModel.OrderId,
                OrderInfo = responseModel.OrderInfo,
                Amount = amount,
                UserId = responseModel.UserId,
                CreatedDate = DateTime.UtcNow.AddHours(7),
                Message = responseModel.Message,
                LocalMessage = responseModel.LocalMessage,
                PayUrl = responseModel.PayUrl,
                Signature = responseModel.Signature,
                QrCodeUrl = responseModel.QrCodeUrl,
                Deeplink = responseModel.Deeplink,
                DeeplinkWebInApp = responseModel.DeeplinkWebInApp,
            };

            await _unitOfWork.Repository<MomoPay>().InsertAsync(momoPay);
            await _unitOfWork.CommitAsync();

            if (responseModel.Success)
            {
                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.Id == responseModel.UserId);
                if (user != null)
                {
                    user.wallet += amount;
                    await _unitOfWork.CommitAsync();
                }
                else
                {
                    throw new Exception("User not found.");
                }
            }
            return momoPay;
        }
        private string ComputeHmacSha256(string message, string secretKey)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message), "Message cannot be null or empty.");

            if (string.IsNullOrEmpty(secretKey))
                throw new ArgumentNullException(nameof(secretKey), "Secret key cannot be null or empty.");

            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var momoPay = await _unitOfWork.Repository<MomoPay>().FindAsync(x => x.Id == id);

            if (momoPay == null)
            {
                return false;
            }

            _unitOfWork.Repository<MomoPay>().Delete(momoPay);
            await _unitOfWork.CommitAsync();

            return true; 
        }
    }
}
