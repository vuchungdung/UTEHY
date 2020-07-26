using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Dtos
{
    public class PageResult<T>
    {
        public List<T> ListItem { get; set; }
        public int TotalRecords { get; set; }

        public int Page { get; set; }

        public int TotalPages { get; set; }
    }
}
