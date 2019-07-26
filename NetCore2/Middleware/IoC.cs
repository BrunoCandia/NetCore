using Microsoft.Extensions.DependencyInjection;
using NetCore2.Client;
using NetCore2.Client.Interfaces;
using NetCore2.Services;
using NetCore2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IPlayerService, PlayerService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IYoutubeClient, YoutubeClient>();

            services.AddScoped<IYoutubeService, YoutubeService>();

            return services;
        }
    }
}
