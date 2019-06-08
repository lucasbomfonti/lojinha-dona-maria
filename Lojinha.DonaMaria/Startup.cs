using Lojinha.DonaMaria.Data.Repository;
using Lojinha.DonaMaria.Data.Repository.Interface;
using Lojinha.DonaMaria.Data.Service;
using Lojinha.DonaMaria.Data.Service.Interface;
using Lojinha.DonaMaria.Helper;
using Lojinha.DonaMaria.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Tmss_Back_end.Data.Repository.Context;

namespace Lojinha.DonaMaria
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
            MapperConfig.RegisterMappings();
          
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Lojinha da Dona Maria",
                    Version = "v1"
                });

            });
            services.AddScoped<LoginService>();
            services.AddScoped<LoginRepository>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();

            ServiceFactory.SetServiceProvider(services.BuildServiceProvider());
            new Agent().CreateDatabase();

            services.ConfigureSwaggerGen(options =>
            {
                options.DocumentFilter<SecurityRequirementsDocumentFilter>();
                options.AddSecurityDefinition("Authorization",
                    new ApiKeyScheme
                    {
                        Description = "Token received at Login",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware(typeof(HandleExceptionHelper));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project");
            });
        }

        public class SecurityRequirementsDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument document, DocumentFilterContext context)
            {
                document.Security = new List<IDictionary<string, IEnumerable<string>>>
                {
                    new Dictionary<string, IEnumerable<string>>
                    {
                        { "Authorization", new string[]{ } },
                        { "Value", new string[]{ } },
                    }
                };
            }
        }

    }
}
