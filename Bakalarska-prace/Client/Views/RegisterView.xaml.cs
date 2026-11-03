using System.Windows;
using System.Windows.Controls;

namespace Bakalarska_prace.Views
{
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void ReturnToLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Main.Content = new LoginView();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
