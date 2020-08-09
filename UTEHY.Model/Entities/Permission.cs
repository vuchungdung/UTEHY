using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class Permission
    {
        [Key]
        [Column(Order =1)]
        public Guid FunctionId { get; set; }
        [Key]
        [Column(Order = 2)]
        public Guid RoleId { get; set; }
        [Key]
        [Column(Order = 3)]
        public Guid CommandId { get; set; }

        public virtual Command Command { get; set; }
        public virtual Function Function { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
