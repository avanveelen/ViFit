using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ViFit.Application;
using ViFit.Infrastructure.EF;

namespace ViFit.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public System.IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(this.Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // Add Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private class DefaultModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                var currentAssembly = Assembly.GetExecutingAssembly();
                var applicationAssembly = Assembly.GetAssembly(typeof(ICommand));
                var infrastructureAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));
                               
                builder.RegisterAssemblyTypes(currentAssembly).AsImplementedInterfaces();
                builder.RegisterAssemblyTypes(applicationAssembly).AsImplementedInterfaces();
                builder.RegisterAssemblyTypes(infrastructureAssembly).AsImplementedInterfaces();

                builder.RegisterAssemblyTypes(new[] {
                    applicationAssembly,
                    currentAssembly
                }).AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces();
                //builder.RegisterType<CharacterRepository>().As<ICharacterRepository>();
            }
        }
    }
}
