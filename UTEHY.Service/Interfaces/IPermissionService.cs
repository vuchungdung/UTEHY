using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IPermissionService
    {
        List<PermissionScreenViewModel> GetCommandViews(string roleId);
        List<PermissionViewModel> GetAllPermission();      
    }
}
