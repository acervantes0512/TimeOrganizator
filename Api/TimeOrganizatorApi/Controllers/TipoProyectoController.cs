using Application.Services.Interfaces;
using Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TimeOrganizatorApi.Controllers
{
    public class TipoProyectoController : CrudGenericoController<TipoProyecto>
    {
        private readonly ITiposProyectosService _tiposProyectosService;

        public TipoProyectoController(IGenericService<TipoProyecto> genericService, ITiposProyectosService tiposProyectosService) : base(genericService)
        {
            this._tiposProyectosService = tiposProyectosService;
        }

        [HttpGet]
        [Route("GetByUser")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TipoProyecto>>> GetByUser()
        {
            var idUsuario = int.Parse(User.FindFirstValue("idUsuario"));
            return Ok(this._tiposProyectosService.TiposProyectosPorIdUsuario(Convert.ToInt32(idUsuario)));
        }
    }
}
