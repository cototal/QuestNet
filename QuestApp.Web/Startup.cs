using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuestApp.Web.Config;
using QuestApp.Web.Hubs;
using QuestApp.Web.Services;
using QuestApp.Web.Services.ActionHandlers;
using System.Collections.Generic;

namespace QuestApp.Web
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
            var gameConfig = new MainConfig();
            Configuration.GetSection("game").Bind(gameConfig);
            services.AddSingleton(new HelpAction(gameConfig.Help));
            services.AddSingleton(srv =>
            {
                var helpAction = srv.GetService<HelpAction>();
                return new ActionHandler(gameConfig, new Dictionary<string, IGameAction>
                {
                    { "help", helpAction }
                });
            });

            services.AddSignalR();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSignalR(routes =>
            {
                routes.MapHub<SampleHub>("/sampleHub");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
