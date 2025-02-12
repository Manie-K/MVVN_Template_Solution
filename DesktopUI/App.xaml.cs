using System.Configuration;
using System.Data;
using System.Windows;
using DesktopUI.Core;
using DesktopUI.MVVN.Viewmodel;
using DesktopUI.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow 
            { 
                DataContext = provider.GetRequiredService<MainViewModel>() 
            });

            //Viewmodels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<SettingsViewModel>();
        
            //Interfaces
            services.AddSingleton<INavigationService, NavigationService>();

            //Navigation factory
            services.AddSingleton<Func<Type,ViewModelBase>>(provider => type =>
            {
                return (ViewModelBase)provider.GetRequiredService(type);
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            
            base.OnStartup(e);
        }
    }

}
