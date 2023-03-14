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
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly TimeOrganizatorDBContext _context;

        public UsuarioRepository(TimeOrganizatorDBContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<Usuario> GetByUsernameAsync(string username)
        {
            return await _context.Set<Usuario>()
                .Where(p => p.NombreUsuario == username)
                .FirstOrDefaultAsync();
        }
    }
}
