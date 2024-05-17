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
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); //hangi ortama ait olduðumu buluyor 

builder.Services.AddPersistence(builder.Configuration); //yukarýdaki configurationu yazdýktan sonra bunun gelmesi önemli
builder.Services.AddInfrastructure(builder.Configuration); //yukarýdaki configurationu yazdýktan sonra bunun gelmesi önemli
builder.Services.AddApplication(); //mediatR için
builder.Services.AddCustomMapper();


//Bunla JWT yi swagger da etkinleþtirmiþ(auth arayüzü) oluyoruz
builder.Services.AddSwaggerGen(c =>
{

    //swagger da sol üstte ne yazacaðý
    c.SwaggerDoc("v1", new OpenApiInfo {Title= "HepsiAPI" , Version ="v1", Description= "Hepsi Api Swagger Client" });


    //kilide týkladýktan sonra bilgileri girmen için açýlan kutu
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat ="JWT",
        In = ParameterLocation.Header, //içine ne geleceði
        Description = @"Bearer yazýp boþluk býraktýktan sonra Token'ý girebilirsiniz "


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

app.ConfigureExceptionHandlingMiddleWare(); //middleware ý applicationa runtime mýma entegre etmiþ oldum
app.UseAuthorization();

app.MapControllers();

app.Run();
