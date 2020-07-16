using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;
using UTEHY.Model.Enums;

namespace UTEHY.Model.ViewModel
{
    public class PostViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int CategoryId { get; set; }
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
        public virtual PostCategory PostCategory { get; set; }
    }
}
