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
        private IUnitOfWork _unitOfWork;
        public UserService(IRepositoryBase<User,string> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(UserViewModel userVm)
        {
            var model = new User()
            {
                UserId = new Guid().ToString(),
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
                UserId = Guid.Parse(x.UserId),
                Name = x.Name,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                UserName = x.UserName,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Dob = x.Dob,
                GroupId = Guid.Parse(x.GroupId)
            });
            return result.ToList();
        }

        public PageResult<UserViewModel> GetAllPaging(string keyword, PageRequest request)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUserById(string id)
        {
            var user = _userRepository.FindById(id);
            var model = new UserViewModel()
            {
                UserId = Guid.Parse(user.UserId),
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.Dob,
                GroupId = Guid.Parse(user.GroupId)
            };
            return model;
        }

        public UserViewModel GetUserByUserName(string username)
        {
            var user = _userRepository.FindSingle(x=>x.UserName == username);
            var model = new UserViewModel()
            {
                UserId = Guid.Parse(user.UserId),
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.Dob,
                GroupId = Guid.Parse(user.GroupId)
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
