using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITipoActividadService
    {
        Task<List<TipoActividadDTO>> ObtenerTiposDeActividadesPorTipoProyecto(int idTipoProyecto);
    }
}