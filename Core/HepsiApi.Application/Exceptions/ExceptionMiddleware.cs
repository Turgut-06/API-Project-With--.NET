using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Application.Exceptions
{
	public class ExceptionMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
		{
			try
			{
				await next(httpContext); //httpContext i geçirmeye çalışıyorum geçiremezsem hata fırlatıyor,httpContext yapısı aldığım hatayı bana dönen bir yapı
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
		{
			int statusCode = GetStatusCode(exception); //gelen hatamın status codunu buldum
			httpContext.Response.ContentType = "application/json";
			httpContext.Response.StatusCode = statusCode;

			if(exception.GetType() == typeof(ValidationException)) //validationException FluentValidation dan geliyor			
			{
				return httpContext.Response.WriteAsync(new ExceptionModel
				{
					Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
					StatusCode = StatusCodes.Status400BadRequest // validation işleminden geçemezsen badRequest dönsün 
				}.ToString());

			}

			List<string> errors = new()
			{
				exception.Message,
			};

			return httpContext.Response.WriteAsync(new ExceptionModel //oluşturduğum ExceptionModel a değerleri eşitliyorum
			{
				Errors=errors,
				StatusCode=statusCode
			}.ToString()); //toString json a dönüştürür
		}

		private static int GetStatusCode(Exception exception) => //aç-kapa yerine geçer
			exception switch
			{
				BadRequestException => StatusCodes.Status400BadRequest,
				NotFoundException => StatusCodes.Status400BadRequest,
				ValidationException => StatusCodes.Status422UnprocessableEntity, // işlenemeyen entity
				_ => StatusCodes.Status500InternalServerError  //switch case in default kısmına karşılık geliyor 

			};


	}
}

