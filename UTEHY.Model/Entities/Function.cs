using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class Function
    {
        [Key]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string FunctionId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string Url { get; set; }
        public int? SortOrder { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string ParentId { get; set; }
        public string Icons { get; set; }
    }
}
