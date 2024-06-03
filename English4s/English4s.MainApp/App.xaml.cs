using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using English4s.Presentation.Views;
using English4s.Presentation.ViewModels;

namespace English4s.MainApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? Host { get; private set; }
        private ServiceProvider? _serviceProvider = null;
        public App()
        {
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<MainView>(provider => new MainView
                    {
                        DataContext = provider.GetRequiredService<MainViewModel>()
                    });
                    services.AddSingleton<MainViewModel>();


                    _serviceProvider = services.BuildServiceProvider();
                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await Host!.StartAsync();
            var mainWindow = _serviceProvider?.GetRequiredService<MainView>();
            mainWindow?.Show();
            base.OnStartup(e);
        }
    }

}
