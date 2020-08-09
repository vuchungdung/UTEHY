using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.ViewModel
{
    public class PermissionViewModel
    {
        public Guid RoleId { get; set; }
        public Guid CommandId { get; set; }
        public Guid FunctionId { get; set; }
    }
}
