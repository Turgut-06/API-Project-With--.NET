using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Exceptions
{
    public static class ConfigureExceptionMiddleware
    {

       public static void ConfigureExceptionHandlingMiddleWare(this IApplicationBuilder app) //IApplicationBuilder WebService ı kullanmamızı sağlıyor
        {
            app.UseMiddleware<ExceptionMiddleware>(); //programın runtime ında middleware ın geçerli olmasını sağlar
        }

    }
}
