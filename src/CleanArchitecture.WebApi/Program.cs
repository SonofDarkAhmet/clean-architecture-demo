using CleanArchitecture.WebApi.Middleware;
using CleanArchitecture.WebApi.Configurations.Abstractions;

namespace CleanArchitecture.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.InstallServices(builder.Configuration, builder.Host, typeof(IServiceInstaller).Assembly);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();

        app.UseMiddlewareExtensions();

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
