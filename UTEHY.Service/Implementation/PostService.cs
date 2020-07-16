using UTEHY.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Model.Dtos;
using UTEHY.Infrastructure.Interfaces;

namespace UTEHY.Service.Implementation
{
    public class PostService : IPostService
    {
        private IRepositoryBase<Post, Guid> _postRepository;
        private IUnitOfWork _unitOfWork;
        public PostService(IRepositoryBase<Post,Guid> postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }
        public List<PostViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PageResult<PostViewModel> GetAllPaging(int? categoryid, string keyword, PageRequest request)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
