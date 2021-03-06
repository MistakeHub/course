﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using Course.Views;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using MVVM_Example_04;


namespace Course
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ViewModels для окна MainWindow
        private PostalOfficeViewModel _postalOfficeViewModel;
        private LoginModelView _logindModelView;

        public MainWindow()
        {
          
           
          
            
 
                InitializeComponent();

            // Окно логирования
            LogInForm log=new LogInForm();
           
            _logindModelView =new LoginModelView(new DefaultDialogService());
            _postalOfficeViewModel = new PostalOfficeViewModel("отдел 1", new DefaultDialogService(), 
                new XmlSereliazable());
            _logindModelView.Users = _postalOfficeViewModel.Users;
            log.DataContext = _logindModelView;
      
            log.ShowDialog();
            _postalOfficeViewModel.UsernameLog = _logindModelView.UserName;
            _postalOfficeViewModel.PasswordLog = _logindModelView.Password;
            // Проверка логина, для определения того, кто зашёл
            if (_postalOfficeViewModel.UsernameLog == "qwertyqwerty")
                _postalOfficeViewModel.Names = "Авторизован как:Заведующий почтового отдела";
            else if (_postalOfficeViewModel.UsernameLog == "Mag1824")
                _postalOfficeViewModel.Names = "Авторизован как:Оператор почтового отдела";
            DataContext = _postalOfficeViewModel;
          




        }
       


    }
}
