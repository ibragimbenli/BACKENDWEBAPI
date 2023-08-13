using Ah.Business.Implementation;
using Ah.Business.Interface;
using Ah.Business.Profiles;
using Ah.DataAccess.EF.Repositoryies;
using Ah.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Business
{
    public static class ServicesCollectionExtentions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductBs, ProductBs>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeBs, EmployeeBs>();


            services.AddAutoMapper(typeof(ProductMapperProfile).Assembly);//aynı zamanda DI yapmamızı sağlıyor

        }
    }
}
