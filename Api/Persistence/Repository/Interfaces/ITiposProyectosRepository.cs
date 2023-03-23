using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public interface ITiposProyectosRepository
    {
        Task<List<TipoProyecto>> GetByUserIdAsync(int idUser);
    }
}