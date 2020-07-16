using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface ICommandService
    {
        List<CommandViewModel> GetAll();
    }
}
