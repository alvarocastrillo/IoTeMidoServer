using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADESDLL.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace IoTeMidoServer
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
            //nuevo
            JwtSettings settings = GetJwtSettings();

            services.AddSingleton<JwtSettings>(settings);

            services
                .AddAuthentication
                (
                    options =>
                    {
                        options.DefaultAuthenticateScheme = "JwtBearer";
                        options.DefaultChallengeScheme = "JwtBearer";
                    }
                )
                .AddJwtBearer
                (
                    "JwtBearer", jwtBearerOptions =>
                    {
                        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),

                            ValidateIssuer = true,
                            ValidIssuer = settings.Issuer,

                            ValidateAudience = true,
                            ValidAudience = settings.Audience,

                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.FromMinutes(settings.MinutesToExpiration)
                        };
                    }
                );


            services.AddAuthorization(cfg =>
                cfg.AddPolicy("CanAccessProducts", p =>
                    p.RequireClaim("CanAccessProducts", "true")));
            services.AddAuthorization(cfg =>
                cfg.AddPolicy("CanAccessCategories", p =>
                p.RequireClaim("CanAccessCategories", "true")));


            services.AddCors();
            services.AddControllers().AddNewtonsoftJson();
            //
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }//nuevo
            else {
                app.UseHsts();
            }
            //nuevo
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthentication(); 

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        //nuevo
        // encargar de obtener el ajuste de jwtsetting
        public JwtSettings GetJwtSettings()
        {
            JwtSettings settings = new JwtSettings();

            settings.Key = Configuration["JwtSettings:key"];
            settings.Audience = Configuration["JwtSettings:audience"];
            settings.Issuer = Configuration["JwtSettings:issuer"];
            settings.MinutesToExpiration = Convert.ToInt32(Configuration["JwtSettings:minutesToExpiration"]);

            return settings;
        }
    }
}
