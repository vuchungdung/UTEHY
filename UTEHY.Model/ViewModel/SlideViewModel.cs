using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Enums;

namespace UTEHY.Model.ViewModel
{
    public class SlideViewModel
    {
        public int SlideId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
        public ImgType ImgType { get; set; }
    }
}
