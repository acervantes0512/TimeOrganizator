using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class TipoEstado
    {
        public int Id { get; set; }
        public int Nombre { get; set; }
        public ICollection<Estado> Estados { get; set; }
    }
}
