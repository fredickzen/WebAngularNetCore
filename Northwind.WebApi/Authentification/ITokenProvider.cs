using Microsoft.IdentityModel.Tokens;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Authentification
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
