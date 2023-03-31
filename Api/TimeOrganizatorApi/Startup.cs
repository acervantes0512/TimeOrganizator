using Application.Services.Implementaciones;
using Application.Services.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.EntityFramework;
using Persistence.Repository;
using Persistence.UnitOfWork;
using Shared;
using Shared.Authentication;
using System.Text;
using WebApi.Middlewares;
using AutoMapper;
using AutoMapper.Configuration;

namespace TimeOrganizatorApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeOrganizatorApi", Version = "v1" });
            });

            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITiposProyectosRepository, TiposProyectosRepository>();
            services.AddScoped<ITiposProyectosService, TiposProyectosService>();
            services.AddScoped<ITiposActividadRepository, TiposActividadRepository>();
            services.AddScoped<ITipoActividadService, TipoActividadService>();
            services.AddScoped<ITiposTiempoRepository, TiposTiempoRepository>();
            services.AddScoped<ITiposTiempoService, TiposTiempoService>();
            services.AddScoped<ITokenService, JWTService>();
            services.AddAutoMapper(typeof(Startup));



            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            //JWT Configuration
            var jwtSettings = Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.UserRoles.administrador.ToString(), policy => policy.RequireRole(Constants.UserRoles.administrador.ToString()));
                options.AddPolicy(Constants.UserRoles.usuario.ToString(), policy => policy.RequireRole(Constants.UserRoles.usuario.ToString()));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });            

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TimeOrganizatorDBContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<TimeOrganizatorDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeOrganizatorApi v1"));
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            
        }
    }
}
