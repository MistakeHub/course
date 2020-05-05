using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    // Работа с подписчиками издания
    class Subscriber
    {
        //Фамилия, имя и отчество подписчика
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
        public SubEdition[]   IndexEdition { get; set; }

      
        //Дата Оформления Подписки
        private DateTime _dateStartSub;
        public DateTime DateStartSub
        {
            get { return _dateStartSub; }
            set { _dateStartSub = value; }
        }
        //Дата окончание Подписки
        private DateTime _dateEndSub;
        public DateTime DateEndSub
        {
            get { return _dateEndSub; }
            set { _dateEndSub = value; }
        }

        //Конструктор с параметрами
        public Subscriber(string surname, string homeaddress)
        {
            _surnameNP = SurnameNP;
            _homeaddress = homeaddress;
            

        }
        //Конструктор  Без параметров 
        public Subscriber():this("ФИО", "Адресс") { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}



