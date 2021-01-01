using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;

namespace UTEHY.Model.Entities
{
    [Table("Templates")]
    public class Template : BaseModel
    {
        [Key]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string TemplateId { get; set; }

        public string Path { get; set; }

        public string Image { get; set; }

    }
}
