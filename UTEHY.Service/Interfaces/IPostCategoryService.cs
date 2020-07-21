using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IPostCategoryService
    {
        bool Add(PostCategoryViewModel postCategoryVm);
        bool Update(PostCategoryViewModel postCategoryVm);
        bool Delete(string id);
        List<PostCategoryViewModel> GetAll();
        List<PostCategoryViewModel> GettAllPaging(string keyword, PageRequest request);

        void Save();
    }
}
