using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Authentication
{
    public class JWTService : ITokenService
    {
        private readonly JwtSecurityTokenHandler _jwtHandler;
        private readonly JwtSettings _jwtSettings;
        private readonly IUnitOfWork _unitOfWork;

        public JWTService(IOptions<JwtSettings> jwtSettings, IUnitOfWork unitOfWork)
        {
            _jwtHandler = new JwtSecurityTokenHandler();
            this._jwtSettings = jwtSettings.Value;
            this._unitOfWork = unitOfWork;
        }

        public async Task<string> GenerateJwtToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            Rol role = await _unitOfWork.GetGenericRepository<Rol>().GetByIdAsync(user.RolId);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.NombreUsuario.ToString()),
                    new Claim(ClaimTypes.Role, role.Nombre),
                    new Claim("idUsuario", Convert.ToString(user.Id)),
                }),
                Expires = DateTime.UtcNow.AddSeconds(_jwtSettings.ExpirationSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
