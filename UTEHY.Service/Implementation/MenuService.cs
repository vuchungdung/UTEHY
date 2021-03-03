using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Infrastructure.Interfaces;
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
        public List<MenuViewModel> GetAll()
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
                    
                }).ToList();

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
                }

                return listResult;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
