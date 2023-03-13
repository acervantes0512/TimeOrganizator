using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class AsignacionProyectoPorDia
    {
        public int Id { get; set; }
        public float PorcentajePorDia { get; set; }
        public int AsignacionTipoProyectoPorDiaId { get; set; }
        public int EstadoId { get; set; }
        public AsignacionTipoProyectoPorDia AsignacionTipoProyectoPorDia { get; set; }        
        public Estado Estado { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }

    }
}
