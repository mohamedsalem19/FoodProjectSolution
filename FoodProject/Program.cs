
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FoodProject.Config;
using FoodProject.Data;
using FoodProject.Midllwares;
using FoodProject.Models;
using FoodProject.Services;
using FoodProject.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace FoodProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            builder.Services.AddIdentity<UserApplication, IdentityRole>().AddEntityFrameworkStores<Context>();
            builder.Services.AddAutoMapper(typeof(CategoryProfile).Assembly);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container =>
            {
                container.RegisterModule(new AutoFacModule());
            });
            builder.Services.AddResponseCompression(opt =>
            {
                opt.EnableForHttps = true;
                opt.Providers.Add<GzipCompressionProvider>();
                opt.Providers.Add<BrotliCompressionProvider>();
            });

            builder.Services.Configure<GzipCompressionProviderOptions>(opt =>
            {
                opt.Level = System.IO.Compression.CompressionLevel.Fastest;
            });

            builder.Services.Configure<BrotliCompressionProviderOptions>(opt =>
            {
                opt.Level = System.IO.Compression.CompressionLevel.Optimal;
            });
            builder.Services.AddMediatR(typeof(Program).Assembly);

            var app = builder.Build();

            app.UseResponseCompression();
            AutoMapperService.Mapper = app.Services.GetService<IMapper>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<GlobalErrorHandlerMiddlware>();
            app.UseMiddleware<TransactionMiddlware>();

            app.MapControllers();

            app.Run();
        }
    }
}
