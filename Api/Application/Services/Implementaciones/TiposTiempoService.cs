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
    public class TiposTiempoService : ITiposTiempoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TiposTiempoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoTiempo, TipoTiempoDTO>()
                    .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                    .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                    .ForMember(dest => dest.TipoProyectoId, opt => opt.MapFrom(src => src.TipoProyectoId));
            }).CreateMapper();
        }

        public async Task<List<TipoTiempoDTO>> TiposTiempoPorIdProyecto(int idTipoProyecto)
        {
            List<TipoTiempo> rta = await this._unitOfWork.TiposTiempoRepository.GetByProjectIdAsync(idTipoProyecto);
            return _mapper.Map<List<TipoTiempoDTO>>(rta);
        }
    }
}
