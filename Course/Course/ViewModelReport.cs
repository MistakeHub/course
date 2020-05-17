using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class ViewModelReport
    {
        //VM Отчёта
        // Коолекция Элементов Отчёта
        public ObservableCollection<Result> Results { get; set; }

        public string SelectedSubEditionsTitles { get; set; }

        public string SelectedSubscribersSurnames { get; set; }
        // Конструктор с парамметрами 
        public ViewModelReport(ObservableCollection<Result> _results)
        {

            Results = _results;

        }
    }
}
