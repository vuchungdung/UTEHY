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
    public class PostCategory : BaseModel
    {
        [Key]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string CategoryId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        public string Alias { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string FacultyId { get; set; }

    }
}
