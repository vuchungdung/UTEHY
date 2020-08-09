using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            this.Permissions = new HashSet<Permission>();
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }

        [StringLength(250)]
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }      
    }
}
