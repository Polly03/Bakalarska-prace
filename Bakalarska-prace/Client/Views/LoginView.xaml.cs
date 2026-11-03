using Bakalarska_prace.Services;
using Shared.Models.Auth;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using static Shared.Constants.Constants;

namespace Bakalarska_prace.Views
{

    public partial class LoginView : UserControl
    {
        public string LoginText
        {
            get => txtBox_Login.Text;
            set => txtBox_Login.Text = value;
        }
        public string PasswordText
        {
            get => txtBox_Password.Text;
            set => txtBox_Password.Text = value;
        }

        public LoginView()
        {
            InitializeComponent();
        }
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            AuthService authService = new AuthService();
            LoginResponseDto? responseDto = await authService.LoginAsync(LoginText, PasswordText);

            if (responseDto != null)
            {
                string token = responseDto.Token;
                string user = responseDto.Username;
                DateTime expires = responseDto.ExpiresAt;

                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.Main.Content = new MainMenuView();
                }
            }
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Main.Content = new RegisterView();
            }
        }
    }
}
