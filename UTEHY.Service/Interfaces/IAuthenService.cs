using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Dtos;

namespace UTEHY.Service.Interfaces
{
    public interface IAuthenService
    {
        string SecretKey { get; set; }
        bool IsTokenValid(string token);
        string GenerateToken(JWTContainer model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
