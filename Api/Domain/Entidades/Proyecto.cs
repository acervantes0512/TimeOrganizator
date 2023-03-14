using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalEstimada { get; set; }
        public int DuracionMinutos { get; set; }
        public int AsignacionProyectoPorDiaId { get; set; }
        public int EstadoId { get; set; }
        public int TipoProyectoId { get; set; }
        public TipoProyecto TipoProyecto { get; set; }
        public AsignacionProyectoPorDia AsignacionProyectoPorDia { get; set; }        
        public Estado Estado { get; set; }
        public ICollection<PlanActividad> PlanActividades { get; set; }

    }
}
