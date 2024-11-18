using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using presenter.ViewModels;
using presenter.Services;
using System.Windows;
using presenter.Views;

namespace presenter
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
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<MediaExplorerViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<PlaylistViewModel>();
                services.AddSingleton<PlaylistView>();
                //services.AddSingleton<Configuration>(new Configuration() { DbConnectionString = @"Data Source=C:\Users\Caleb\Desktop\song_manager\Songs.db" });
                services.AddDbContext<SongContext>(options => {
                    options.UseSqlite(@"Data Source=Songs.db");
                    options.UseLazyLoadingProxies();
                });
            });
    }

}
