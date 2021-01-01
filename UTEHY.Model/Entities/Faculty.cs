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
    [Table("Faculties")]
    public class Faculty : BaseModel
    {
        [Key]
        [StringLength(128)]
        public string FacultyId { get; set; }

        public string Name { get; set; }
    }
}
