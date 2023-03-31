using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;
using Persistence.Repository;
using Persistence.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimeOrganizatorDBContext _context;
        private bool disposed = false;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITiposProyectosRepository _tiposProyectosRepository;
        private readonly ITiposActividadRepository _tiposActividadRepository;
        private readonly ITiposTiempoRepository _tiposTiempoRepository;

        public UnitOfWork(TimeOrganizatorDBContext context)
        {
            _context = context;
            _usuarioRepository = new UsuarioRepository(_context);
            _tiposProyectosRepository = new TiposProyectosRepository(_context);
            _tiposActividadRepository = new TiposActividadRepository(_context);
            _tiposTiempoRepository = new TiposTiempoRepository(_context);
        }

        public IUsuarioRepository UsuarioRepository => _usuarioRepository;
        public ITiposProyectosRepository TiposProyectosRepository => _tiposProyectosRepository;
        public ITiposActividadRepository TiposActividadRepository => _tiposActividadRepository;
        public ITiposTiempoRepository TiposTiempoRepository => _tiposTiempoRepository;

        public IGenericRepository<T> GetGenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
