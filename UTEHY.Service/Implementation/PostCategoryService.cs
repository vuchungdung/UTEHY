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
                    Alias = postCategoryVm.Alias,
                    CreateDate = DateTime.Now
                };
                _postCategoryRepository.Add(model);
                return true;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public string Delete(string id)
        {
            try
            {
                var model = _postCategoryRepository.FindById(id);
                var result = model.Name;
                _postCategoryRepository.Remove(model);
                return result;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public int DeleteMulti(string[] listId)
        {
            try
            {
                for (int i = 0; i < listId.Length; i++)
                {
                    var model = _postCategoryRepository.FindById(listId[i]);
                    _postCategoryRepository.Remove(model);
                }
                return listId.Length;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public List<PostCategoryViewModel> GetAll()
        {
            var result = _postCategoryRepository.FindAll().Select(x => new PostCategoryViewModel()
            {
                ID = x.CategoryId,
                Name = x.Name,
                Alias = x.Alias,
            }).ToList();
            return result.ToList();
        }

        public PostCategoryViewModel GetSingleById(string id)
        {
            try
            {
                var model = _postCategoryRepository.FindById(id);
                var result = new PostCategoryViewModel()
                {
                    ID = model.CategoryId,
                    Name = model.Name,
                    Alias = model.Alias,
                };
                return result;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public PageResult<PostCategoryViewModel> GettAllPaging(PageRequest request)
        {
            var query = _postCategoryRepository.FindAll();
            if(!String.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.Name.Contains(request.keyword));
            }
            var totalRecords = query.Count();
            var listItems = query.OrderBy(x => x.CreateDate)
                .Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(y => new PostCategoryViewModel()
                {
                    ID = y.CategoryId,
                    Name = y.Name,
                    Alias = y.Alias,
                })              
                .ToList();
            var pagination = new PageResult<PostCategoryViewModel>()
            {
                ListItem = listItems,
                TotalRecords = totalRecords
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
                model.Alias = postCategoryVm.Alias;
                model.UpdateDate = DateTime.Now;
                _postCategoryRepository.Update(model);
                return model.Name;
            }
            catch(Exception error)
            {
                throw error;
            }
        }
    }
}
