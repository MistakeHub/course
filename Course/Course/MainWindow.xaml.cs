using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Course.Model;

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PostalOfficeViewModel _postalOfficeViewModel;
        private LoginModelView _logindModelView;

        public MainWindow()
        {
          
           
          
            
 
                InitializeComponent();


            LogInForm log=new LogInForm();
            _logindModelView=new LoginModelView();
            _postalOfficeViewModel = new PostalOfficeViewModel("отдел 1");
            _logindModelView.Users = _postalOfficeViewModel.Users;
            log.DataContext = _logindModelView;
            log.ShowDialog();
            _postalOfficeViewModel.UsernameLog = _logindModelView.UserName;
            _postalOfficeViewModel.PasswordLog = _logindModelView.Password;
            if (_postalOfficeViewModel.UsernameLog == "qwerty123123")
                _postalOfficeViewModel.Names = "Авторизован как:Заведующий почтового отдела";
            else if (_postalOfficeViewModel.UsernameLog == "rofl")
                _postalOfficeViewModel.Names = "Авторизован как:Оператор почтового отдела";
            DataContext = _postalOfficeViewModel;
           



        }

        

    }
}
