using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IPostService
    {
        List<PostViewModel> GetAll();

        PageResult<PostViewModel> GetAllPaging(int? categoryid, string keyword, PageRequest request);

        void Save();
    }
}
