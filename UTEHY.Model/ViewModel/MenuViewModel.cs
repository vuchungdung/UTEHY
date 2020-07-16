using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.ViewModel
{
    public class MenuViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
        public int? ParentId { get; set; }
        public string Content { get; set; }
    }
}
