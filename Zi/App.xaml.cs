using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Zi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        internal static Service Service;
        internal NotifyIcon notifyIcon;
        internal MainWindow window;
        private Dictionary<string, System.Drawing.Icon> iconSet;
        public App()
        {
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
            var login = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Zi", "Login", null);
            var password = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Zi", "Token", null);
            if (login == null) //Пользователь не заходил в систему с этого компьютера
            {
                var regForm = new Forms.Registration();
                if (regForm.ShowDialog() == true)
                    OpenLoginForm();
                else
                    Current.Shutdown();
            }
            else
            {
                //осуществить попытку входа, если не удалось показать форму логина
                if (password == null)
                    OpenLoginForm(login.ToString());
                else
                {
                    if (!((App)Current).Login(login.ToString(), Context.Verify.Decrypt(password.ToString(), login.ToString())))
                        OpenLoginForm(login.ToString(), Context.Verify.Decrypt(password.ToString(), login.ToString()));
                    else
                        loginSuccess();
                }
            }
        }
        protected override void OnExit(ExitEventArgs e)
        {
            if (notifyIcon != null)
                notifyIcon.Dispose();
            if (Service != null)
                Service.Exit();
            base.OnExit(e);
        }

        public bool Login(string login, string password)
        {
            var service = Service.Login(login, password);
            if (service != null) //Логин прошел успешно
            {
                Service = service;
                return true;
            }
            return false;
        }

        private void OpenLoginForm(string login = null, string password = null)
        {

            var loginFrm = new Forms.Password(login, password);
            if (loginFrm.ShowDialog() == true)
                loginSuccess();
            else
                Current.Shutdown();
        }

        private void setIcons()
        {
            iconSet = new Dictionary<string, System.Drawing.Icon>();

            foreach (var icn in new[] { "icon" })
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = $"Zi.Icons.{icn}.ico";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    var icon = new System.Drawing.Icon(stream);
                    iconSet.Add(icn, icon);
                }
            }


        }

        private void loginSuccess()
        {
            setIcons();
            notifyIcon = new NotifyIcon();
            notifyIcon.Click += NotifyIcon_Click;
            notifyIcon.Icon = iconSet["icon"];
            notifyIcon.Visible = true;
            notifyIcon.Text = "Zi версия 0.9 alpha";

            var menu = new ContextMenu();
            var itm1 = new MenuItem
            {
                Index = 0,
                Text = "Задачи"
            };
            itm1.Click += Task_Click;

            var itm2 = new MenuItem
            {
                Index = 1,
                Text = "Сообщения"
            };
            itm2.Click += Messages_Click;

            var itm3 = new MenuItem
            {
                Index = 2,
                Text = "Уведомления"
            };
            itm3.Click += SilentMode_Click;

            var itm4 = new MenuItem
            {
                Index = 3,
                Text = "Сменить пользователя"
            };
            itm4.Click += ChangeUser_Click; ;

            var itm5 = new MenuItem
            {
                Index = 4,
                Text = "Выход"
            };
            itm5.Click += Exit_Click;

            menu.MenuItems.AddRange(new[] { itm1, itm2, itm3, itm4, new MenuItem { Text = "-" }, itm5 });

            notifyIcon.ContextMenu = menu;

            window = new MainWindow();
            window.Show();
        }

        private void ChangeUser_Click(object sender, EventArgs e)
        {
            Service.Exit();
            Service = null;
            window.Close();
            notifyIcon.Dispose();
            var login = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Zi", "Login", null);
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Zi", true))
            {
                if (key != null)
                    key.DeleteValue("Token");
            }

            OpenLoginForm(login.ToString());

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Current.Shutdown();
        }

        private void SilentMode_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Messages_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Task_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            var evt = e as MouseEventArgs;
            if (evt == null) return;
            if (evt.Button == MouseButtons.Left) //активировать окно
            {
                if (window.IsVisible)
                    window.Hide();
                else
                    window.Show();
            }
            else if (evt.Button == MouseButtons.Right) //показать меню
            {

            }

        }
    }
}
