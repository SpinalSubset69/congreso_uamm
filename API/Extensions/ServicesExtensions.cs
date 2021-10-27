using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using API.Helpers;
using API.Mails;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {            
            services.AddTransient<IEmailService, EmailService>();
            services.AddAutoMapper(typeof(MappingProfiles));            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddCors(c => {
                c.AddPolicy("CorsPolicy", options => {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(e => e.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationResponse(){
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            
            return services;
        }
    }
}