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
    public class TemplateService : ITemplateService
    {
        private readonly IRepositoryBase<Template, string> _templateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TemplateService(IRepositoryBase<Template, string> templateRepository, IUnitOfWork unitOfWork)
        {
            _templateRepository = templateRepository;
            _unitOfWork = unitOfWork;
        }
        public bool Add(TemplateViewModel templateVm)
        {
            try
            {
                var model = new Template()
                {
                    TemplateId = Guid.NewGuid().ToString(),
                    Image = templateVm.Image,
                    Path = templateVm.Path
                };
                _templateRepository.Add(model);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            };
        }

        public bool Delete(string templateId)
        {
            try
            {
                var model = _templateRepository.FindById(templateId);

                model.Deleted = true;
                model.UpdateDate = DateTime.Now;

                _templateRepository.Update(model);

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<TemplateViewModel> GetAll()
        {
            try
            {
                var query = _templateRepository.FindAll().OrderBy(x=>x.CreateDate).Select(x => new TemplateViewModel()
                {
                    TemplateId = x.TemplateId,
                    Image = x.Image,
                    Path = x.Path
                });
                return query.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public PageResult<TemplateViewModel> GetAllPaging(PageRequest request)
        {
            try
            {
                var query = _templateRepository.FindAll();

                if (!String.IsNullOrEmpty(request.keyword))
                {
                    query = query.Where(x => x.Equals(request.keyword));
                }

                var totalRecords = query.Count();

                var listItems = query.OrderBy(x => x.CreateDate)
                    .Skip((request.pageIndex - 1) * request.pageSize)
                    .Take(request.pageSize)
                    .Select(x => new TemplateViewModel()
                    {
                        TemplateId = x.TemplateId,
                        Path = x.Path,
                        Image = x.Image,
                    }).ToList();

                var pagination = new PageResult<TemplateViewModel>()
                {
                    ListItem = listItems,
                    TotalRecords = totalRecords
                };

                return pagination;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TemplateViewModel GetSingle(string id)
        {
            try
            {
                var model = _templateRepository.FindById(id);

                var result = new TemplateViewModel()
                {
                    TemplateId = model.TemplateId,
                    Image = model.Image,
                    Path = model.Path
                };

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool Update(TemplateViewModel templateVm)
        {
            try
            {
                var model = _templateRepository.FindById(templateVm.TemplateId);

                model.Image = templateVm.Image;
                model.Path = templateVm.Path;
                model.UpdateDate = DateTime.Now;

                _templateRepository.Update(model);

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
