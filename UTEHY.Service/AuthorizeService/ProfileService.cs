using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;

namespace UTEHY.Service.AuthorizeService
{
    public class ProfileService : IDisposable
    {
        private FITDbContext _db = new FITDbContext();

        public void Dispose()
        {
            _db.Dispose();
        }

        public List<string> GetProfileService(IList<string> roles)
        {
            var query = from f in _db.Functions
                        join p in _db.Permissions
                        on f.FunctionId equals p.FunctionId
                        join c in _db.Commands
                        on p.CommandId equals c.CommandId
                        join r in _db.Roles on p.RoleId equals r.Id
                        where roles.Contains(r.Name)
                        select f.FunctionId + "_" + c.CommandId;
            var permissions = query.Distinct().ToList();
            return permissions;
        }
    }
}
