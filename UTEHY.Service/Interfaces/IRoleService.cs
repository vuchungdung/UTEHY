using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Model.Dtos;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IRoleService
    {
        bool Add(RoleViewModel roleVm);
        bool Update(RoleViewModel roleVm);
        bool Delete(string roleId);
        List<RoleViewModel> GetAll();
        PageResult<RoleViewModel> GetAllPaging(PageRequest request);
        void Save();
    }
}
