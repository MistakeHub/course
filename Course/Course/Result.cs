using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Course
{
    [Serializable]
  public class Result
    {
        // Работа С отчётом
        // Имя Почтальона

   
        public string SurnamePostmanst { get; set; }
       // Кол-во участков, Обслуживающим почтальонов
       public int CountPostmansRegions { get; set; }
       // Количество Изданий
       public int AnySubEdition { get; set; }
       // Общий срок подписков
       public  double TermSubscribers { get; set; }
       // Адресса Подписчиков
       public List<string> AddressesSubscribers { get; set; }
       // Название Изданий
        public List<string> SubeditionsTitles { get ; set; }

    
        // Конструктор с парамметрами
        public Result(string surnamePostmanst, int countSurnamePostmanst, int  anySubedition, double termSubscribers )
        {
            SurnamePostmanst = surnamePostmanst;
            CountPostmansRegions = countSurnamePostmanst;
            AnySubEdition = anySubedition;
            AddressesSubscribers = new List<string>();
            TermSubscribers=termSubscribers;
            SubeditionsTitles=new List<string>();
        }
        // конструктор по умолчанию
        public Result():this("0", 0, 0,0 ) { }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
