using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;

namespace UTEHY.Infrastructure.Authenticated
{
    public class OAuthen : IDisposable
    {
        FITEntities context = new FITEntities();
        public User ValidateUser(LoginViewModel model)
        {
            return context.Users.FirstOrDefault(x=>x.UserName == model.UserName && x.Password == model.Password);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
