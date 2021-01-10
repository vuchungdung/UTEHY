using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string Img { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string FacultyName { get; set; }
    }
}
