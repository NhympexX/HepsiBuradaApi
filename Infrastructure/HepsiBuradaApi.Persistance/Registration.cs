﻿using HepsiBuradaApi.Application.Interfaces.Repositories;
using HepsiBuradaApi.Application.UnitOfWorks;
using HepsiBuradaApi.Persistance.Context;
using HepsiBuradaApi.Persistance.Repositories;
using HepsiBuradaApi.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Persistance
{
    public static class Registration
    {
        public static void addPersistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IUnitofWork), typeof(UnitOfWork));
        }
    }
}
