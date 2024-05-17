using FluentValidation;
using HepsiApi.Application.Bases;
using HepsiApi.Application.Behaviours;
using HepsiApi.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application
{
    public static class Registration
    {

        public static void AddApplication(this IServiceCollection services) //this sayesinde kendi metodunu kendi alıyor
        {
            var assembly=Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly,typeof(BaseRules)); //ruleslarım baseRules dan türetildiğinden bunları bulup servise ekler fonksiyon sayesinde

            services.AddMediatR(cfg=> cfg.RegisterServicesFromAssemblies(assembly)); //configuration yazıyoruz

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture= new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior< , >) , typeof(FluentValidationBehaviour< ,> )); 
            services.AddTransient(typeof(IPipelineBehavior< , >) , typeof(RedisCacheBehavior< ,> )); 
        }

        public static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly, //assembly Application içinde bulunduğu proje
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

            foreach(var item in types) 
            {
                services.AddTransient(item);
                     
            }
            return services;
        }
    }
}
