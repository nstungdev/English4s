using English4s.Presentation.Generic;
using English4s.Presentation.ViewModels;
using English4s.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace English4s.Presentation
{
    public static class DependencyInjection
    {
        public static void AddPresentationServices(this IServiceCollection services)
        {
            services.AddSingleton<Func<Type, BaseViewModel>>(provider => viewModelType => (BaseViewModel)provider.GetRequiredService(viewModelType));
            services.AddSingleton(provider => new MainView
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            // view models
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<DashBoardViewModel>();
        }
    }
}
