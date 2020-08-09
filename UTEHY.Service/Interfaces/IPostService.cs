using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.Enums;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IPostService
    {
        List<PostViewModel> GetAll();

        bool Add(PostViewModel postVm);

        string Update(PostViewModel postVm);

        string Delete(string id);

        PostViewModel GetPostById(string id);

        int DeleteMulti(Guid[] id);

        PageResult<PostViewModel> GetAllPaging(string categoryid, string keyword, PageRequest request);

        bool ChangeStatus(string id, PostStatus status);

        bool ChangeFlag(string id, bool status);
        void Save();
    }
}
