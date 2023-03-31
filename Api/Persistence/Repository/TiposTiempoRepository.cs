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
    public class TiposTiempoRepository : GenericRepository<TipoTiempo>, ITiposTiempoRepository
    {
        private readonly TimeOrganizatorDBContext _context;

        public TiposTiempoRepository(TimeOrganizatorDBContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<List<TipoTiempo>> GetByProjectIdAsync(int idTipoProyecto)
        {
            return await _context.Set<TipoTiempo>()
                .Where(p => p.TipoProyectoId == idTipoProyecto)
                .Select(p => new TipoTiempo { Id = p.Id, Nombre = p.Nombre, Descripcion = p.Descripcion, TipoProyectoId = p.TipoProyectoId })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
