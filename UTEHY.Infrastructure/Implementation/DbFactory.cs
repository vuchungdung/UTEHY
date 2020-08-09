using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Model.Entities;

namespace UTEHY.Infrastructure.Implementation
{
    public class DbFactory : Disposable, IDbFactory
    {
        private FITDbContext dbContext;

        public FITDbContext Init()
        {
            return dbContext ?? (dbContext = new FITDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
