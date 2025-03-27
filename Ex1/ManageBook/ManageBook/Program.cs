
using BookStore.Configs;
using ManageBook.Data;
using Microsoft.EntityFrameworkCore;

namespace ManageBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add dbcontext
            builder.Services.AddDbContext<APIDBContext>(opt => 
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"))
            );

            // add config services
            builder.Services.AddUserService();

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
