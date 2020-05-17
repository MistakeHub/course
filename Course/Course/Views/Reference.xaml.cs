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
    /// Логика взаимодействия для Reference.xaml
    /// </summary>
    public partial class Reference : Window
    {
        // ViewModel для окна Reference
        public ViewModelReference _vmref;
        public Reference(int countbooks, int countjurnal, int countsub)
        {
            
            InitializeComponent();
            // Заполение Данными для VM
            _vmref = new ViewModelReference();
            _vmref.CountBooks = countbooks;
            _vmref.CountJurnal = countjurnal;
            _vmref.CountSubs = countsub;
            DataContext = _vmref;
        }
    }
}
