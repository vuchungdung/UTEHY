using UTEHY.Service.Interfaces;
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

namespace UTEHY.Service.Implementation
{
    public class UserService : IUserService
    {
        //private IRepositoryBase<User, string> _userRepository;
        //private IRepositoryBase<Function, string> _functionRepository;
        //private IRepositoryBase<Command, string> _commandRepository;
        //private IRepositoryBase<Permission, string> _permissionRepository;
        //private IRepositoryBase<GroupUser, string> _groupUsersRepository;
        //private IUnitOfWork _unitOfWork;
        //public UserService(IRepositoryBase<User,string> userRepository,
        //    IUnitOfWork unitOfWork,
        //    IRepositoryBase<Function,string> functionRepository,
        //    IRepositoryBase<Command, string> commandRepository,
        //    IRepositoryBase<Permission, string> permissionRepository,
        //    IRepositoryBase<GroupUser, string> groupUsersRepository)
        //{
        //    _userRepository = userRepository;
        //    _unitOfWork = unitOfWork;
        //    _functionRepository = functionRepository;
        //    _commandRepository = commandRepository;
        //    _permissionRepository = permissionRepository;
        //    _groupUsersRepository = groupUsersRepository;
        //}
        //public bool Add(UserViewModel userVm)
        //{
        //    try
        //    {
        //        var model = new User()
        //        {
        //            UserId = Guid.NewGuid().ToString(),
        //            Name = userVm.Name,
        //            Email = userVm.Email,
        //            PhoneNumber = userVm.PhoneNumber,
        //            Address = userVm.Address,
        //            UserName = userVm.UserName,
        //            Password = userVm.Password,
        //            FirstName = userVm.FirstName,
        //            LastName = userVm.LastName,
        //            Dob = userVm.Dob,
        //            GroupId = userVm.GroupId.ToString()
        //        };
        //        _userRepository.Add(model);
        //        return true;
        //    }catch(Exception error)
        //    {
        //        Console.WriteLine(error);
        //        return false;
        //    }
        //}

        //public bool Delete(string id)
        //{
        //    var model = _userRepository.FindById(id);
        //    if (model != null)
        //    {
        //        _userRepository.Remove(id);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
            
        //}

        //public User FindUser(LoginViewModel model)
        //{
        //    var user = _userRepository.FindSingle(x => x.UserName == model.UserName && x.Password == model.Password);
        //    if(user != null)
        //    {
        //        return user;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public List<UserViewModel> GetAll()
        //{
        //    var result = _userRepository.FindAll().Select(x => new UserViewModel()
        //    {
        //        UserId = x.UserId,
        //        Name = x.Name,
        //        Email = x.Email,
        //        PhoneNumber = x.PhoneNumber,
        //        Address = x.Address,
        //        UserName = x.UserName,
        //        Password = x.Password,
        //        FirstName = x.FirstName,
        //        LastName = x.LastName,
        //        Dob = x.Dob,
        //        GroupId = x.GroupId
        //    });
        //    return result.ToList();
        //}

        //public PageResult<UserViewModel> GetAllPaging(string keyword, PageRequest request, string groupId)
        //{
        //    var query = _userRepository.FindAll();
        //    if (!String.IsNullOrEmpty(keyword))
        //    {
        //        query = query.Where(x => x.Equals(keyword));
        //    }
        //    if (!String.IsNullOrEmpty(groupId))
        //    {
        //        query = query.Where(x => x.GroupId == groupId);
        //    }
        //    var totalRecords = query.Count();
        //    var listItems = query.OrderBy(x=>x.Name)
        //        .Skip((request.pageIndex - 1) * request.pageSize)
        //        .Take(request.pageSize)
        //        .Select(x => new UserViewModel()
        //        {
        //            UserId = x.UserId,
        //            Name = x.Name,
        //            Email = x.Email,
        //            PhoneNumber = x.PhoneNumber,
        //            Address = x.Address,
        //            UserName = x.UserName,
        //            Password = x.Password,
        //            FirstName = x.FirstName,
        //            LastName = x.LastName,
        //            Dob = x.Dob,
        //            GroupId = x.GroupId
        //        }).ToList();
        //    var pagination = new PageResult<UserViewModel>()
        //    {
        //        ListItem = listItems,
        //        TotalRecords = totalRecords
        //    };
        //    return pagination;
        //}

