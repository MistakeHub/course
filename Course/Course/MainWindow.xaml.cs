﻿using System;
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


        public MainWindow()
        {
     
            InitializeComponent();
            
          LogInForm log=new LogInForm();
          log.Show();
         _postalOfficeViewModel=new PostalOfficeViewModel("отдел 1");
         DataContext = _postalOfficeViewModel;


        
         // Инициализация цветом выделения
      
        }

        

    }
}
