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

namespace UTEHY.Service.Implementation
{
    public class UserService : IUserService
    {
        private IRepositoryBase<User, string> _userRepository;
        private IRepositoryBase<Function, string> _functionRepository;
        private IRepositoryBase<Command, string> _commandRepository;
        private IRepositoryBase<Permission, string> _permissionRepository;
        private IRepositoryBase<GroupUser, string> _groupUsersRepository;
        private IUnitOfWork _unitOfWork;
        public UserService(IRepositoryBase<User,string> userRepository,
            IUnitOfWork unitOfWork,
            IRepositoryBase<Function,string> functionRepository,
            IRepositoryBase<Command, string> commandRepository,
            IRepositoryBase<Permission, string> permissionRepository,
            IRepositoryBase<GroupUser, string> groupUsersRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _functionRepository = functionRepository;
            _commandRepository = commandRepository;
            _permissionRepository = permissionRepository;
            _groupUsersRepository = groupUsersRepository;
        }
        public void Add(UserViewModel userVm)
        {
            var model = new User()
            {
                UserId = Guid.NewGuid().ToString(),
                Name = userVm.Name,
                Email =userVm.Email,
                PhoneNumber = userVm.PhoneNumber,
                Address =userVm.Address,
                UserName = userVm.UserName,
                Password = userVm.Password,
                FirstName =userVm.FirstName,
                LastName =userVm.LastName,
                Dob =userVm.Dob,
                GroupId = userVm.GroupId.ToString()
            };
            _userRepository.Add(model);
        }

        public string Delete(string id)
        {
            var model = _userRepository.FindById(id);
            _userRepository.Remove(id);
            return model.UserId;
        }

        public List<UserViewModel> GetAll()
        {
            var result = _userRepository.FindAll().Select(x => new UserViewModel()
            {
                UserId = x.UserId,
                Name = x.Name,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                UserName = x.UserName,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Dob = x.Dob,
                GroupId = x.GroupId
            });
            return result.ToList();
        }

        public PageResult<UserViewModel> GetAllPaging(string keyword, PageRequest request)
        {
            throw new NotImplementedException();
        }

        public List<FunctionViewModel> GetMenuByUserPermission(string userId)
        {
            try
            {
                var functions = _functionRepository.FindAll();
                var permissions = _permissionRepository.FindAll();
                var commands = _commandRepository.FindAll();
                var groupusers = _groupUsersRepository.FindAll();
                var user = _userRepository.FindById(userId);
                var groupuser = _groupUsersRepository.FindById(user.GroupId);
                var query = from f in functions
                            join p in permissions
                                on f.FunctionId equals p.FunctionId
                            join g in groupusers on p.GroupId equals g.GroupId
                            join c in commands
                                on p.CommandId equals c.CommandId
                            where groupuser.GroupId == g.GroupId && c.CommandId == "VIEW"
                            select new FunctionViewModel()
                            {
                                FunctionId = f.FunctionId,
                                Name = f.Name,
                                Url = f.Url,
                                ParentId = f.ParentId,
                                SortOrder = f.SortOrder
                            };
                var data = query.Distinct()
                    .OrderBy(x => x.ParentId)
                    .ThenBy(x => x.SortOrder)
                    .ToList();
                return data;
            }catch(Exception error)
            {
                return null;
            }
        }

        public UserViewModel GetUserById(string id)
        {
            var user = _userRepository.FindById(id);
            var model = new UserViewModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.Dob,
                GroupId = user.GroupId
            };
            return model;
        }

        public UserViewModel GetUserByUserName(string username)
        {
            var user = _userRepository.FindSingle(x=>x.UserName == username);
            var model = new UserViewModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.Dob,
                GroupId = user.GroupId
            };
            return model;
        }

        public bool Login(LoginViewModel model)
        {
            var user = _userRepository.FindSingle(x => x.UserName == model.UserName && x.Password == model.Password);
            if(user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(UserViewModel userVm)
        {
            var model = new User()
            {
                UserId = userVm.UserId.ToString(),
                Name = userVm.Name,
                Email = userVm.Email,
                PhoneNumber = userVm.PhoneNumber,
                Address = userVm.Address,
                UserName = userVm.UserName,
                Password = userVm.Password,
                FirstName = userVm.FirstName,
                LastName = userVm.LastName,
                Dob = userVm.Dob,
                GroupId = userVm.GroupId.ToString()
            };
            _userRepository.Update(model);
        }
    }
}
