using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class Function
    {
        public Function()
        {
            this.Permissions = new HashSet<Permission>();
            this.Commands = new HashSet<Command>();
        }
        [Key]
        public Guid FunctionId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? SortOrder { get; set; }
        public Guid ParentId { get; set; }
        public string Icons { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Command> Commands { get; set; }
    }
}
