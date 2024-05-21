using System.Windows;

namespace DesafioWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Shutdown();
        }
    }

}
