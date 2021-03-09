using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IMenuService
    {
        List<MenuViewModel> GetAll();
        List<MenuViewModel> GetMenu();
        bool Add(MenuViewModel postCategoryVm);
        string Update(MenuViewModel postCategoryVm);
        string Delete(string id);
        PageResult<MenuViewModel> GetAllPaging(PageRequest request);
        MenuViewModel GetSingleById(string id);
        int DeleteMulti(string[] listId);
        void Save();
    }
}
