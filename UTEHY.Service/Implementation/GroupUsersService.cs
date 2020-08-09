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
    public class GroupUsersService : IGroupUsersService
    {
        //private IRepositoryBase<GroupUser, string> _groupUserRepository;
        //private IUnitOfWork _unitOfWork;
        //public GroupUsersService(IRepositoryBase<GroupUser,string> groupUserRepository, IUnitOfWork unitOfWork)
        //{
        //    _groupUserRepository = groupUserRepository;
        //    _unitOfWork = unitOfWork;
        //}
        //public bool Add(GroupUserViewModel groupUserVm)
        //{
        //    try
        //    {
        //        var model = new GroupUser()
        //        {
        //            GroupId = groupUserVm.GroupId,
        //            Name = groupUserVm.Name
        //        };
        //        _groupUserRepository.Add(model);
        //        return true;
        //    }
        //    catch (Exception error)
        //    {
        //        Console.WriteLine(error);
        //        return false;
        //    }
        //}

        //public bool Delete(string groupId)
        //{
        //    var model = _groupUserRepository.FindById(groupId);
        //    if (model != null)
        //    {
        //        _groupUserRepository.Remove(model);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public List<GroupUserViewModel> GetAll()
        //{
        //    var result = _groupUserRepository.FindAll().Select(x => new GroupUserViewModel()
        //    {
        //        GroupId = x.GroupId,
        //        Name = x.Name
        //    }).ToList();
        //    return result;
        //}

        //public void Save()
        //{
        //    _unitOfWork.Commit();
        //}

        //public bool Update(GroupUserViewModel groupUserVm)
        //{
        //    try
        //    {
        //        var model = new GroupUser()
        //        {
        //            GroupId = groupUserVm.GroupId,
        //            Name = groupUserVm.Name
        //        };
        //        _groupUserRepository.Update(model);
        //        return true;
        //    }
        //    catch (Exception error)
        //    {
        //        Console.WriteLine(error);
        //        return false;
        //    }
        //}
    }
}
