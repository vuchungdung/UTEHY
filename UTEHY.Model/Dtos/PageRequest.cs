using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Dtos
{
    public class PageRequest
    {
        public int pageSize { get; set; }
        public int pageIndex { get; set; }    
        public string keyword { get; set; }
        public string categoryId { get; set; }
    }
}
