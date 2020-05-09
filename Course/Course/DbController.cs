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
            _db = new ModelMailContainer();
        }

        public int AddSub(SubscriberDB sub)
        {
            _db.SubscriberDBSet.Add(sub);
           

            return 1; 
        } 

        public int AddPostMan(PostManDB postman)
        {
            _db.PostManDBSet.Add(postman);
         

            return 1; // количество добавленных записей
        } 

        public int AddSubEdition(SubEditionDB sbe)
        {
            _db.SubEditionDBSet.Add(sbe);
           

            return 1; 
        } 

        public int AddRegion(RegionDB region)
        {
            _db.RegionDBSet.Add(region);
          

            return 1; 
        } 

        public int AddPostalOffice(PostalOfficeDB posof)
        {
            _db.PostalOfficeDBSet.Add(posof);
           

            return 1; 
        }


        public int RemoveSub(SubscriberDB sub)
        {
            _db.SubscriberDBSet.Remove(sub);
          

            return 1;
        }

        

        public int RemoveSubEdition(SubEditionDB sbe)
        {
            _db.SubEditionDBSet.Remove(sbe);
           

            return 1;
        }

        public int RemoveRegion(RegionDB region)
        {
            _db.RegionDBSet.Remove(region);
           

            return 1;
        }

        public int RemovePostalOffice(PostalOfficeDB posof)
        {
            _db.PostalOfficeDBSet.Remove(posof);
            _db.SaveChanges();

            return 1;
        }



        public IList GetSubscriber() => _db
            .SubscriberDBSet.Select(c => new
            {
                c.Id,
                c.SubEditionDB,
                c.Address,
                
                
            }).ToList();

        public IList GetSubEdition() => _db
            .SubEditionDBSet.Select(e => new
            {
                e.Id,

            }).ToList();

        // Получить менеджеров, наследников класса Employee
        // обратите внимание на метод OfType
        public IList GetPostMant() => _db
            .PostManDBSet
            .Select(m => new
            {
                m.Id,

            }).ToList();

        public IList GetPostalOffi =>
            _db.PostalOfficeDBSet.Select(o => new {o.RegionDB, o.SubscriberDB, o.PostManDB}).ToList();

        public IList GetRegion() => _db.RegionDBSet.Select(r => new {r.TitleReg, r.SubscriberDB, r.PostManDB}).ToList();
        // Поиск города по названию в коллекции/таблице городов

        public void FihdPostmane(string Address)
        {
            _db.RegionDBSet.Where(c => c.SubscriberDB.ToList().Exists(a => a.Address == Address))
                .Select(p => new {p.PostManDB.Surname});
        }

        public IList FindMagazine(string Surname) => _db.SubscriberDBSet.Where(s => s.SurnameNpSub == Surname)
                .Select(p => new {p.SubEditionDB}).ToList();

        public IList NumberOfPostmans()=> _db.PostalOfficeDBSet.GroupBy(p => p.PostManDB).Select(p => new {numberofpostmans = p.Count()}).ToList();

        public IList AvgDate()
        => _db.SubscriberDBSet.GroupBy( p => p.SubEditionDB).Select(p => new {AveTerm = p.Average(a => a.Term)}).ToList();




        public IList NumberOfSubEdition() => _db.PostalOfficeDBSet.GroupBy(p => p.SubEditionDB).Select(p => new { numberofsubEdition = p.Count() }).ToList();




       
    } // class DbController
}

