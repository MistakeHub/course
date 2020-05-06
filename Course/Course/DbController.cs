using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Course.Model;

namespace Course
{
    // Контроллер для Работы с Базами данных 
    class DbController
    {
        private ModelMailContainer _db;

        public DbController()
        {
            _db=new ModelMailContainer();
        }
        public IList GetSubscriber() => _db
            .SubscriberDBSet.Select(c => new {
                c.Id,
               c.Address
            }).ToList();

        public IList GetSubEdition() => _db
            .SubEditionDBSet.Select(e => new {
                e.Id,
               
            }).ToList();

        // Получить менеджеров, наследников класса Employee
        // обратите внимание на метод OfType
        public IList GetPostMant() => _db
            .PostManDBSet
            .Select(m => new {
                m.Id,
              
            }).ToList();

        public IList GetRegion() => _db.RegionDBSet.Select(r=> new{ r.TitleReg ,r.SubscriberDB ,r.PostManDB   }).ToList();
        // Поиск города по названию в коллекции/таблице городов

        public void FihdPostmane(string Address)
        {
            _db.RegionDBSet.Where(c => c.SubscriberDB.ToList().Exists(a => a.Address == Address))
                .Select(p => new {p.PostManDB.Surname});
        }

        public SubscriberDB FindMagazine(string Surname)
        {

            _db.SubscriberDBSet.Where(s=> s.SurnameNpSub == Surname).Select(p=> new { p.SubEditionDB = p.SubEditionDB. })

        }




        // Средний возраст по городам
        public IList AvgAgeByCity() => _db.Employees
            .GroupBy(byAge => byAge.City.Name)
            .Select(byAge => new {
                City = byAge.Key,
                AvgAge = byAge.Average(e => e.Age),
                Amount = byAge.Count()
            }).ToList();
    } // class DbController
}

