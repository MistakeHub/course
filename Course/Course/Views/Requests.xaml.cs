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

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class Requests : Window
    {
        private ViewModelRequest _viewModelRequest;
        public Requests(string address, string surname)
        {

            
            InitializeComponent();
            
            _viewModelRequest=new ViewModelRequest(address, surname);
            DataContext = _viewModelRequest;
        }
    }
}
