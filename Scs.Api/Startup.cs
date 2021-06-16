using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scs.Api.Core;
using Scs.Application;
using Scs.Application.Commands;
using Scs.Application.Queries;
using Scs.DataAccess;
using Scs.Implementation;
using Scs.Implementation.Commands;
using Scs.Implementation.Queries;
using Scs.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scs.Api
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
            services.AddTransient<ScsContext>();

        /* Brand */
            //services.AddTransient<ICreateBrandCommand, RawSqlCreateBrandCommand>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommad>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<CreateBrandValidator>();
            
            
            services.AddTransient<IApplicationActor, FakeApiActor>();
            services.AddTransient<UseCaseExecutor>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}