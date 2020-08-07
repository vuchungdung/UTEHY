using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        IRepositoryBase<User, string> _authenRepository;
        public AuthenticationService(IRepositoryBase<User,string> authenRepository)
        {
            _authenRepository = authenRepository;
        }
        public User Login(LoginViewModel model)
        {
            var user = _authenRepository.FindSingle(x => x.UserName == model.UserName && x.Password == model.Password);
            return user;
        }
    }
}
