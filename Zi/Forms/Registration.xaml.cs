using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Zi.Entity;
using Zi.Models;

namespace Zi.Forms
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            DataContext = new RegistrationModel();
            ((RegistrationModel)DataContext).ActualRoles = new ObservableCollection<Role>(Service.GetActualRoles());
            ((RegistrationModel)DataContext).SelectedRole = ((RegistrationModel)DataContext).ActualRoles.First();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void registrationBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
