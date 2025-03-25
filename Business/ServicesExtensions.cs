using Business.Services;
using Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ServicesExtensions
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<ClienteServiceAsync>();

        }
    }
}
