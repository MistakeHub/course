using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Model;

namespace Course
{
    class ViewModelRequest
    {
        // Коллекции для заполения запросами
        public IList PostalOfficeRequest { get; set; }
        public IList RequestFindPostman { get; set; }
        public IList RequestNumberOfSubEdition { get; set; }
        public IList RequestAVGDate { get; set; }
        public IList RequestFindMagazine { get; set; }
        public IList RequestMaxSub { get; set; }
        public IList RequestNumberOfPostmans { get; set; }

        private DbController _db;
        public ViewModelRequest(string address, string surname)
        {
            // Контроллер с работами с запросами
            _db = new DbController();
            // Заполение Коллекции запросами
            
            //Запрос Отделов почты
            PostalOfficeRequest =new ObservableCollection<PostalOfficeDB>();
            PostalOfficeRequest = _db.GetPostalOffice();
            //Запрос 1
            RequestFindPostman = new ObservableCollection<PostalOfficeDB>();
            RequestFindPostman = _db.FindPostman(address);
            //Запрос 2
            RequestNumberOfSubEdition = new ObservableCollection<PostalOfficeDB>();
            RequestNumberOfSubEdition = _db.NumberOfSubEdition();
            //Запрос 3
            RequestAVGDate = new ObservableCollection<PostalOfficeDB>();
            RequestAVGDate = _db.AvgDate();
            //Запрос 4
            RequestFindMagazine = new ObservableCollection<PostalOfficeDB>();
            RequestFindMagazine = _db.FindMagazine(surname);
            //Запрос 5
            RequestMaxSub = new ObservableCollection<PostalOfficeDB>();
            RequestMaxSub = _db.MaxSub();
            //Запрос 6
            RequestNumberOfPostmans = new ObservableCollection<PostalOfficeDB>();
            RequestNumberOfPostmans = _db.NumberOfPostmans();

        }

    }
}
