using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeOrganizatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IGenericService<Usuario> _genericService;

        public UsuarioController(IUsuarioService usuarioService, IGenericService<Usuario> genericService)
        {
            this._usuarioService = usuarioService;
            this._genericService = genericService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> CreateUser(Usuario user)
        {
            UsuarioDto createdUser = await _usuarioService.CreateUserAsync(user);

            return Ok(createdUser);
        }

        [HttpGet]
        [Route("GetByUsername")]        
        public async Task<ActionResult> GetByUsername(string username)
        {
            UsuarioDto createdUser = await _usuarioService.GetByUsernameAsync(username);

            return Ok(createdUser);
        }
    }
}
