using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;

namespace UTEHY.Model.ViewModel
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string PostId { get; set; }
        public int? ReplyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Post Post { get; set; }
    }
}
