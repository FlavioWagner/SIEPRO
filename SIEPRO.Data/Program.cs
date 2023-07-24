using Microsoft.EntityFrameworkCore;
using SIEPRO.Data.src.Infrastructure.Data.Contexts;
using System.Configuration;

namespace SIEPRO.Data
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            var database = configuration.GetSection("SIEPRODatabase");

            builder.Services.AddDbContext<SIEPROContext>(options =>
            {
                options.UseNpgsql(database["DefaultConnection"]);
            });

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