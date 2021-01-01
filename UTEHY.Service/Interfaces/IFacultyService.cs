using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IFacultyService
    {
        bool Add(FacultyViewModel facultyVm);
        bool Update(FacultyViewModel facultyVm);
        bool Delete(string facultyId);
        FacultyViewModel GetSingle(string id);
        List<FacultyViewModel> GetAll();
        PageResult<FacultyViewModel> GetAllPaging(PageRequest request);
        void Save();
    }
}
