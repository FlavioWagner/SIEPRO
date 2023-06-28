using Microsoft.Extensions.Options;
using SIEPRO.API.Infrastructure.Data.Contexts;
using SIEPRO.API.Infrastructure.Data.Repositories;
using System.Reflection;

namespace SIEPRO.API
{
    public class Program
    {
        private static void RegistrarRepositories(WebApplicationBuilder builder)
        {
            var namespaceName = "SIEPRO.API.Application.Entities";

            // Obter o Assembly da sua aplicação
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Obter todas as classes do namespace especificado
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                // Verificar se a classe pertence ao namespace desejado
                if (type.Namespace == namespaceName)
                {
                    Type tipoGenerico = typeof(IRepository<>).MakeGenericType(type);
                    Type tipoImplementacao = typeof(Repository<>).MakeGenericType(type);
                    builder.Services.AddSingleton(tipoGenerico, tipoImplementacao);
                }
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //adicionando configuração de banco MongoDB
            builder.Services.Configure<SIEPROData>(builder.Configuration.GetSection(nameof(SIEPROData)));
            builder.Services.AddSingleton<ISIEPROData>(sg => sg.GetRequiredService<IOptions<SIEPROData>>().Value);

            // Add repositories
            RegistrarRepositories(builder);

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


            app.MapControllers();

            app.Run();
        }
    }
}