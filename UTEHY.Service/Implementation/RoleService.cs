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
        private FITDbContext _context;
        private IUnitOfWork _unitOfWork;
        public RoleService(IUnitOfWork unitOfWork, FITDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public bool Add(RoleViewModel roleVm)
        {
            try
            {
                var model = new Role()
                {
                    Id = roleVm.Id,
                    Name = roleVm.Name
                };
                _context.Roles.Add(model);
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
                var model = _context.Roles.Find(roleId);
                _context.Roles.Remove(model);
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
                var result = _context.Roles.Select(x => new RoleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
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
            try
            {
                var query = _context.Roles.ToList();
                if (!String.IsNullOrEmpty(request.keyword))
                {
                    query = query.Where(x => x.Name.Contains(request.keyword)).ToList();
                }
                if (!String.IsNullOrEmpty(request.categoryId))
                {
                    
                }
                int totalRecords = query.Count();

                var listItems = query.OrderByDescending(x => x.Name)
                    .Skip((request.pageIndex - 1) * request.pageSize)
                    .Take(request.pageSize)
                    .Select(x => new RoleViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name                        
                    }).ToList();
                var pagination = new PageResult<RoleViewModel>()
                {
                    ListItem = listItems,
                    TotalRecords = totalRecords
                };
                return pagination;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<PermissionViewModel> GetPermissionByRoleId(string roleId)
        {
            var listModels = from p in _context.Permissions
                             join r in _context.Roles
                             on p.RoleId equals r.Id
                             where r.Id == roleId
                             select new PermissionViewModel()
                             {
                                 CommandId = p.CommandId,
                                 FunctionId = p.FunctionId,
                                 RoleId = p.RoleId
                             };
            return listModels.ToList();
        }

        public RoleViewModel GetSingle(string id)
        {
            var model = _context.Roles.Find(id);
            var result = new RoleViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
            return result;
        }

        public bool PutPermissionByRoleId(string roleId, List<PermissionViewModel> models)
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
                var model = _context.Roles.Find(roleVm.Id);
                model.Id = roleVm.Id;
                model.Name = roleVm.Name;
                _context.Roles.Attach(model);
                return true;
            }
            catch(Exception error)
            {
                throw error;
            }
        }
    }
}
