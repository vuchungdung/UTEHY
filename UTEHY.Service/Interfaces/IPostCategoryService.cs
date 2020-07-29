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
        string Update(PostCategoryViewModel postCategoryVm);
        string Delete(string id);
        List<PostCategoryViewModel> GetAll();
        PageResult<PostCategoryViewModel> GettAllPaging(string keyword, PageRequest request);

        PostCategoryViewModel GetSingleById(string id);

        void Save();
    }
}
