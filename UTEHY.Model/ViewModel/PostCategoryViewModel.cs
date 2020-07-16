using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.ViewModel
{
    public class PostCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int? ParentId { get; set; }
    }
}
