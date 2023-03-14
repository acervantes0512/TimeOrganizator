using Application.Services.Interfaces;
using Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeOrganizatorApi.Controllers
{
    public class PlanActividadController : CrudGenericoController<PlanActividad>
    {
        public PlanActividadController(IGenericService<PlanActividad> genericService) : base(genericService)
        {
        }
    }
}
