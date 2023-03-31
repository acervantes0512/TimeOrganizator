using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeOrganizatorApi.Controllers
{
    public class TipoTiempoController : CrudGenericoController<TipoTiempo>
    {
        private readonly ITipoActividadService _tipoActividadService;

        public TipoTiempoController(IGenericService<TipoTiempo> genericService, ITipoActividadService tipoActividadService) : base(genericService)
        {
            this._tipoActividadService = tipoActividadService;
        }

        [HttpGet]
        [Route("getByProjectType")]
        public async Task<ActionResult<IEnumerable<TipoActividadDTO>>> getByProjectType(int id)
        {
            var result = await this._tipoActividadService.ObtenerTiposDeActividadesPorTipoProyecto(id);
            return Ok(result);
        }
    }
}
