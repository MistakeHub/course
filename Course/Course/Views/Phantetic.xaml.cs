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
using MVVM_Example_04;

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class ResultReport : Window
    {
        // ViewModel для окна Phantetic
        public ViewModelReport VmRep;
        public ResultReport(ObservableCollection<Result> _results)
        {
            InitializeComponent();
            
            VmRep = new ViewModelReport(_results,  new XmlSereliazable(),
            new DefaultDialogService());
            DataContext = VmRep;

        }
    }
}
