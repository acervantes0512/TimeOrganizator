using Application.DTOs;
using Domain.Entidades;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> AuthenticateAsync(string username, string password);
        Task<UsuarioDto> CreateUserAsync(Usuario user);
        Task<UsuarioDto> GetByUsernameAsync(string username);
    }
}