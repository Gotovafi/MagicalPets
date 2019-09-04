using PetApp.Core.ApplicationService;
using PetApp.Core.ApplicationService.Services;
using PetApp.Core.DomaniService;
using PetApp.Infrastructure.Static.Data;
//using PetApp.Core.Infrastructure.Static.Data;
using PetApp.Infrastructure.Static.Data;
using Microsoft.Extensions.DependencyInjection;
namespace ConsoleAppOfPats
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IMirrorImage, MirrorImage>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IMirrorImage>();
            printer.StartUI();

        }
    }
}
