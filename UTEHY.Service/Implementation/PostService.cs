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
using UTEHY.Model.Enums;

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

        public bool Add(PostViewModel postVm)
        {
            try
            {
                var model = new Post()
                {
                    PostId = Guid.NewGuid(),
                    Name = postVm.Name,
                    Alias = postVm.Alias,
                    CategoryId = postVm.CategoryId,
                    Description = postVm.Description,
                    Content = postVm.Content,
                    HomeFlag = false,
                    CreatedDate = DateTime.Now,
                    CreatedBy = postVm.CreatedBy,
                    Img = postVm.Img,
                    MoreImgs = postVm.MoreImgs,
                    Status = (int)PostStatus.Closed
                };
                _postRepository.Add(model);
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }

        public bool ChangeFlag(string id, bool status)
        {
            var model = _postRepository.FindById(Guid.Parse(id));
            if (model != null)
            {
                model.HomeFlag = status;
                _postRepository.Update(model);
                return true;
            }
            return false;
        }

        public bool ChangeStatus(string id, PostStatus status)
        {
            var model = _postRepository.FindById(Guid.Parse(id));
            if(model!= null)
            {
                model.Status = status;
                _postRepository.Update(model);
                return true;
            }
            return false;
        }

        public string Delete(string id)
        {
            var model = _postRepository.FindById(Guid.Parse(id));
            if(model != null)
            {
                string name = model.Name;
                _postRepository.Remove(model);
                return name;
            }
            else
            {
                return null;
            }
            
        }

        public int DeleteMulti(Guid[] id)
        {
            for(int i = 0; i< id.Length; i++)
            {
                var model = _postRepository.FindById(id[i]);
                _postRepository.Remove(model);
            }
            return id.Length;
        }

        public List<PostViewModel> GetAll()
        {
            var result = _postRepository.FindAll().Select(x => new PostViewModel()
            {
                ID = x.PostId,
                Name = x.Name,
                Alias = x.Alias,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Content = x.Content,
                HomeFlag = x.HomeFlag,
                CreatedDate = x.CreatedDate,
                CreatedBy = x.CreatedBy,
                MoreImgs = x.MoreImgs,
                Img = x.Img,
                Status = (PostStatus)x.Status
            }).ToList();
            return result;
        }

        public PageResult<PostViewModel> GetAllPaging(string keyword, string categoryid, PageRequest request)
        {
            var query = _postRepository.FindAll();
            if (!String.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if(!String.IsNullOrEmpty(categoryid))
            {
                query = query.Where(x => x.CategoryId == categoryid);
            }
            int totalRecords = query.Count();

            var listItems = query.OrderByDescending(x => x.CreatedDate)
                .Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new PostViewModel()
                {
                    ID = x.PostId,
                    Name = x.Name,
                    Alias = x.Alias,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    Content = x.Content,
                    HomeFlag = x.HomeFlag,
                    CreatedDate = x.CreatedDate,
                    CreatedBy = x.CreatedBy,
                    MoreImgs = x.MoreImgs,
                    Img = x.Img,
                    Status = (PostStatus)x.Status
                }).ToList();
            var pagination = new PageResult<PostViewModel>()
            {
                ListItem = listItems,
                TotalRecords = totalRecords
            };
            return pagination;
        }

        public PostViewModel GetPostById(string id)
        {
            var model = _postRepository.FindById(Guid.Parse(id));
            var result = new PostViewModel()
            {
                ID = model.PostId,
                Name = model.Name,
                Alias = model.Alias,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Content = model.Content,
                HomeFlag = model.HomeFlag,
                CreatedDate = model.CreatedDate,
                CreatedBy = model.CreatedBy,
                MoreImgs = model.MoreImgs,
                Img = model.Img,
                Status = (PostStatus)model.Status
            };
            return result;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public string Update(PostViewModel postVm)
        {
            var model = _postRepository.FindById(postVm.ID);
            if(model != null)
            {
                model.Name = postVm.Name;
                model.Alias = postVm.Alias;
                model.CategoryId = postVm.CategoryId;
                model.Description = postVm.Description;
                model.Content = postVm.Content;
                model.UpdatedDate = DateTime.Now;
                model.UpdatedBy = postVm.UpdatedBy;
                model.Img = postVm.Img;
                model.MoreImgs = postVm.MoreImgs;
            }
            _postRepository.Update(model);
            return postVm.Name;
        }
    }
}
