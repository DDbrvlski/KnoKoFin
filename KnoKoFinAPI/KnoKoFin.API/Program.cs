using KnoKoFin.Infrastructure.Persistence;
using KnoKoFin.API.Configuration;
using Microsoft.EntityFrameworkCore;
using KnoKoFin.Infrastructure;

namespace KnoKoFin.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<KnoKoFinContext>(options =>
                options.UseSqlServer(builder.Configuration
                .GetConnectionString("KnoKoFinContext") ?? 
                throw new InvalidOperationException("Connection string 'KnoKoFinContext' not found.")));
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();


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
