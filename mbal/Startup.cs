using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using mbal.Models;
using Microsoft.EntityFrameworkCore;

namespace mbal
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;";
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
