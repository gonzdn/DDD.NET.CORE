using DDD.NET.CORE.APPLICATION.Application.Services.Car;
using DDD.NET.CORE.DOMAIN.Repositories.Contracts;
using DDD.NET.CORE.INFRAESTRUCTURE;
using DDD.NET.CORE.INFRAESTRUCTURE.Repositories.Car;
using GraphQLServer.GraphQL;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Connection String  
            services.AddDbContext<ApplicationDbContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarRepository, CarRepository>();

            services.AddGraphQLServer().AddQueryType<Query>()
                                       .AddType<GraphQLTypes>()
                                       .AddMutationType<Mutation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path = "/playground"
                });
            }

            app.UseGraphQL("/api");

            app.UseRouting();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Ejecutando GraphQL!");
                });
                endpoints.MapGraphQL();
            });            
        }
    }
}