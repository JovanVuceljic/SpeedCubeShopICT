﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Scs.Api.Core;
using Scs.Application;
using Scs.Application.Commands;
using Scs.Application.Queries;
using Scs.DataAccess;
using Scs.Implementation.Commands;
using Scs.Implementation.Logging;
using Scs.Implementation.Queries;
using Scs.Implementation.Validators;
using Newtonsoft.Json;
using Scs.Implementation;

namespace Scs.Api
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
            services.AddTransient<ScsContext>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommad>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddHttpContextAccessor();

            //services.AddTransient<IApplicationActor, AdminFakeActor>();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                Console.WriteLine(accessor);
                var user = accessor.HttpContext.User;

                Console.WriteLine(user);
                if (user.FindFirst("ActorData") == null)
                {

                    Console.WriteLine("InvalidOperationException");
                    throw new InvalidOperationException("Actor data doesnt exist in token.");
                }

                var actorString = user.FindFirst("ActorData").Value;

                Console.WriteLine(actorString);
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                Console.WriteLine(actor);
                return actor;

            }); 
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<JwtManager>();




            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
