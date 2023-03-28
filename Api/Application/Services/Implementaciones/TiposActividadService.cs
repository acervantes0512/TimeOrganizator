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
    public class TipoActividadService : ITipoActividadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public TipoActividadService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoActividad, TipoActividadDTO>()
                    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                    .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                    .ForMember(dest => dest.EstadoId, opt => opt.MapFrom(src => src.EstadoId))
                    .ForMember(dest => dest.TipoProyectoId, opt => opt.MapFrom(src => src.TipoProyectoId));
            }).CreateMapper();
        }

        public async Task<List<TipoActividadDTO>> ObtenerTiposDeActividadesPorTipoProyecto(int idTipoProyecto)
        {
            List<TipoActividad> rta = await this._unitOfWork.TiposActividadRepository.GetByTipoProyectoAsync(idTipoProyecto);
            return _mapper.Map<List<TipoActividadDTO>>(rta);
        }
    }
}
