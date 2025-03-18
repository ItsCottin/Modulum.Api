using System;
using System.Threading.Tasks;
using modulum.Infrastructure.Contexts;
using modulum.Server.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using modulum.Server.Settings;
using System.Runtime.CompilerServices;
using modulum.Application.Interfaces.Common;
using modulum.Infrastructure.Extensions;
using modulum.Application.Extensions;
using Hangfire;
using Microsoft.Extensions.FileProviders;
using modulum.Server.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(cfg =>
{
    cfg.DefaultApiVersion = new ApiVersion(1, 0);
});

var _configuration = builder.Configuration;

// Services - Avaliar quais métodos não são nescessários
//builder.Services.AddForwarding(_configuration);
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.AddCurrentUserService();
builder.Services.AddSerialization();
builder.Services.AddDatabase(_configuration);
builder.Services.AddServerStorage(); //TODO - should implement ServerStorageProvider to work correctly!
builder.Services.AddIdentity();
builder.Services.AddJwtAuthentication(builder.Services.GetApplicationSettings(_configuration));
builder.Services.AddSignalR();
//builder.Services.AddApplicationLayer();
builder.Services.AddApplicationServices();
//builder.Services.AddRepositories();
builder.Services.AddSharedInfrastructure(_configuration);
builder.Services.RegisterSwagger();
builder.Services.AddInfrastructureMappings();
builder.Services.AddHangfire(x => x.UseSqlServerStorage(//Environment.GetEnvironmentVariable("MODULUM_CONNECTION_STRING") ??
                            _configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();
builder.Services.AddControllers().AddValidators();
builder.Services.AddRazorPages();
//builder.Services.AddCredentialsCors();  // Meu primeiro método de Service fora do Program.cs - Nao deu certo

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Permite qualquer origem
              .AllowAnyMethod()   // Permite qualquer método (GET, POST, etc.)
              .AllowAnyHeader();  // Permite qualquer cabeçalho
    });
});

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});
builder.Services.AddLazyCache();
// Services - fim

var app = builder.Build();

app.UseForwarding(_configuration);  // Linha onde adiciona a politica de acesso na api
//app.UseExceptionHandling(env);


// FrameWork para Arquivo
//app.UseBlazorFrameworkFiles();
//app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
//    RequestPath = new PathString("/Files")
//});

app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard("/jobs", new DashboardOptions
{
    //DashboardTitle = localizer["BlazorHero Jobs"],
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

app.ConfigureSwagger(); // Configuração do Swagger - Documentação da API
app.UseEndpoints();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Initialize(_configuration);
app.Run();
