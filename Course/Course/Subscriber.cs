using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    // Работа с подписчиками издания
    [Serializable]
    public class Subscriber
    {
        //Фамилия, имя и отчество подписчика
        [NonSerialized]
        private string _surnameNP;
        
        public string SurnameNP
        {
            get { return _surnameNP; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат Имени, Отчества, Фамилии ");
                _surnameNP = value;
            }

        }

        //Домашний Адресс Подписчика

        [NonSerialized]
        private string _homeaddress;

      
        public string HomeAddress
        {
            get { return _homeaddress; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат адресса ");
                _homeaddress = value;
            }
        }

        //Индексы Подписного издания
      
        public ObservableCollection<SubEdition>   IndexEdition { get  ; set; }


        //Дата Оформления Подписки
      
        public DateTime DateStartSub { get; set; }
        //Дата окончание Подписки
      
        public DateTime DateEndSub
        {
          get; set;  
        }
        //Срок Подписки
        [NonSerialized]
        public Double _term;
        public Double Term
        {
            get  ;
            set;
        }

        //Конструктор с параметрами
        public Subscriber(string surname, string homeaddress, DateTime datestart, DateTime end)
        {
            
            _surnameNP = surname;
            _homeaddress = homeaddress;
            DateStartSub = datestart;
            DateEndSub = end;



            IndexEdition = new ObservableCollection<SubEdition> { };
            

        }

        //Конструктор  Без параметров 
        public Subscriber():this("ФИО", "Адресс", new DateTime(),new DateTime() ) { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}



