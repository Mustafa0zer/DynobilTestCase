using Dynobil.DataAccess.Abstract;
using Dynobil.DataAccess.Concrete;
using Dynobil.DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.DataAccess
{
    public static class DataAccessSeviceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DynobilContext>(options => options.UseSqlServer(configuration.GetConnectionString("DynobiTestContext")));
            services.AddScoped<ISellingAdvertRepository, SellingAdvertRepository>();
            services.AddScoped<ICarBrandRepository, CarBrandRepository>();
            services.AddScoped<ICarModelRepository, CarModelRepository>();


           

                return services;
        }
    }
}
