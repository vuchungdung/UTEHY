using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Enums;

namespace UTEHY.Model.Entities
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        public Guid PostId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool HomeFlag { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string Img { get; set; }
        public PostStatus Status { get; set; }
        public string MoreImgs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        [ForeignKey("CategoryId")]
        public virtual PostCategory PostCategory { get; set; }
    }
}
