using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore2.Middleware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetCore2.IntegrationTests
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            //if (env.IsDevelopment())
            //{
            //    var builder = new ConfigurationBuilder();
            //    builder.AddUserSecrets<Startup>();
            //    Configuration = builder.Build();
            //}
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IoC.AddRegistration(services);
            
            //services.AddDbContext<NBAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Determine base path for the application
            //var basePath = AppContext.BaseDirectory;

            //var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            //var fileName = Path.GetFileName(assemblyName + ".xml");

            //var filePath = Path.Combine(basePath, fileName);
            //var filePath = Path.Combine(basePath, "NetCore2.xml");

            //services.AddSwaggerGen(config =>
            //{
            //    config.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            //    {
            //        Title = "Ejemplo"
            //    });

            //    config.IncludeXmlComments(filePath);

            //    config.AddSecurityDefinition("Bearer", new OAuth2Scheme()
            //    {
            //        Description = "Auth OAuth2",
            //        TokenUrl = "https://identityServer.azurewebsites.net/oauth2/token",
            //        Flow = "password",
            //        Type = "oauth2"
            //    });
            //});

            //services.AddApplicationInsightsTelemetry();

            //var issuer = Configuration["AuthorizationSettings:Issuer"];
            //var audience = Configuration["AuthorizationSettings:Audience"];
            //var signingKey = Configuration["AuthorizationSettings:SigningKey"];

            //services.AddAuthorization(options =>
            //{
            //    options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            //                                .RequireAuthenticatedUser()
            //                                .Build();
            //});

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options =>
            //        {
            //            options.Audience = audience;
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidIssuer = issuer,
            //                ValidateIssuerSigningKey = true,
            //                ValidateLifetime = true,
            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signingKey))
            //            };
            //        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseAuthentication();
            
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseLogMiddleware();
            //app.UseSampleMiddlewareExtension();

            //app.UseSwagger();
            //app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "API de ejemplo Swagger"));

            app.UseMvc();

            //     Applies any pending migrations for the context to the database. Will create the
            //     database if it does not already exist.
            //     Note that this API is mutually exclusive with DbContext.Database.EnsureCreated().
            //     EnsureCreated does not use migrations to create the database and therefore the
            //     database that is created cannot be later updated using migrations.
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<NBAContext>();
            //    var pendingMigrations = context.Database.GetPendingMigrations().ToList();

            //    if (!pendingMigrations.Any())
            //        return;

            //    context.Database.Migrate();
            //}
        }
    }
}
