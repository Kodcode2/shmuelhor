
using AgentsRest.Date;
using AgentsRest.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AgentsRest
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
            builder.Services.AddDbContextFactory<ApplicationDbContext>();
            builder.Services.AddSwaggerGen();
            

            builder.Services.AddControllers();


            builder.Services.AddScoped<IAgentService, AgentService>();
            builder.Services.AddScoped<ITargetService, TargetService>();
            builder.Services.AddScoped<IMissionService, MissionService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<ILoginService, LoginService>();

            builder.Services.AddHttpClient();

   //         builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   //.AddJwtBearer(options =>
   //{
   //    options.TokenValidationParameters = new()
   //    {
   //        ValidateIssuer = true,
   //        ValidateAudience = true,
   //        ValidateIssuerSigningKey = true,
   //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
   //        ValidAudience = builder.Configuration["Jwt:Audience"],
   //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
   //    };
   //});

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
