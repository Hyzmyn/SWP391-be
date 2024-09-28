using RepositoryLayer;
using RepositoryLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CertificationService
    {
        private readonly PawFundContext _context;
        private readonly UnitOfWork _unitOfWork;

        public CertificationService(PawFundContext context, UnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }   

    }
}
