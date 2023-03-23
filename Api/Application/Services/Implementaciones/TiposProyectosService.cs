using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Persistence.UnitOfWork;
using Shared.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementaciones
{
    public class TiposProyectosService : ITiposProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;

        public TiposProyectosService(IMapper mapper, IUnitOfWork unitOfWork, IOptions<JwtSettings> jwtSettings, ITokenService tokenService)
        {
            this._unitOfWork = unitOfWork;
            this._tokenService = tokenService;
            this._jwtSettings = jwtSettings.Value;

            _mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<TipoProyecto, TipoProyectoDTO>()
                    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                    .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                    .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.EstadoId))
                    .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId));
            }).CreateMapper();
        }

        public async Task<List<TipoProyectoDTO>> TiposProyectosPorIdUsuario(int idUsuario)
        {
            List<TipoProyecto> rta = await this._unitOfWork.TiposProyectosRepository.GetByUserIdAsync(idUsuario);
            return _mapper.Map<List<TipoProyectoDTO>>(rta);
        }
    }
}
