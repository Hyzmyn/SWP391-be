using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;

namespace ServiceLayer.Interfaces
{
    public interface ICertificationService
    {
        Task<bool> CertificationExistsAsync(int id);
        //Task<CertificationResponseDetail> CreateCertificateAsync(CertificationRequest request);
        Task DeleteCertificateAsync(int id);
        IEnumerable<CertificationResponseDetail> GetAllCertificates();
        //Task<CertificationResponseDetail> GetCertificateByIdAsync(int id);
        //Task<CertificationResponseDetail> UpdateCertificateAsync(int id, CertificationRequest request);
    }
}