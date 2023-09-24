using Microsoft.EntityFrameworkCore;
using OrderUpdate.Manager;
using OrderUpdate.Models;

namespace OrderUpdate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();



            builder.Services.AddDbContext<Context>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("Con")));
            builder.Services.AddScoped<Iorder,OrderManager>();  
            builder.Services.AddScoped<IsubOrder, SubOrderManager>();  


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