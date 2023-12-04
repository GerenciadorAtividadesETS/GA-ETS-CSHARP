using System.Reflection;
using GA_ETS.Data;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// CONEXÃO COM BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("GAETSConnection");
builder.Services.AddDbContext<GAETSContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// AUTO MAPPER
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// SWAGGER CONFIGURAÇÕES https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GAETS_API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    Console.WriteLine("CAMINHO: " + xmlPath);
    c.IncludeXmlComments(xmlPath);
});

// AUTENTICAÇÃO DE CERTIFICADO
builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// AUTENTICAÇÃO DE CERTIFICADO
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();