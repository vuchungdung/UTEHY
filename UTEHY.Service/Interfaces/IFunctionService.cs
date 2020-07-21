using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;
using UTEHY.Model.ViewModel;

namespace UTEHY.Service.Interfaces
{
    public interface IFunctionService
    {
        bool Add(FunctionViewModel functionVm);
        bool Update(FunctionViewModel functionVm);

        bool Delete(string funcId);

        List<FunctionViewModel> GellAll();

        FunctionViewModel GetFunctionById(string funcId);

        FunctionViewModel GetFunctionByParentId(string parentId);

        CommandViewModel GetCommandInFunction(string funcId);

        void AddCommandToFunction(string funcId, CommandAssignRequest request);

        string DeleteCommandToFunction(string funcId, CommandAssignRequest request);
        PageResult<FunctionViewModel> GetAllPaging(string keyword, PageRequest request);
        void Save();
    }
}
