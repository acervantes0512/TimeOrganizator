using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class TiempoReal
    {
        public int Id { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int PlanActividadId { get; set; }
        public PlanActividad PlanActividad { get; set; }
    }
}
