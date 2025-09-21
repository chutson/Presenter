using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Presenter.Services;
using Presenter.WPF.Views;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Messaging;
using Presenter.WPF.ViewModels;

namespace Presenter.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            host.Start();
            App app = new();

            app.InitializeComponent();
            app.MainWindow = host.Services.GetRequiredService<MainWindow>();
            app.MainWindow.Visibility = Visibility.Visible;
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IMessenger, WeakReferenceMessenger>();
                services.AddSingleton<MediaExplorerViewModel>();
                services.AddSingleton<PlaylistViewModel>();
                services.AddSingleton<PlaylistView>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddDbContext<SongContext>(options => {
                    options.UseSqlite(LoadSettings().DbConnectionString);
                    options.UseLazyLoadingProxies();
                });
            });

        private static PresenterSettings LoadSettings()
        {
            return new PresenterSettings
            {
                DbConnectionString = System.Configuration.ConfigurationManager.AppSettings["DbConnectionString"] ?? "Data Source=Songs.db"
            };
        }
    }

    class PresenterSettings
    {
        public string DbConnectionString { get; set; } = string.Empty;
    }
}
