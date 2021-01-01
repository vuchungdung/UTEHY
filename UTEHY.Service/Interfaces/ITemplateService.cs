using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface ITemplateService
    {
        bool Add(TemplateViewModel templateVm);
        bool Update(TemplateViewModel templateVm);
        bool Delete(string templateId);
        TemplateViewModel GetSingle(string id);
        List<TemplateViewModel> GetAll();
        PageResult<TemplateViewModel> GetAllPaging(PageRequest request);
        void Save();
    }
}
