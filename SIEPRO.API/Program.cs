using Microsoft.Extensions.Options;
using SIEPRO.API.Infrastructure.Data.Contexts;
using SIEPRO.API.Infrastructure.Data.Repositories;

namespace SIEPRO.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //adicionando configuração de banco MongoDB
            builder.Services.Configure<SIEPROData>(builder.Configuration.GetSection(nameof(SIEPROData)));
            builder.Services.AddSingleton<ISIEPROData>(sg => sg.GetRequiredService<IOptions<SIEPROData>>().Value);

            // Add repositories
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //add cors
            builder.Services.AddCors();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.UseCorsWithDefaultPolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }


    public static class CorsExtensions
    {
        public static void UseCorsWithDefaultPolicy(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        }
    }
}
