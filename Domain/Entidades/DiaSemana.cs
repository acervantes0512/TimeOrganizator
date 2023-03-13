using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class DiaSemana
    {
        public int Id{ get; set; }
        public string Nombre { get; set; }
        public float HorasConfiguradas { get; set; }        
        public ICollection<AsignacionTipoProyectoPorDia> AsignacionTipoProyectoPorDias { get; set; }
    }
}
