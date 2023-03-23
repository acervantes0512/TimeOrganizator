using Application.DTOs;
using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITiposProyectosService
    {
        Task<List<TipoProyectoDTO>> TiposProyectosPorIdUsuario(int idUsuario);
    }
}