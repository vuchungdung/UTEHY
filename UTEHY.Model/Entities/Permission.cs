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
        [Column(Order =1, TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string FunctionId { get; set; }
        [Key]
        [Column(Order =2, TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string RoleId { get; set; }
        [Key]
        [Column(Order =3, TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string CommandId { get; set; }

    }
}
