using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using presenter.ViewModel;
using presenter.Services;
using System.Windows;
using presenter.View.UserControls;

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
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<MediaExplorerViewModel>();
                services.AddSingleton<PlaylistView>();
                services.AddSingleton<PlaylistViewModel>();
                services.AddDbContext<SongContext>(options => options.UseSqlite(@"Data Source=C:\Users\Caleb\Desktop\song_manager\Songs.db"));
            });
    }

}
