using Dynobil.Business.Abtraction;
using Dynobil.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.Business
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISellingAdvertService, SellingAdvertManager>();
            services.AddScoped<ICarBrandService, CarBrandManager>();
            services.AddScoped<ICarModelService, CarModelManager>();


            return services;
        }
    }
}
