using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class PlanActividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int DuracionMinutos { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaEstimadaFin { get; set; }
        public int OrdenEjecucion { get; set; }
        public int TipoActividadId { get; set; }
        public int TipoTiempoId { get; set; }
        public int ProyectoId { get; set; }
        public TipoActividad TipoActividad { get; set; }
        public TipoTiempo TipoTiempo { get; set; }
        public Proyecto Proyecto { get; set; }
        public ICollection<TiempoReal> TiemposReales { get; set; }
    }
}
