using DesafioWPF.Data;
using DesafioWPF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Windows;
namespace DesafioWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
#if DEBUG
			serviceCollection.AddBlazorWebViewDeveloperTools();
#endif
            serviceCollection.AddSingleton<WeatherForecastService>();
            serviceCollection.AddTransient<IApplicationRunner, WindowsApplicationRunner>();
            serviceCollection.AddDbContext<AppDbContext>(x => { x.UseInMemoryDatabase("app"); });
            serviceCollection.AddMudServices();
            serviceCollection.AddDevExpressBlazor(configure => configure.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5);
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}