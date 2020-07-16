using Dapper;
using UTEHY.Service.Interfaces;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        private readonly IRepositoryBase<Permission, string> _permissionRepository;

        public PermissionService(IConfiguration configuration,IRepositoryBase<Permission,string> permissionRepository)
        {
            _configuration = configuration;
            _permissionRepository = permissionRepository;
        }
        public List<PermissionScreenViewModel> GetCommandViews()
        {
            var sql = @"select f.FunctionId,f.Name,
		                        sum((case when c.CommandId = 'CREATE' then 1 else 0 end)) as HasCreate,
		                        sum((case when c.CommandId = 'VIEW' then 1 else 0 end)) as HasView,
		                        sum((case when c.CommandId = 'UPDATE' then 1 else 0 end)) as HasUpdate,
		                        sum((case when c.CommandId = 'DELETE' then 1 else 0 end)) as HasDelete,
		                        sum((case when c.CommandId = 'APPROVE' then 1 else 0 end)) as HasApprove
	                    from Functions as f inner join CommandInFunctions as cif on f.FunctionId = cif.FunctionId 
			                    inner join Commands as c on cif.CommandId = c.CommandId
			                    inner join Permissions as p on p.FunctionId = f.FunctionId and p.CommandId = cif.CommandId
	                    group by f.FunctionId,f.Name,f.ParentId order by f.ParentId";
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("metadata=res://*/Entities.FITEntities.csdl|res://*/Entities.FITEntities.ssdl|res://*/Entities.FITEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-6HF17VS\\SQLEXPRESS;initial catalog=FIT;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;")))
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
                GroupId = Guid.Parse(x.GroupId)
            });
            return result.ToList();
        }
    }
}
