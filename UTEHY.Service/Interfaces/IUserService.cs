using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll();

        UserViewModel GetUserById(string id);
        UserViewModel GetUserByUserName(string username);

        PageResult<UserViewModel> GetAllPaging(string keyword, PageRequest request);

        void Add(UserViewModel userVm);
        void Update(UserViewModel userVm);

        int Login(LoginViewModel model);

        List<FunctionViewModel> GetMenuByUserPermission(string userId);

        string Delete(string id);
        void Save();

    }
}
