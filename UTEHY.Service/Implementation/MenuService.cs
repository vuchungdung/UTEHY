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
    public class MenuService : IMenuService
    {
        private IRepositoryBase<Menu, string> _menuRepository;
        private IUnitOfWork _unitOfWork;
        public MenuService(IRepositoryBase<Menu, string> menuRepository, IUnitOfWork unitOfWork)
        {
            _menuRepository = menuRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Add(MenuViewModel menuVm)
        {
            try
            {
                var model = new Menu()
                {
                    MenuId = Guid.NewGuid().ToString(),
                    Name = menuVm.Name,
                    URL = "/Post/Index?=categoryId=",
                    DisplayOrder = menuVm.DisplayOrder,
                    Status =true,
                    ParentId = menuVm.ParentId,
                };
                _menuRepository.Add(model);
                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public string Delete(string id)
        {
            try
            {
                var model = _menuRepository.FindById(id);
                var result = model.Name;
                _menuRepository.Remove(model);
                return result;
            }
            catch (Exception error)
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
                    var model = _menuRepository.FindById(listId[i]);
                    _menuRepository.Remove(model);
                }
                return listId.Length;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<MenuViewModel> GetMenu()
        {
            try
            {
                var result = _menuRepository.FindAll().Select(x => new MenuViewModel()
                {
                    ID = x.MenuId,
                    PostId = x.PostId,
                    URL = x.URL,
                    Name = x.Name,
                    DisplayOrder = x.DisplayOrder,
                    ParentId = x.ParentId
                    
                }).OrderBy(x=>x.DisplayOrder).ToList();

                List<MenuViewModel> listResult = new List<MenuViewModel>();

                foreach(var item in result)
                {
                    if (String.IsNullOrEmpty(item.ParentId))
                    {
                        foreach(var menu in result)
                        {
                            if(menu.ParentId == item.ID)
                            {
                                item.SubMenu.Add(menu);                               
                            }
                            
                        }
                        listResult.Add(item);
                    }
                    else
                    {
                        foreach(var sub in result)
                        {
                            if(sub.ParentId == item.ID)
                            {
                                item.SubMenu.Add(sub);
                            }
                        }
                    }
                }

                return listResult.OrderBy(x => x.DisplayOrder).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<MenuViewModel> GetAll()
        {
            var result = _menuRepository.FindAll().Select(x => new MenuViewModel()
            {
                ID = x.MenuId,
                Name = x.Name,
            }).ToList();
            return result.ToList();
        }

        public MenuViewModel GetSingleById(string id)
        {
            try
            {
                var model = _menuRepository.FindById(id);
                var result = new MenuViewModel()
                {
                    ID = model.MenuId,
                    PostId = model.PostId,
                    URL = model.URL,
                    Name = model.Name,
                    DisplayOrder = model.DisplayOrder,
                    ParentId = model.ParentId
                };
                return result;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public PageResult<MenuViewModel> GetAllPaging(PageRequest request)
        {
            var query = _menuRepository.FindAll();
            if (!String.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.Name.Contains(request.keyword));
            }
            var totalRecords = query.Count();
            var listItems = query.OrderBy(x => x.CreateDate)
                .Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(y => new MenuViewModel()
                {
                    ID = y.MenuId,
                    Name = y.Name                   
                })
                .ToList();
            var pagination = new PageResult<MenuViewModel>()
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

        public string Update(MenuViewModel postCategoryVm)
        {
            try
            {
                var model = _menuRepository.FindById(postCategoryVm.ID);
                model.ParentId = postCategoryVm.ParentId;
                model.Name = postCategoryVm.Name;
                model.DisplayOrder = postCategoryVm.DisplayOrder;
                _menuRepository.Update(model);
                return model.Name;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
