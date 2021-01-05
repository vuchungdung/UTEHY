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
    public class FacultyService : IFacultyService
    {
        private readonly IRepositoryBase<Faculty, string> _facultyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FacultyService(IRepositoryBase<Faculty,string> facultyRepository, IUnitOfWork unitOfWork)
        {
            _facultyRepository = facultyRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(FacultyViewModel facultyVm)
        {
            try
            {
                var model = new Faculty()
                {
                    FacultyId = Guid.NewGuid().ToString(),
                    Deleted = false,
                    CreateDate = DateTime.Now,
                    Name = facultyVm.Name
                };

                _facultyRepository.Add(model);

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string facultyId)
        {
            try
            {
                var model = _facultyRepository.FindById(facultyId);

                model.Deleted = true;
                model.UpdateDate = DateTime.Now;

                _facultyRepository.Update(model);

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<FacultyViewModel> GetAll()
        {
            try
            {
                var query = _facultyRepository.FindAll().OrderBy(x => x.CreateDate).Select(x => new FacultyViewModel()
                {
                    FacultyId = x.FacultyId,
                    Name = x.Name
                }).ToList();

                return query;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public PageResult<FacultyViewModel> GetAllPaging(PageRequest request)
        {
            try
            {
                var query = _facultyRepository.FindAll();

                if (!String.IsNullOrEmpty(request.keyword))
                {
                    query = query.Where(x => x.Equals(request.keyword));
                }

                var totalRecords = query.Count();

                var listItems = query.OrderBy(x => x.CreateDate)
                    .Skip((request.pageIndex - 1) * request.pageSize)
                    .Take(request.pageSize)
                    .Select(x => new FacultyViewModel()
                    {
                        FacultyId = x.FacultyId,
                        Name = x.Name
                    }).ToList();

                var pagination = new PageResult<FacultyViewModel>()
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

        public FacultyViewModel GetSingle(string id)
        {
            try
            {
                var model = _facultyRepository.FindById(id);

                var result = new FacultyViewModel()
                {
                    FacultyId = model.FacultyId,
                    Name = model.Name
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

        public bool Update(FacultyViewModel facultyVm)
        {
            try
            {
                var model = _facultyRepository.FindById(facultyVm.FacultyId);

                model.FacultyId = facultyVm.Name;
                model.Name = facultyVm.Name;
                model.UpdateDate = DateTime.Now;

                _facultyRepository.Update(model);

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
