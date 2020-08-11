using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class Comment
    {
        [Key]
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string CommentId { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string PostId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(128)]
        public string ReplyId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string UserName { get; set; }
    }
}
