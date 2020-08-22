using Dapper;
using UTEHY.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Infrastructure.Interfaces;

namespace UTEHY.Service.Implementation
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepositoryBase<Permission, string> _permissionRepository;

        public PermissionService(IRepositoryBase<Permission,string> permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public List<PermissionScreenViewModel> GetCommandViews(string roleId)
        {
            var sql = @"select f.FunctionId as FunctionId,f.Name as Name,f.ParentId as ParentId,
		                        sum((case when c.CommandId = 'CREATE' then 1 else 0 end)) as HasCreate,
		                        sum((case when c.CommandId = 'VIEW' then 1 else 0 end)) as HasView,
		                        sum((case when c.CommandId = 'UPDATE' then 1 else 0 end)) as HasUpdate,
		                        sum((case when c.CommandId = 'DELETE' then 1 else 0 end)) as HasDelete,
		                        sum((case when c.CommandId = 'APPROVE' then 1 else 0 end)) as HasApprove
	                    from Functions as f inner join CommandInFunctions as cif on f.FunctionId = cif.FunctionId 
			                    inner join Commands as c on cif.CommandId = c.CommandId
			                    inner join Permissions as p on p.FunctionId = f.FunctionId and p.CommandId = cif.CommandId
                                and p.RoleId = '"+roleId+"'"+"group by f.FunctionId,f.Name,f.ParentId order by f.ParentId";
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-6HF17VS\SQLEXPRESS;Initial Catalog=FIT;Integrated Security=True;"))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var result = conn.Query<PermissionScreenViewModel>(sql, null, null, true, 120, CommandType.Text);
                return result.ToList();
            }
        }
        public List<PermissionViewModel> GetAllPermission()
        {
            var result = _permissionRepository.FindAll().Select(x => new PermissionViewModel()
            {
                FunctionId = x.FunctionId,
                CommandId = x.CommandId,
                RoleId = x.RoleId
            });
            return result.ToList();
        }
    }
}
