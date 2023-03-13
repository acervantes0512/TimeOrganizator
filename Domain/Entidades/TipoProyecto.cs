﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class TipoProyecto
    {
        public int Id { get; set; }
        public string Nombre  { get; set; }
        public string Descripcion { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioId { get; set; }
        public Estado Estado { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<AsignacionTipoProyectoPorDia> AsignacionesTipoProyectoPorDia { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<TipoActividad> TiposActividades { get; set; }

    }
}
