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
        public IList sadsada { get; set; }
        public IList sadsadad { get; set; }
        public IList sadsadada { get; set; }
        public IList sadsadadad { get; set; }
        public IList sadsadadada { get; set; }
        public IList sadsadadadad { get; set; }
        public IList sadsadadadada { get; set; }

        private DbController _db;
        public ViewModelRequest()
        {

            _db = new DbController();
            sadsada =new ObservableCollection<PostalOfficeDB>();
            sadsada = _db.GetPostalOffice();
            sadsadad = new ObservableCollection<PostalOfficeDB>();
            sadsadad = _db.FihdPostmane("ул. Поселковая дор, дом 25, квартира 316");
            sadsadada=new ObservableCollection<PostalOfficeDB>();
            sadsadada = _db.NumberOfSubEdition();
            sadsadadad = new ObservableCollection<PostalOfficeDB>();
            sadsadadad = _db.AvgDate();
            sadsadadada = new ObservableCollection<PostalOfficeDB>();
            sadsadadada = _db.FindMagazine("Л.Т Эльдарович");
            sadsadadadad = new ObservableCollection<PostalOfficeDB>();
            sadsadadadad = _db.MaxSub();
            sadsadadadada = new ObservableCollection<PostalOfficeDB>();
            sadsadadadada = _db.NumberOfPostmans();

        }

    }
}
