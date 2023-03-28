using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public interface ITiposActividadRepository
    {
        Task<List<TipoActividad>> GetByTipoProyectoAsync(int idTipoProyecto);
    }
}