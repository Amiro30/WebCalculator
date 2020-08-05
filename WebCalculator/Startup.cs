using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebCalculator.Models;
using Microsoft.EntityFrameworkCore;
using WebCalculator.Interfaces;
using WebCalculator.Service;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace WebCalculator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<CalcContext>(opt =>
               opt.UseInMemoryDatabase("CalcHistory"));

            services.AddTransient<ICalculator, Calculator>();

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calculator API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //seed database
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = app.ApplicationServices.GetService<CalcContext>();
               // AddTestData(context);
            }

            //swagger configure
            var swaggerOptions = new Options.SwaggerOptions();
            Configuration.GetSection(nameof(Options.SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });


            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //private static void AddTestData(CalcContext context)
        //{
        //    var transaction1 = new History
        //    {
        //        Id = 1,
        //        Result = 10,
        //        FirstNumber = 5,
        //        SecondNumber = 5,
        //        OperationType = '+'
        //    };

        //    context.Operations.Add(transaction1);

        //    var transaction2 = new History
        //    {
        //        Id = 2,
        //        Result = 55,
        //        FirstNumber = 65,
        //        SecondNumber = 10,
        //        OperationType = '-'
        //    };

        //    context.Operations.Add(transaction2);

        //    context.SaveChanges();
        //}

    }
}
