using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UTEHY.Model.Dtos
{
    public class JWTContainer
    {
        public string SecretKey { get ; set ; } = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
        public string SecurityAlgorithm { get ; set ; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireMinutes { get; set; } = 1440;
        public Claim[] Claims { get ; set ; }
    }
}
