using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeOrganizatorApi.Controllers
{
    public class TipoActividadController : CrudGenericoController<TipoActividad>
    {
        private readonly ITipoActividadService _tipoActividadService;

        public TipoActividadController(IGenericService<TipoActividad> genericService, ITipoActividadService tipoActividadService) : base(genericService)
        {
            this._tipoActividadService = tipoActividadService;
        }

        [HttpGet]
        [Route("GetByProjectType")]
        public async Task<ActionResult<IEnumerable<TipoActividadDTO>>> GetByProjectType(int id)
        {
            return Ok(await this._tipoActividadService.ObtenerTiposDeActividadesPorTipoProyecto(id));
        }
    }
}
