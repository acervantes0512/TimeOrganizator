using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITiposTiempoService
    {
        Task<List<TipoTiempoDTO>> TiposTiempoPorIdProyecto(int idTipoProyecto);
    }
}