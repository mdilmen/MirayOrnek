using FluentValidation.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MirayOrnek.Configurations;
using MirayOrnek.Configurations.Mapper;
using MirayOrnek.Configurations.Validators;
using MirayOrnek.Data;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.IO;

namespace MirayOrnek
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMirayOrnekTransient();
            builder.Services.AddAutoMapper(typeof(MirayOrnekMapperProfile));
            builder.Services.AddLogging();
            builder.Services.AddControllersWithViews().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<BasketSaveDtoValidator>();
                options.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>();
            });


            var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

            builder.Services.AddDbContext<MirayDbContext>(cfg =>
            {
                cfg.UseSqlServer(connectionString);
            }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}



