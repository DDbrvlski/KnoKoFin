using KnoKoFin.API.Configuration;
using KnoKoFin.Infrastructure.Common.Exceptions;
using KnoKoFin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddControllers();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();

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
