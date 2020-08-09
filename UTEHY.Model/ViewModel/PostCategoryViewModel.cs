using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.ViewModel
{
    public class PostCategoryViewModel
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Alias { get; set; }
        public Guid ParentId { get; set; }
        [Required]
        public int? DisplayOrder { get; set; }
    }
}
