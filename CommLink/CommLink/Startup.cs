using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommLink
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSignalR();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    //.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }
        public void Configure(IApplicationBuilder app)
        {


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();
            app.UseWebSockets();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ClientHub>("/ClientHub");
               // endpoints.MapHub<ServerHub>("/ServerHub");
            });
        }
    }
}
