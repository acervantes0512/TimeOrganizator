using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Alias { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int EstadoId { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<TipoProyecto> TiposProyecto { get; set; }
    }
}