        //public List<FunctionViewModel> GetMenuByUserPermission(string userId)
        //{
        //    try
        //    {
        //        var functions = _functionRepository.FindAll();
        //        var permissions = _permissionRepository.FindAll();
        //        var commands = _commandRepository.FindAll();
        //        var groupusers = _groupUsersRepository.FindAll();
        //        var user = _userRepository.FindById(userId);
        //        var groupuser = _groupUsersRepository.FindById(user.GroupId);
        //        var query = from f in functions
        //                    join p in permissions
        //                        on f.FunctionId equals p.FunctionId
        //                    join g in groupusers on p.GroupId equals g.GroupId
        //                    join c in commands
        //                        on p.CommandId equals c.CommandId
        //                    where groupuser.GroupId == g.GroupId && c.CommandId == CommandCode.VIEW
        //                    select new FunctionViewModel()
        //                    {
        //                        FunctionId = f.FunctionId,
        //                        Name = f.Name,
        //                        Url = f.Url,
        //                        ParentId = f.ParentId,
        //                        SortOrder = f.SortOrder,
        //                        Icons = f.Icons
        //                    };
        //        var data = query.Distinct()
        //            .OrderBy(x => x.ParentId)
        //            .ThenBy(x => x.SortOrder)
        //            .ToList();
        //        return data;
        //    }catch(Exception error)
        //    {
        //        Console.WriteLine(error);
        //        return null;
        //    }
        //}

        //public UserViewModel GetUserById(string id)
        //{
        //    var user = _userRepository.FindById(id);
        //    var model = new UserViewModel()
        //    {
        //        UserId = user.UserId,
        //        Name = user.Name,
        //        Email = user.Email,
        //        PhoneNumber = user.PhoneNumber,
        //        Address = user.Address,
        //        UserName = user.UserName,
        //        Password = user.Password,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Dob = user.Dob,
        //        GroupId = user.GroupId
        //    };
        //    return model;
        //}

        //public UserViewModel GetUserByUserName(string username)
        //{
        //    var user = _userRepository.FindSingle(x=>x.UserName == username);
        //    var model = new UserViewModel()
        //    {
        //        UserId = user.UserId,
        //        Name = user.Name,
        //        Email = user.Email,
        //        PhoneNumber = user.PhoneNumber,
        //        Address = user.Address,
        //        UserName = user.UserName,
        //        Password = user.Password,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Dob = user.Dob,
        //        GroupId = user.GroupId
        //    };
        //    return model;
        //}

        //public void Save()
        //{
        //    _unitOfWork.Commit();
        //}

        //public bool Update(UserViewModel userVm)
        //{
        //    try
        //    {
        //        var model = _userRepository.FindById(userVm.UserId);
        //        model.UserId = userVm.UserId.ToString();
        //        model.Name = userVm.Name;
        //        model.Email = userVm.Email;
        //        model.PhoneNumber = userVm.PhoneNumber;
        //        model.Address = userVm.Address;
        //        model.UserName = userVm.UserName;
        //        model.Password = userVm.Password;
        //        model.FirstName = userVm.FirstName;
        //        model.LastName = userVm.LastName;
        //        model.Dob = userVm.Dob;
        //        model.GroupId = userVm.GroupId;
        //        _userRepository.Update(model);
        //        return true;
        //    }catch(Exception error)
        //    {
        //        Console.WriteLine(error);
        //        return false;
        //    }
        //}
    }
}
