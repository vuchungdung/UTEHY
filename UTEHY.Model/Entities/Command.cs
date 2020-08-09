using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class Command
    {

        public Command()
        {
            this.Permissions = new HashSet<Permission>();
            this.Functions = new HashSet<Function>();
        }
        [Key]
        public Guid CommandId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<Function> Functions { get; set; }
    }
}
