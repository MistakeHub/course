﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для LogInForm.xaml
    /// </summary>
    public partial class LogInForm : Window
    {
        private LoginModelView _LoginModel;
        public LogInForm()
        {
            
            InitializeComponent();
            _LoginModel=new LoginModelView();
            DataContext = _LoginModel;
        }
    }
}