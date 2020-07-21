using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Model.Dtos;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Service.Interfaces;

namespace UTEHY.Service.Implementation
{
    public class PostCategoryService : IPostCategoryService
    {
        private IRepositoryBase<PostCategory, string> _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IRepositoryBase<PostCategory, string> postCategoryRepository, IUnitOfWork unitOfWork)
        {
            _postCategoryRepository = postCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(PostCategoryViewModel postCategoryVm)
        {
            try
            {
                var model = new PostCategory()
                {
                    CategoryId = postCategoryVm.ID,
                    Name = postCategoryVm.Name,
                    ParentId = postCategoryVm.ParentId,
                    Alias = postCategoryVm.Alias,
                };
                _postCategoryRepository.Add(model);
                return true;
            }catch(Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
        }

        public bool Delete(string id)
        {
            var model = _postCategoryRepository.FindById(id);
            if(model != null)
            {
                _postCategoryRepository.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PostCategoryViewModel> GetAll()
        {
            var result = _postCategoryRepository.FindAll().Select(x => new PostCategoryViewModel()
            {
                ID = x.CategoryId,
                Name = x.Name,
                ParentId = x.ParentId,
                Alias = x.Alias,
            }).ToList();
            return result;
        }

        public List<PostCategoryViewModel> GettAllPaging(string keyword, PageRequest request)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool Update(PostCategoryViewModel postCategoryVm)
        {
            try
            {
                var model = new PostCategory()
                {
                    CategoryId = postCategoryVm.ID,
                    Name = postCategoryVm.Name,
                    ParentId = postCategoryVm.ParentId,
                    Alias = postCategoryVm.Alias,
                };
                _postCategoryRepository.Update(model);
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
        }
    }
}
