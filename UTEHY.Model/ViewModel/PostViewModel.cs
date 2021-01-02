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
        public string ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public int? ViewCount { get; set; }
        public int? LikeCount { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateBy { get; set; }
        public string Img { get; set; }

        public string MoreImgs { get; set; }

        public PostStatus Status { get; set; }
        public virtual PostCategory PostCategory { get; set; }
    }
}
