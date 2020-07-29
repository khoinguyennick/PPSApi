using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using ProjectPorfolioSystem.Manager.Implementations;
using ProjectPorfolioSystem.Manager.Interface;
using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Repository.Implementations;
using ProjectPorfolioSystem.Repository.Interface;
using ProjectPorfolioSystem.Utils.Interface;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjectPorfolioSystem
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContextConnection")));
            services.AddDbContext<ProjectPorfolioSystemContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContextConnection")));
            #region Identity
            // ===== Add Identity ========
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DBContext>()
                .AddDefaultTokenProviders();
            #endregion
            #region AspIdentity options
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                //options.User.RequireUniqueEmail = false;
            });

            #endregion
            #region Swagger 
                services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Project Porfolio System API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    In = "header",
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
            });
                c.OperationFilter<Utils.Implementations.Utils.FileUploadOperation>();
            });
            #endregion
            #region JWT
            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
            services.AddAuthorization();
            #endregion
            #region Utils
            services.AddScoped<IUtils, Utils.Implementations.Utils>();
            #endregion
            #region Repository
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IWorkTimeRepository, WorkTimeRepository>();
            services.AddScoped<IWorkTimeInProjectRepository, WorkTimeInProjectRepository>();
            #endregion
            #region Manager
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IProjectManager, ProjectManager>();
            services.AddScoped<IWorkTimeManager, WorkTimeManager>();
            services.AddScoped<IWorkTimeInProjectManager, WorkTimeInProjectManager>();
            #endregion
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DBContext dbContext)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}
            // ===== Use Authentication ======
            app.UseAuthentication();
            #region Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Porfolio System API");
                c.DocExpansion(DocExpansion.None);
            });
            #endregion
            // ===== Create tables ======
            dbContext.Database.EnsureCreated();
            app.UseHttpsRedirection();
            app.UseMvc();
            #region Static Files
            app.UseStaticFiles();
            #endregion
            app.UseCors("AllowAllHeaders");
        }
    }
}
