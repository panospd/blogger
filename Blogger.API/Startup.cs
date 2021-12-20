using Blogger.API.Api.Stories;
using Blogger.API.Core.Services;
using Blogger.API.Core.Services.BlogUseCases;
using Blogger.API.Core.Services.StoryUseCases;
using Blogger.API.Infrastructure;
using Blogger.API.Infrastructure.Respositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Blogger.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blogger.API", Version = "v1" });
            });

            services.AddDbContext<BloggerContext>(options => 
                options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Blogger;Integrated Security=True;"));

            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddScoped<BlogService>();

            services.AddTransient<IStoryRepository, StoryRepository>();
            services.AddScoped<StoryService>();
            services.AddScoped<Mapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blogger.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
