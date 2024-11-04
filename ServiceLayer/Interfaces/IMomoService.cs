using Microsoft.AspNetCore.Http;
using ModelLayer.Entities.Momo;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

namespace ServiceLayer.Interfaces
{
    public interface IMomoService
    {
        Task<MomoPay> CreatePaymentAsync(MomoOrderRequest model);
        MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);

        Task<bool> DeletePaymentAsync(int id);
    }
}