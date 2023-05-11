using Backend.Challenge.Configuration;
using Backend.Challenge.Contracts;
using Backend.Challenge.RavenDB;
using Backend.Challenge.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Backend.Challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RavenConfiguration>(Configuration.GetSection(nameof(RavenConfiguration)));

            services.AddRazorPages();

            services.AddTransient<ICommentService, CommentService>()
                    .AddTransient<IUserService, UserService>()
                    .AddTransient<IUserRepository, UserRepository>()
                    .AddTransient<ICommentService, CommentService>()
                    .AddTransient<ICommentRepository, CommentRepository>()
                    .AddTransient<IUnseenCommentRepository, UnseenCommentRepository>()
                    .AddSingleton<IDocumentStoreHolder, DocumentStoreHolder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
