using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations.Model;
using System.Diagnostics.Eventing.Reader;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Threading;
using Course.Model;

namespace Course
{
    class LoginModelView
    {
        private string _username;

        public string UserName
        {
            get => _username;
            set
            {
                _username = value;

                OnPropertyChanged();
            }

        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value; OnPropertyChanged();
            }

        }
        public ObservableCollection<User> Users;

        public LoginModelView()
        {

            _username = "Рофл";
            _password = "123123";

        }

        private RelayCommand _login ;
        public RelayCommand Login
        {
            get
            {
                return _login ??
                       (_login = new RelayCommand(obj =>
                           {
                               
                              
                               
                                   if(UserName == "Здарова" && Password=="123123")
                                       Application.Current.Shutdown();
                                   
                               


                           }
                       ));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        } // OnPropertyChanged

    }
}
