using System.Reflection;
using FluentValidation;
using GeneticDrill.WebApi.Apis.Users;
using GeneticDrill.WebApi.Core.DataAccess.Abstractions;
using GeneticDrill.WebApi.Core.Services.Abstractions;
using GeneticDrill.WebApi.Core.Services.Implementations;
using GeneticDrill.WebApi.Core.Services.Implementations.User;
using GeneticDrill.WebApi.Helpers;
using GeneticDrill.WebApi.Helpers.Extensions;

namespace GeneticDrill.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var configuration = builder.Configuration;
        // Add services to the container.
        services.AddAuthorization();

        // services.AddOptions<DapperConfiguration>()
        //     .Bind(configuration.GetSection(DapperConfiguration.SectionName))
        //     .ValidateDataAnnotations()
        //     .ValidateOnStart();

        services.AddSingleton(
            new DapperContext(configuration.GetSection("DapperConfiguration:ConnectionString").Value!));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserService, UserService>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.InitializeDatabase();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseAuthorization();

        app.MapUsersEndpoints();

        app.Run();
    }
}