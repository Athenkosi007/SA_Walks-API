
using Microsoft.EntityFrameworkCore;
using SA_Walks.API.Data;

namespace SA_Walks
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

            //builder.Services.AddDbContext<SA_WalksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")));

            builder.Services.AddDbContext<SA_WalksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")!));



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
