using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public interface ITiposTiempoRepository
    {
        Task<List<TipoTiempo>> GetByProjectIdAsync(int idTipoProyecto);
    }
}