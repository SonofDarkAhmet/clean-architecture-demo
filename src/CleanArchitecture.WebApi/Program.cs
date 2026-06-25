//using System.Runtime.ConstrainedExecution;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.WebApi.Middleware;
using CleanArchitecture.WebApi.OptionsSetup;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Infrastructure.Authentication;

using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CleanArchitecture.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<ICarService, CarService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IMailService, MailService>();
        builder.Services.AddScoped<IRoleService, RoleService>();

        builder.Services.AddScoped<IUserRoleService, UserRoleService>();

        builder.Services.AddTransient<ExceptionMiddleware>();
        builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<AppDbContext>());
        builder.Services.AddScoped<ICarRepository, CarRepository>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        builder.Services.AddScoped<IJwtProvider, JwtProvider>();

        builder.Services.ConfigureOptions<JwtOptionsSetup>();
        builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
        builder.Services.AddAuthentication().AddJwtBearer();
        builder.Services.AddAuthorization();

        builder.Services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);

        string connectionString = builder.Configuration.GetConnectionString("SqlServer");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddIdentity<User, Role>(
            options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireUppercase = false;
            }
        ).AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

        builder.Services.AddMediatR(cfr => cfr.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly));

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddValidatorsFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly);

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "Enter JWT Bearer token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            };

            options.AddSecurityDefinition("Bearer", securityScheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddlewareExtensions();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
