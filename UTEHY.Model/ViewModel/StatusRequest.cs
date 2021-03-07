using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Enums;

namespace UTEHY.Model.ViewModel
{
    public class StatusRequest
    {
        public string Id { get; set; }
        public PostStatus Status { get; set; }
    }
}
