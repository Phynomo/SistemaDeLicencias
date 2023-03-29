using Microsoft.Extensions.DependencyInjection;
using SistemaLicencias.BusinessLogic.Service;
using SistemaLicencias.DataAccess;
using SistemaLicencias.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaLicencias.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAcces(this IServiceCollection service, string connectionString)
        {
            service.AddScoped<TipoLicenciaRepository>();
            service.AddScoped<SolicitanteRepository>();
            service.AddScoped<EmpleadoRepository>();
            service.AddScoped<AprobadosRepository>();
            service.AddScoped<RechazadosRepository>();
            service.AddScoped<UsuarioRepository>();
            service.AddScoped<SolicitudRepository>();
            service.AddScoped<RolesRepository>();
            service.AddScoped<PantallasRepository>();


            LicenciaContext.BuildConnectionString(connectionString);
        }

        public static void BussinessLogic(this IServiceCollection service)
        {
            service.AddScoped<LicenciaServivce>();
            service.AddScoped<SeguService>();
        }
    }
}
