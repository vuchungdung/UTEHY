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
        private FITDbContext _context;
        private IUnitOfWork _unitOfWork;

        public FunctionService(IRepositoryBase<Function,string> functionRepository, IUnitOfWork unitOfWork, FITDbContext context)
        {
            _functionRepository = functionRepository;
            _unitOfWork = unitOfWork;
            _context = context;
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
                throw error;
            }
        }

        public void AddCommandToFunction(string funcId, CommandAssignRequest request)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string funcId)
        {
            try
            {
                var model = _functionRepository.FindById(funcId);
                _functionRepository.Remove(model);
                return true;
            }
            catch(Exception error)
            {
                throw error;
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

        public List<CommandViewModel> GetCommandInFunction(string funcId)
        {
            var query = from c in _context.Commands
                        join cif in _context.CommandInFunctions
                        on c.CommandId equals cif.CommandId
                        join f in _functionRepository.FindAll()
                        on cif.FunctionId equals f.FunctionId
                        where f.FunctionId == funcId
                        select new CommandViewModel()
                        {
                            CommandId = c.CommandId,
                            Name = c.Name
                        };
            return query.ToList();
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
