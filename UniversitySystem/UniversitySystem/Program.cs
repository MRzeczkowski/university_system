using UniversitySystem.Models;

namespace UniversitySystem;

public static class Program
{
    public static void Main(string[] args)
    {
        var app = CreateWebHostBuilder(args).Build();

        var scope = app.Services.CreateScope();
        
        SampleData.Initialize(scope.ServiceProvider);

        app.Run();
    }

    private static IHostBuilder CreateWebHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}