using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.ViewModel
{
    public class FunctionViewModel
    {
        public string FunctionId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? SortOrder { get; set; }
        public string ParentId { get; set; }
    }
}
