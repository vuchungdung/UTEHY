using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.ViewModel
{
    public class FunctionViewModel
    {
        public Guid FunctionId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? SortOrder { get; set; }
        public Guid ParentId { get; set; }
        public string Icons { get; set; }
    }
}
