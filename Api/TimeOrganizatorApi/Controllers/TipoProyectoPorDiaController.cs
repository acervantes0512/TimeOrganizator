using Application.Services.Interfaces;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeOrganizatorApi.Controllers
{
    public class AsignacionTipoProyectoPorDiaController : CrudGenericoController<AsignacionTipoProyectoPorDia>
    {
        public AsignacionTipoProyectoPorDiaController(IGenericService<AsignacionTipoProyectoPorDia> genericService) : base(genericService)
        {
        }
    }
}
