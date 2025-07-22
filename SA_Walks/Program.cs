using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SA_Walks.API.Data;
using SA_Walks.API.Mappings;
using SA_Walks.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;

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

            builder.Services.AddDbContext<SA_WalksAuthDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SA_WAlksConnString")!));

            //Injecting the interface with the implementation SQLRegionRepository
            builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
            //Injecting the interface with the implementation SQLWalkRepository
            builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();
            //Injecting the interface with the implementation TokenRepository
            builder.Services.AddScoped<ITokenRepository, TokenRepository>();

            //Injecting the interface with the implementation InMemoryRegionRepository (in memory data source)
            //builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();

            //identity framework core for authentication
            builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("SA_Walks")
                .AddEntityFrameworkStores<SA_WalksAuthDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //options.Lockout.MaxFailedAccessAttempts = 5;

                // User settings
                //options.User.RequireUniqueEmail = true;
            });


            //Adding AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

            // JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
