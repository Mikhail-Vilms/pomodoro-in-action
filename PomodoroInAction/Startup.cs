using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PomodoroInAction.Controllers;
using PomodoroInAction.Models;
using PomodoroInAction.Repositories;
using PomodoroInAction.ServiceInterfaces;
using PomodoroInAction.Services;
using System;
using System.Text;

namespace PomodoroInAction
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
            // Injecting ApplictionSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            // Configuring database connection
            services.AddDbContext<PomodoroAppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

            // Configuration for Identity package - providing "AppUser" as "Identity" class
            // ??? Allows to use (DI) UserManager instance in AppUserController. #TODO google it.
            services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<PomodoroAppDbContext>();


            //services.AddMvc();

            //services.AddControllers()
            //    .AddNewtonsoftJson();

            services.AddMvc()
     .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

            // Enable / disable built-in ModelState validation
            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});


            services.AddCors();


            // JWT Authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                // We can restrict authentication resourses only to type of https
                x.RequireHttpsMetadata = false;
                // Do we want to save authentication token inside the server after successful authentication?
                x.SaveToken = false;

                // Define how we want to validate token once it is recieved from the client side.
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    // System will validate the security key (???) during validation. (???)
                    ValidateIssuerSigningKey = true,
                    // String for the JWT encryption
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString())),
                    
                    // Verify issuer
                    ValidIssuer = Configuration["ApplicationSettings:JWT_Issuer"].ToString(),
                    ValidateIssuer = true,

                    // Verify audience ??? #TODO google it
                    ValidateAudience = false,

                    // Checking an expioration time of token(???)
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddScoped<IDBTransaction, DBTransaction>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<ITicketService, TicketService>();


            services.AddScoped<ModelStateValidationActionFilterAttribute>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(builder => builder
                .WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseAuthentication();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
