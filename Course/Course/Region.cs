using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [DataContract]
    //Работа с Участком
    public class Region
    {
        public  static int Max = 13;

        private static int idregion;
        public static int IDRegion { get => idregion++; set => idregion = value; }
        public int Id
        {
            get => IDRegion;
        }
        //Название Участка
        private string _titleReg;
        [DataMember]
        public string TitleReg
        {
            get { return _titleReg; }
            set {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат  названия ");
                _titleReg = value;
            }
        }
        // Почтальон Участка
        [DataMember]
        public PostMan Postman { get; set; }
        // Подписчики Участка
        [DataMember]
        public List<Subscriber> Subscribers { get; set; }
        //Конструктор с параметрами 
        public Region(string title)
        {
            _titleReg = title;
            Postman = null;
            Subscribers = new List<Subscriber>();

        }

       


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
