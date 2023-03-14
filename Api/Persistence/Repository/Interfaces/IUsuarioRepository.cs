using Domain.Entidades;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByUsernameAsync(string username);
    }
}