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
        private readonly ITiposTiempoService _tipoTiempoService;

        public TipoTiempoController(IGenericService<TipoTiempo> genericService, ITiposTiempoService tipoTiempoService) : base(genericService)
        {
            this._tipoTiempoService = tipoTiempoService;
        }

        [HttpGet]
        [Route("getByProjectType")]
        public async Task<ActionResult<IEnumerable<TipoActividadDTO>>> getByProjectType(int id)
        {
            var result = await this._tipoTiempoService.TiposTiempoPorIdProyecto(id);
            return Ok(result);
        }
    }
}
