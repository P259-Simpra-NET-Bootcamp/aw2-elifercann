﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories.Abstract;
using Repositories.Context;
using Repositories.EfCore;
using Services.Abstract;
using Services.Concrete;

namespace SimApi.Extensions
{
    public static class ServiceExtensions
    {
       
        public static void AddConfigureMapperExtension(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
            

        }
      
        public static void AddCustomSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sim Api Management", Version = "v1.0" });


                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Sim Management for IT Company",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, new string[] { }}
            });
            });
        }
        public static void AddDbContextExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            var dbType = Configuration.GetConnectionString("DbType");
            if (dbType == "SQL")
            {
                var dbConfig = Configuration.GetConnectionString("sqlConnection");
                services.AddDbContext<ApplicationContext>(opts =>
                opts.UseSqlServer(dbConfig));
            }
            else if (dbType == "PostgreSql")
            {
                var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
                services.AddDbContext<ApplicationContext>(opts =>
                  opts.UseNpgsql(dbConfig));
            }

        }
    }
}
