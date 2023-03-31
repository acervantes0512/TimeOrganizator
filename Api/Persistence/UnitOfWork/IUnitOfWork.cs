using Persistence.Repository;
using Persistence.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }
        ITiposProyectosRepository TiposProyectosRepository { get; }
        ITiposActividadRepository TiposActividadRepository { get; }
        ITiposTiempoRepository TiposTiempoRepository { get; }
        IGenericRepository<T> GetGenericRepository<T>() where T : class;
        void SaveChanges();
    }

}
