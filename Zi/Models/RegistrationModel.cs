using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.Entity;

namespace Zi.Models
{
    internal class RegistrationModel : INotifyPropertyChanged
    {
        public ObservableCollection<Role> ActualRoles { get; set; }

        private Role selectedRole;
        public Role SelectedRole
        {
            get
            {
                return selectedRole;
            }
            set
            {
                selectedRole = value;
                Rise("SelectedRole");
            }
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        public string Email { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Rise(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
