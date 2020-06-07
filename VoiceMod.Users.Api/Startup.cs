using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using VoiceMod.Common.Extensions;
using VoiceMod.Common.Handlers;
using VoiceMod.Users.Api.Configuration.EF;
using VoiceMod.Users.Core.Domain.Services.Users;
using VoiceMod.Users.Core.Dtos;
using VoiceMod.Users.Core.Handlers;
using VoiceMod.Users.Core.Messages.Commands;
using VoiceMod.Users.Core.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using VoiceMod.Users.Api.Swagger;

namespace VoiceMod.Users.Api
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddControllers().AddNewtonsoftJson(); ;

            // Configure EF
            services.AddEFConfiguration(Configuration);

            // We add all dependencies related to dispatchers
            services.AddDispatchers();

            // Command Handlers
            services.AddScoped<ICommandHandler<CreateUser, UserDto>, CreateUserHandler>();
            services.AddScoped<ICommandHandler<UpdateUser, UserDto>, UpdateUserHandler>();
            services.AddScoped<ICommandHandler<DeleteUser>, DeleteUserHandler>();
            services.AddScoped<ICommandHandler<AuthenticateUser, UserDto>, AuthenticateUserHandler>();

            // QueryHandlers
            services.AddScoped<IQueryHandler<GetUser, UserDto>, GetUserHandler>();

            services.AddScoped<CheckEmailAvailability>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VoiceMod Users API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Manuel Berenguer Valero",
                        Email = "manuel.berenguer.valero@gmail.com"
                    }
                });

                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {                    
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http
                });

                // add auth header for [Authorize] endpoints
                c.OperationFilter<AddAuthHeaderOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Users API V1");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
