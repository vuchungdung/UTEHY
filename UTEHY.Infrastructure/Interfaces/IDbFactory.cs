using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;

namespace UTEHY.Infrastructure.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        FITEntities Init();
    }
}
