using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Course.Model;

namespace Course
{
    [DataContract]
    //Работа с Почтальоном
    public  class PostMan
    {
        //ФИО Почтальона
        private string _surnameNPPost;
        [DataMember]
        public string SurnameNPPost
        {
            get { return _surnameNPPost; }
            set { 
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат Имени, Отчества, Фамилии ");
                _surnameNPPost = value;
                }
        }
        //Участок, Участки,  Обслуживаемые Почтальоном
        [DataMember]
        public List<Region> Regions { get; set; }
        //Конструктор с параметрами 
        public PostMan(string surname)
        {
            _surnameNPPost = surname;
            Regions = new List<Region>();

        }
        // Конструктор по умолчанию
        public PostMan() : this("Имя") { }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
