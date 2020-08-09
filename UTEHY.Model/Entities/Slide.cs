using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Enums;

namespace UTEHY.Model.Entities
{
    public class Slide
    {
        [Key]
        public Guid SlideId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Url { get; set; }
        public int DisplayOrder { get; set; }
        public bool Status { get; set; }
        public ImgType ImgType { get; set; }
    }
}
