using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Model.Dtos;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.Service.Implementation
{
    public class RoleService : IRoleService
    {
        private IRepositoryBase<Role, string> _roleRepository;
        private IUnitOfWork _unitOfWork;
        public RoleService(IRepositoryBase<Role, string> roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }
        public bool Add(RoleViewModel roleVm)
        {
            try
            {
                var model = new Role()
                {
                    Id = roleVm.Id,
                    Name = roleVm.Name,
                    Description = roleVm.Description,

                };
                _roleRepository.Add(model);
                return true;
            }catch(Exception error)
            {
                throw error;
            }
        }

        public bool Delete(string roleId)
        {

            try
            {
                var model = _roleRepository.FindById(roleId);
                _roleRepository.Remove(model);
                return true;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public List<RoleViewModel> GetAll()
        {
            try
            {
                var result = _roleRepository.FindAll().Select(x => new RoleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();
                return result;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public PageResult<RoleViewModel> GetAllPaging(PageRequest request)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool Update(RoleViewModel roleVm)
        {
            try
            {
                var model = _roleRepository.FindById(roleVm.Id);
                model.Id = roleVm.Id;
                model.Name = roleVm.Name;
                model.Description = roleVm.Description;
                _roleRepository.Update(model);
                return true;
            }
            catch(Exception error)
            {
                throw error;
            }
        }
    }
}
