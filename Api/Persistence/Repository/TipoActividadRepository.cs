using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class TiposActividadRepository : GenericRepository<TipoActividad>, ITiposActividadRepository
    {
        private readonly TimeOrganizatorDBContext _context;

        public TiposActividadRepository(TimeOrganizatorDBContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<List<TipoActividad>> GetByTipoProyectoAsync(int idTipoProyecto)
        {
            return await _context.Set<TipoActividad>()
                .Where(p => p.TipoProyectoId == idTipoProyecto)
                .Select(p => new TipoActividad { Id = p.Id, Nombre = p.Nombre, Descripcion = p.Descripcion, EstadoId = p.EstadoId, TipoProyectoId = p.TipoProyectoId })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
