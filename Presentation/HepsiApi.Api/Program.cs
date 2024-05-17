using HepsiApi.Persistence;
using HepsiApi.Application;
using HepsiApi.Mapper;
using HepsiApi.Infrastructure;
using HepsiApi.Application.Exceptions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); //hangi ortama ait oldu�umu buluyor 

builder.Services.AddPersistence(builder.Configuration); //yukar�daki configurationu yazd�ktan sonra bunun gelmesi �nemli
builder.Services.AddInfrastructure(builder.Configuration); //yukar�daki configurationu yazd�ktan sonra bunun gelmesi �nemli
builder.Services.AddApplication(); //mediatR i�in
builder.Services.AddCustomMapper();


//Bunla JWT yi swagger da etkinle�tirmi�(auth aray�z�) oluyoruz
builder.Services.AddSwaggerGen(c =>
{

    //swagger da sol �stte ne yazaca��
    c.SwaggerDoc("v1", new OpenApiInfo {Title= "HepsiAPI" , Version ="v1", Description= "Hepsi Api Swagger Client" });


    //kilide t�klad�ktan sonra bilgileri girmen i�in a��lan kutu
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat ="JWT",
        In = ParameterLocation.Header, //i�ine ne gelece�i
        Description = @"Bearer yaz�p bo�luk b�rakt�ktan sonra Token'� girebilirsiniz "


    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type= ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleWare(); //middleware � applicationa runtime m�ma entegre etmi� oldum
app.UseAuthorization();

app.MapControllers();

app.Run();
