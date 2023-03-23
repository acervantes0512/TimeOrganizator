using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.UnitOfWork;
using Shared.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;

        public UsuarioService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            this._unitOfWork = unitOfWork;
            this._tokenService = tokenService;
        }

        public async Task<UsuarioDto> CreateUserAsync(Usuario user)
        {
            user.Clave = (HashPassword(user.Clave));
            Usuario createdUser = await _unitOfWork.GetGenericRepository<Usuario>().AddAsync(user);
            _unitOfWork.SaveChanges();
            return mapUserControllerDto(createdUser);
        }

        public async Task<UsuarioDto> GetByUsernameAsync(string username)
        {
            Usuario user = await _unitOfWork.UsuarioRepository.GetByUsernameAsync(username);
            return mapUserControllerDto(user);
        }

        private UsuarioDto mapUserControllerDto(Usuario usuario)
        {
            return new UsuarioDto { Id = usuario.Id, Alias = usuario.Alias, FechaCreacion = usuario.FechaCreacion, FechaNacimiento = usuario.FechaNacimiento, NombreUsuario = usuario.NombreUsuario, PrimerApellido = usuario.PrimerApellido, PrimerNombre = usuario.PrimerNombre, SegundoApellido = usuario.SegundoApellido, SegundoNombre = usuario.SegundoNombre };
        }


        public async Task<UsuarioDto> AuthenticateAsync(string username, string password)
        {
            Usuario user = await _unitOfWork.UsuarioRepository.GetByUsernameAsync(username);
            string providedPasword = HashPassword(password);

            if (user == null)
            {
                throw new AuthenticationException("Invalid credentials");
            }

            if (!providedPasword.Equals(user.Clave))
            {
                throw new AuthenticationException("Invalid credentials");
            }

            var token = await this._tokenService.GenerateJwtToken(user);

            return new UsuarioDto
            {
                Id = user.Id,
                NombreUsuario = user.NombreUsuario,
                Alias = user.Alias,
                FechaCreacion = user.FechaCreacion,
                FechaNacimiento = user.FechaNacimiento,
                PrimerApellido = user.PrimerApellido,
                PrimerNombre = user.PrimerNombre,
                SegundoApellido = user.SegundoApellido,
                SegundoNombre = user.SegundoNombre,
                Token = token
            };
        }

        

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

    }
}
