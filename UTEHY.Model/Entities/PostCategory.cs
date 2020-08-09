using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class PostCategory
    {
        public PostCategory()
        {
            this.Posts = new HashSet<Post>();
        }
        [Key]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public Guid ParentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? DisplayOrder { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
