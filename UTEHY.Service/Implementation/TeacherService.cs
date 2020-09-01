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
    public class TeacherService : ITeacherService
    {
        private readonly IRepositoryBase<Teacher, string> _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(IRepositoryBase<Teacher,string> teacherRepository, IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
        }
        public bool Add(TeacherViewModel teacherVm)
        {
            try
            {
                var model = new Teacher()
                {
                    TecherId = teacherVm.TecherId,
                    Name = teacherVm.Name,
                    Phone = teacherVm.Phone,
                    Fax = teacherVm.Fax,
                    Email = teacherVm.Email,
                    Position = teacherVm.Position,
                    WorkPlace = teacherVm.WorkPlace,
                    WebSite = teacherVm.WebSite,
                    Content = teacherVm.Content,
                    Img = teacherVm.Img
                };
                _teacherRepository.Add(model);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var model = _teacherRepository.FindById(id);
                _teacherRepository.Remove(model);
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public PageResult<TeacherViewModel> GetAllPaging(PageRequest request)
        {
            var query = _teacherRepository.FindAll();
            if (!String.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.Equals(request.keyword));
            }
            var totalRecords = query.Count();
            var listItems = query.OrderBy(x => x.Name)
                .Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new TeacherViewModel()
                {
                    TecherId = x.TecherId,
                    Name = x.Name,
                    Phone = x.Phone,
                    Fax = x.Fax,
                    Email = x.Email,
                    Position = x.Position,
                    WorkPlace = x.WorkPlace,
                    WebSite = x.WebSite,
                    Content = x.Content,
                    Img = x.Img
                }).ToList();
            var pagination = new PageResult<TeacherViewModel>()
            {
                ListItem = listItems,
                TotalRecords = totalRecords
            };
            return pagination;
        }

        public TeacherViewModel GetTeacherById(string id)
        {
            try
            {
                var model = _teacherRepository.FindById(id);
                var result = new TeacherViewModel()
                {
                    TecherId = model.TecherId,
                    Name = model.Name,
                    Phone = model.Phone,
                    Fax = model.Fax,
                    Email = model.Email,
                    Position = model.Position,
                    WorkPlace = model.WorkPlace,
                    WebSite = model.WebSite,
                    Content = model.Content,
                    Img = model.Img
                };
                return result;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public TeacherViewModel GetTeacherByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool Update(TeacherViewModel userVm)
        {
            throw new NotImplementedException();
        }
    }
}
