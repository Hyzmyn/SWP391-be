using Microsoft.AspNetCore.Identity.Data;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IAuthServices
    {
        Task<BaseResponseForLogin<LoginResponseModel>> AuthenticateAsync(string username, string password);
        string GenerateJwtToken(string username, string roleName, int userId);
        Task<BaseResponse<TokenModel>> RegisterAsync(RegisterModel user);
        Task<BaseResponse<TokenModel>> AdminGenAcc(AdminCreateAccountModel adminCreateAccountModel);
        Task<BaseResponse> SendAccount(int userId);
        Task<BaseResponse> ForgotPassword(RequestModels.ForgotPasswordRequest request);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);

    }
}
