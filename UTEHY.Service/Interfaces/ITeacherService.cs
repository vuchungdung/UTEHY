using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface ITeacherService
    {
        TeacherViewModel GetTeacherById(string id);
        TeacherViewModel GetTeacherByUserName(string username);
        PageResult<TeacherViewModel> GetAllPaging(PageRequest request);
        bool Add(TeacherViewModel userVm);
        bool Update(TeacherViewModel userVm);
        bool Delete(string id);
        void Save();
    }
}
