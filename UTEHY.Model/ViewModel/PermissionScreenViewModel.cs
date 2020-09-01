using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.ViewModel
{
    public class PermissionScreenViewModel
    {
        public string FunctionId { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public bool HasCreate { get; set; }
        public bool HasUpdate { get; set; }
        public bool HasDelete { get; set; }
        public bool HasView { get; set; }
        public bool HasApprove { get; set; }
        public bool HasExport { get; set; }
        public bool HasImport { get; set; }
    }
}
