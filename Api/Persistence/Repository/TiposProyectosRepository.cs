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
    public class TiposProyectosRepository : GenericRepository<TipoProyecto>, ITiposProyectosRepository
    {
        private readonly TimeOrganizatorDBContext _context;

        public TiposProyectosRepository(TimeOrganizatorDBContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<List<TipoProyecto>> GetByUserIdAsync(int idUser)
        {
            return await _context.Set<TipoProyecto>()
                .Where(p => p.UsuarioId == idUser)
                .Select(p => new TipoProyecto { Id = p.Id, Nombre = p.Nombre })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
