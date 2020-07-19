﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;

namespace UTEHY.Model.ViewModel
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string GroupId { get; set; }
        public string Img { get; set; }
        public GroupUser GroupUser { get; set; }
    }
}
