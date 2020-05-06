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
        public List<SubEdition>   IndexEdition { get; set; }

      
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
        //Срок Подписки
        public Double Term
        {
            get => DateStartSub.Day - DateEndSub.Day;
        }

        //Конструктор с параметрами
        public Subscriber(string surname, string homeaddress,SubEdition sub, DateTime stadt, DateTime end)
        {
            _dateStartSub = stadt;
            _dateEndSub = end;
            _surnameNP = SurnameNP;
            _homeaddress = homeaddress;
            IndexEdition.Add(sub);


        }

        //Конструктор  Без параметров 
        public Subscriber():this("ФИО", "Адресс", new SubEdition(null,0), new DateTime(0), new DateTime(0)) { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}



