﻿using UTEHY.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Model.Dtos;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Model.Constants;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UTEHY.Service.Implementation
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        private FITDbContext _dbContext;
        private IUnitOfWork _unitOfWork;
        public UserService(UserManager<User> userManager,
            FITDbContext dbContext,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        public bool Add(UserViewModel userVm)
        {
            try
            {
                var model = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = userVm.FullName,
                    Email = userVm.Email,
                    PhoneNumber = userVm.Phone,
                    Address = userVm.Address,
                    UserName = userVm.UserName,
                    BirthDay = userVm.Birthday,
                    Img = userVm.Img
                };
                _userManager.Create(model);
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var model = _userManager.FindById(id);
                _userManager.Delete(model);
                return true;
            }
            catch(Exception error)
            {
                throw error;
            }

        }

        public PageResult<UserViewModel> GetAllPaging(PageRequest request)
        {
            var query = from u in _userManager.Users
                        join k in _dbContext.Faculties
                        on u.FacultyId equals k.FacultyId
                        select new UserViewModel()
                        {
                            Id = u.Id,
                            FullName = u.FullName,
                            Email = u.Email,
                            Phone = u.PhoneNumber,
                            Address = u.Address,
                            UserName = u.UserName,
                            Birthday = u.BirthDay,
                            Img = u.Img,
                            FacultyName = k.Name
                        };

            if (!String.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.Equals(request.keyword));
            }

            var totalRecords = query.Count();

            var listItems = query.OrderBy(x => x.FullName)
                .Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToList();

            var pagination = new PageResult<UserViewModel>()
            {
                ListItem = listItems,
                TotalRecords = totalRecords
            };

            return pagination;
        }

        public List<FunctionViewModel> GetMenuByUserPermission(string userId)
        {
            try
            {
                var roles = _dbContext.Roles;
                var user = _userManager.FindById(userId);
                var role = _userManager.GetRoles(user.Id);
                var query = from f in _dbContext.Functions
                            join p in _dbContext.Permissions
                                on f.FunctionId equals p.FunctionId
                            join g in roles on p.RoleId equals g.Id
                            join c in _dbContext.Commands
                                on p.CommandId equals c.CommandId
                            where role.Contains(g.Name) && c.CommandId == CommandCode.VIEW
                            select new FunctionViewModel()
                            {
                                FunctionId = f.FunctionId,
                                Name = f.Name,
                                Url = f.Url,
                                ParentId = f.ParentId,
                                SortOrder = f.SortOrder,
                                Icons = f.Icons
                            };
                var data = query.Distinct()
                    .OrderBy(x => x.ParentId)
                    .ThenBy(x => x.SortOrder)
                    .ToList();
                return data;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public UserViewModel GetUserById(string id)
        {
            try
            {
                var user = _userManager.FindById(id);
                var model = new UserViewModel()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Address = user.Address,
                    UserName = user.UserName,
                    Birthday = user.BirthDay,
                    Img = user.Img
                };
                return model;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public UserViewModel GetUserByUserName(string username)
        {
            try
            {
                var user = _userManager.FindByName(username);
                var model = new UserViewModel()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Address = user.Address,
                    UserName = user.UserName,
                    Birthday = user.BirthDay,
                    Img = user.Img
                };
                return model;
            }catch(Exception error)
            {
                throw error;
            }
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool Update(UserViewModel userVm)
        {
            try
            {
                var model = _userManager.FindById(userVm.Id);
                model.FullName = userVm.FullName;
                model.Email = userVm.Email;
                model.PhoneNumber = userVm.Phone;
                model.Address = userVm.Address;
                model.UserName = userVm.UserName;
                model.BirthDay = userVm.Birthday;
                model.Img = userVm.Img;
                _userManager.Update(model);
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
