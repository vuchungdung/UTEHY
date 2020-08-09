using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class Menu
    {
        [Key]
        public Guid MenuId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int DisplayOrder { get; set; }
        public bool Status { get; set; }
        public Guid ParentId { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
    }
}
