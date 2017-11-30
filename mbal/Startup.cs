using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using mbal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using mbal.Secrete;

namespace mbal
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(cfg =>
                  {
                      cfg.RequireHttpsMetadata = false;
                      cfg.SaveToken = true;

                      cfg.TokenValidationParameters = new TokenValidationParameters()
                      {
                          ValidIssuer = "Fiver.Security.Bearer",
                          ValidAudience = "Fiver.Security.Bearer",
                          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Fiver.Security.Bearer"))
                      };

                  });

                services.AddMvc()
                .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            var connection = @"Server=(localdb)\mssqllocaldb;Database=MBAL;Trusted_Connection=True;";
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseMvc();
            
        }
    }
}
