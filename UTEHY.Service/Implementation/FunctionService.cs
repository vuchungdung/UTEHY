using UTEHY.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Model.Dtos;
using UTEHY.Infrastructure.Interfaces;

namespace UTEHY.Service.Implementation
{
    public class FunctionService : IFunctionService
    {
        private IRepositoryBase<Function, string> _functionRepository;
        private IUnitOfWork _unitOfWork;

        public FunctionService(IRepositoryBase<Function,string> functionRepository, IUnitOfWork unitOfWork)
        {
            _functionRepository = functionRepository;
            _unitOfWork = unitOfWork;
        }
        public bool Add(FunctionViewModel functionVm)
        {
            try
            {
                var model = new Function()
                {
                    FunctionId = functionVm.FunctionId,
                    Name = functionVm.Name,
                    Url = functionVm.Url,
                    SortOrder = functionVm.SortOrder,
                    ParentId = functionVm.ParentId
                };
                _functionRepository.Add(model);
                return true;
            }catch(Exception error)
            {
                return false;
            }
        }

        public void AddCommandToFunction(string funcId, CommandAssignRequest request)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string funcId)
        {
            var model = _functionRepository.FindById(funcId);
            if (model != null)
            {
                _functionRepository.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string DeleteCommandToFunction(string funcId, CommandAssignRequest request)
        {
            throw new NotImplementedException();
        }

        public List<FunctionViewModel> GellAll()
        {
            var result = _functionRepository.FindAll().Select(x => new FunctionViewModel()
            {
                FunctionId = x.FunctionId,
                Name = x.Name,
                Url = x.Url,
                SortOrder = x.SortOrder,
                ParentId = x.ParentId
            });
            return result.ToList();
        }

        public PageResult<FunctionViewModel> GetAllPaging(string keyword, PageRequest request)
        {
            throw new NotImplementedException();
        }

        public CommandViewModel GetCommandInFunction(string funcId)
        {
            throw new NotImplementedException();
        }

        public FunctionViewModel GetFunctionById(string funcId)
        {
            throw new NotImplementedException();
        }

        public FunctionViewModel GetFunctionByParentId(string parentId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool Update(FunctionViewModel functionVm)
        {
            throw new NotImplementedException();
        }
    }
}
