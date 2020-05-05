using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    //Работа с Почтальоном
    class PostMan
    {
        //ФИО Почтальона
        private string _surnameNPPost;

        public string SurnameNPPost
        {
            get { return _surnameNPPost; }
            set { 
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат Имени, Отчества, Фамилии ");
                _surnameNPPost = value;
                }
        } 
        //Участок, Участки,  Обслуживаемые Почтальоном
        public List<Region> Regions { get; set; }
        //Конструктор с параметрами 
        public PostMan(string surname, List<Region> regions)
        {
            _surnameNPPost = surname;
            Regions = regions;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
