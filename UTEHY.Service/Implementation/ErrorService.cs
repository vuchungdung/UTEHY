using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Model.Entities;
using UTEHY.Service.Interfaces;

namespace UTEHY.Service.Implementation
{
    public class ErrorService : IErrorService
    {
        private IRepositoryBase<Error, int> _errorRepository;
        private IUnitOfWork _unitOfWork;
        public ErrorService(IRepositoryBase<Error,int> errorRepository,IUnitOfWork unitOfWork)
        {
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(Error error)
        {
            _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
