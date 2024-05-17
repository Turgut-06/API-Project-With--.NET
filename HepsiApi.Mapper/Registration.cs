using HepsiApi.Application.Interfaces.AutoMapper;
using HepsiApi.Mapper.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Mapper
{
    public static class Registration
    {
        //bu registrationları program.cs kısmında da tanıtıyorum
        public static void AddCustomMapper(this IServiceCollection services) //this sayesinde kendi metodunu kendi alıyor
        {
          services.AddSingleton<IMapper,AutoMapper.Mapper>(); //kendi yazdığım IMapper ve Mapper
        }
    }
}
