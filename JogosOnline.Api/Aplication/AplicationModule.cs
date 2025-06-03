using JogosOnline.Api.Repositories;
using JogosOnline.Api.Services;

namespace JogosOnline.APi.Aplication
{
    public static class AplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmbalagemRepository, EmbalagemRepository>();
            services.AddScoped<IEmbalagemService, EmbalagemService>();

            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();

            return services;
        }
    }
}

