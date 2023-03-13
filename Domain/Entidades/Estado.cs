using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        public int Nombre { get; set; }
        public int TipoEstadoId { get; set; }
        public TipoEstado TipoEstado { get; set; }
    }
}
