using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ModelLayer.Entities.Momo;
using Newtonsoft.Json;
using RepositoryLayer.UnitOfWork;
using RestSharp;
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
        private readonly IOptions<MomoOptionModel> _options;
        private readonly IUnitOfWork _unitOfWork;

        public MomoService(IOptions<MomoOptionModel> options, IUnitOfWork unitOfWork)
        {
            _options = options;
            _unitOfWork = unitOfWork;
        }

        public async Task<MomoPay> CreatePaymentAsync(MomoOrderRequest model)
        {
            var vietnamTime = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7)).DateTime;
            //model.CreateDate = vietnamTime;

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
            //return JsonConvert.DeserializeObject<MomoPay>(response.Content);

            if (response.IsSuccessful)
            {
                var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);

                var momoPay = new MomoPay()
                {
                    RequestId = model.OrderId,
                    RequestType = _options.Value.RequestType,
                    UserId = model.userID,
                    OrderId = model.OrderId,
                    Message = responseData?.message,
                    LocalMessage = responseData?.localMessage,
                    Amount = (decimal)model.Amount,
                    PayUrl = responseData?.payUrl,
                    Signature = signature,
                    QrCodeUrl = responseData?.qrCodeUrl,
                    Deeplink = responseData?.deeplink,  
                    DeeplinkWebInApp = responseData?.deeplinkWebInApp,
                    CreatedDate = vietnamTime
                };
                await _unitOfWork.Repository<MomoPay>().InsertAsync(momoPay);
                await _unitOfWork.CommitAsync();
                return momoPay;
                //return JsonConvert.DeserializeObject<MomoPay>(response.Content);
            }
            else
            {
                throw new Exception("Không thể tạo thanh toán Momo: " + response.ErrorMessage);
            }
        }

        public MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection)
        {
            //var amount = collection.First(s => s.Key == "amount").Value;
            //var orderInfo = collection.First(s => s.Key == "orderInfo").Value;
            //var orderId = collection.First(s => s.Key == "orderId").Value;
            collection.TryGetValue("amount", out var amount);
            collection.TryGetValue("orderInfo", out var orderInfo);
            collection.TryGetValue("orderId", out var orderId);
            return new MomoExecuteResponseModel()
            {
                Amount = amount,
                OrderId = orderId,
                OrderInfo = orderInfo
            };
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

            return true; // Trả về true nếu xóa thành công
        }

    }
}
