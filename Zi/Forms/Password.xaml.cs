using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zi.Context;
using Zi.Models;

namespace Zi.Forms
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public Password(string login = null, string password = null)
        {
            InitializeComponent();
            DataContext = new LoginModel { Login = login, Password = password, RememberMe = (login != null && password != null) };
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var model = (LoginModel)DataContext;
            try
            {
                var result = ((App)App.Current).Login(model.Login, model.Password);
                if (result)
                {
                    saveToRegestry();
                    DialogResult = true;
                    Close();
                }
                else
                    MessageBox.Show("Не удалось осуществить вход в систему с указанным логином и паролем.", "Zi: Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception err)
            {
                MessageBox.Show("Не удается подключиться к серверу.", "Zi: Ошибка соединения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void saveToRegestry()
        {
            var model = (LoginModel)DataContext;
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Zi", "Login", model.Login);
            if (model.RememberMe)
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Zi", "Token", Verify.Encrypt(model.Password, model.Login));
        }
    }
}
