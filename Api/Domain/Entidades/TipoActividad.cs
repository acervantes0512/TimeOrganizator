using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class TipoActividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstadoId { get; set; }
        public int TipoProyectoId { get; set; }
        public TipoProyecto TipoProyecto { get; set; }
        public Estado Estado { get; set; }
        public ICollection<PlanActividad> PlanActividades { get; set; }

    }
}
