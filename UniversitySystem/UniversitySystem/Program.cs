using UniversitySystem.Seeding;

namespace UniversitySystem;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = CreateWebHostBuilder(args);

        var app = builder.Build();

        var scope = app.Services.CreateScope();

        DataSeeder.SeedRequiredData(scope.ServiceProvider);

#if DEBUG
        DataSeeder.SeedTestData(scope.ServiceProvider);
#endif

        app.Run();
    }

    private static IHostBuilder CreateWebHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}