using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class AsignacionTipoProyectoPorDia
    {
        public int Id { get; set; }
        public float PorcentajePorDia { get; set; }
        public int DiasSemanaId { get; set; }
        public int TipoProyectoId { get; set; }
        public int EstadoId { get; set; }        
        public DiaSemana DiasSemana { get; set; }        
        public TipoProyecto TipoProyecto { get; set; }
        public Estado Estado { get; set; }
        public ICollection<AsignacionProyectoPorDia> AsignacionesProyectosPorDia { get; set; }
    }
}
