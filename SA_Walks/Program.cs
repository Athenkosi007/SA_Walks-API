
using Microsoft.EntityFrameworkCore;
using SA_Walks.API.Data;
using SA_Walks.API.Mappings;
using SA_Walks.API.Repositories;

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

            //Injecting the interface with the implementation SQLRegionRepository
            builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

            //Injecting the interface with the implementation InMemoryRegionRepository (in memory data source)
            //builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();


            //Adding AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
