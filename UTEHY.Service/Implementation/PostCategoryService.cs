﻿using System;
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
                    CategoryId = Guid.NewGuid().ToString(),
                    Name = postCategoryVm.Name,
                    ParentId = postCategoryVm.ParentId,
                    Alias = postCategoryVm.Alias,
                    DisplayOrder = postCategoryVm.DisplayOrder
                };
                _postCategoryRepository.Add(model);
                return true;
            }catch(Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
        }

        public string Delete(string id)
        {
            var model = _postCategoryRepository.FindById(id);
            if(model != null)
            {
                var result = model.Name;
                _postCategoryRepository.Remove(model);
                return result;
            }
            else
            {
                return null;
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
            return result.ToList();
        }

        public PostCategoryViewModel GetSingleById(string id)
        {
            var model = _postCategoryRepository.FindById(id);
            var result = new PostCategoryViewModel()
            {
                ID = model.CategoryId,
                Name = model.Name,
                ParentId = model.ParentId,
                Alias = model.Alias,
                DisplayOrder = model.DisplayOrder              
            };
            return result;
        }

        public PageResult<PostCategoryViewModel> GettAllPaging(string keyword, PageRequest request)
        {
            var query = _postCategoryRepository.FindAll();
            if(!String.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            var totalRecords = query.Count();
            var listItems = query.OrderBy(x => x.DisplayOrder)
                .Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(y => new PostCategoryViewModel()
                {
                    ID = y.CategoryId,
                    Name = y.Name,
                    ParentId = y.ParentId,
                    Alias = y.Alias,
                    DisplayOrder = y.DisplayOrder
                })              
                .ToList();
            var pagination = new PageResult<PostCategoryViewModel>()
            {
                ListItem = listItems,
                TotalRecords = totalRecords,
                Page = request.pageIndex,
                TotalPages = (int)Math.Ceiling((decimal)totalRecords/request.pageSize)
            };
            return pagination;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public string Update(PostCategoryViewModel postCategoryVm)
        {
            try
            {
                var model = _postCategoryRepository.FindById(postCategoryVm.ID);
                model.CategoryId = postCategoryVm.ID;
                model.Name = postCategoryVm.Name;
                model.ParentId = postCategoryVm.ParentId;
                model.Alias = postCategoryVm.Alias;
                model.DisplayOrder = postCategoryVm.DisplayOrder;
                _postCategoryRepository.Update(model);
                return model.Name;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return null;
            }
        }
    }
}
