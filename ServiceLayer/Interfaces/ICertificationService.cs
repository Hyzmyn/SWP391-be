using ModelLayer.Entities;

namespace ServiceLayer.Interfaces
{
    public interface ICertificationService
    {
        Task CreateCertificate(Certification certification);
        Task DeleteCertificateAsync(int id);
        IEnumerable<Certification> GetAllCertificate();
        Task<Certification> GetCertificateByIdAsync(int certId);
        Task UpdateCertificate(Certification certification);
    }
}