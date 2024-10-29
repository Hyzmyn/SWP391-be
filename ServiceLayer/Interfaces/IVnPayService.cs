using Microsoft.AspNetCore.Http;
using ModelLayer.Entities;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
	public interface IVnPayService
	{
		string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model);
		VNPaymentResponseModel PaymentExecute(IQueryCollection collections);
		Task SaveTransactionAsync(VNPaymentResponseModel response);
		
			Task<IEnumerable<VnPayTransaction>> GetTransactionsAsync(int? userId = null);
		
	}
}
