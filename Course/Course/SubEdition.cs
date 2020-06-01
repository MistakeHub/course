using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [DataContract]
    //Работа с Подписным изданием 
    public class SubEdition
    {
       

        //индекс подписного издания
        private static int _index = 0;
        [DataMember]
        public static int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        //Название Подписного издания
        private string _title;
        [DataMember]
        public string Title
        {
            get { return _title;}
            set { if(string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат строки"); _title = value; }
        }

        //Цена подисного издания
        private double _price;
        [DataMember]
        public double Price
        {
            get { return _price;}
            set {if(value <0 ) throw new Exception("Ценна не может быть отрицательной!");
                _price = value;
            }
        }
        //Конструктор с параметрами 
        public SubEdition(string title, double price)
        {
            _title = title;
            _price = price;
            Index++;


        }
        //Конструктор  Без параметров 
        public SubEdition() : this("Название", 1) { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
