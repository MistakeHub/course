using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Course.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace Course
{
    // Контроллер для Работы с Базами данных 
    class DbController
    {

        //Переменная модели для работы с БД
        private ModelMailContainer _db;

        public DbController()
        {
            _db = new ModelMailContainer();
        }

       
        // Добавление почтальона
        public int AddPostMan(PostManDB postman)
        {
            _db.PostManDBSet.Add(postman);
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return 1; // количество добавленных записей
        }
        // Добавление Издания
        public int AddSubEdition(SubEditionDB sbe)
        {  
             _db.SubEditionDBSet.Add(sbe);
             try
             {
                 _db.SaveChanges();
             }
             catch (DbEntityValidationException ex)
             {
                 foreach (var entityValidationErrors in ex.EntityValidationErrors)
                 {
                     foreach (var validationError in entityValidationErrors.ValidationErrors)
                     {
                         MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                     }
                 }
             }

             return 1; 
        }
        // Добавление Участка
        public int AddRegion(RegionDB region)
        {
            _db.RegionDBSet.Add(region);
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return 1; 
        }
        // Обновление PostalOfficeDbs базы данных
        public int UptadePostalOffice(PostalOfficeDB posof)
        {
            _db.PostalOfficeDBSet.AddOrUpdate(posof);

            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return 1;
        }

        // Добавление Отдела
        public int AddPostalOffice(PostalOfficeDB posof)
        {
            _db.PostalOfficeDBSet.Add(posof);
            
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return 1; 
        }
        // Добавление подписчиков
        public int AddSubscriber(SubscriberDB sub)
        {
            _db.SubscriberDBSet.Add(sub);
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            catch (OptimisticConcurrencyException)
            {
              
            
            }
            return 1;


        }

        // Удаление подписчиков
        public int RemoveSub(SubscriberDB sub)
        {
            _db.SubscriberDBSet.Remove(sub);
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return 1;
        }


        // Удаление Издания
        public int RemoveSubEdition(SubEditionDB sbe)
        {
            _db.SubEditionDBSet.Remove(sbe);
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return 1;
        }
        // Удаление Участка
        public int RemoveRegion(RegionDB region)
        {
            _db.RegionDBSet.Remove(region);
           

            return 1;
        }

        // Удаление Отдела
        public int RemovePostalOffice(PostalOfficeDB posof)
        {
            _db.PostalOfficeDBSet.Remove(posof);
            _db.SaveChanges();

            return 1;
        }
        // Удаление Почтальона
        public int RemovePostMan(PostManDB posof)
        {
            _db.PostManDBSet.Remove(posof);
            _db.SaveChanges();

            return 1;
        }


        // Поллучения Данных об Подписчиков
        public IList GetSubscriber() => _db
            .SubscriberDBSet.Select(c => new
            {
                
                c.SubEditionDB,
                c.Address,
                c.SurnameNpSub
                
                
            }).ToList();
        // Поллучения Данных об Изданиях
        public IList GetSubEdition() => _db
            .SubEditionDBSet.Select(e => new
            {
                e.Id,
                e.Price,
                e.Title

            }).ToList();

        // Поллучения Данных об Почтальонов
        public IList GetPostMant() => _db
            .PostManDBSet
            .Select(m => new
            {
                m.Id,
                m.Surname,
               Regions= m.RegionDB,
                
                

            }).ToList();
        // Поллучения Данных об Отделе
        public IList GetPostalOffice()
        {
         
           
              return _db.PostalOfficeDBSet.Where(p => p.SubscriberDB != null).Select(o => new
                {
                    Region = o.RegionDB.TitleReg,
                    Subscriber = o.SubscriberDB.SurnameNpSub,
                    Postman = o.PostManDB.Surname,
                    Subedition=o.SubEditionDB.Title
                }).ToList();
                
            


        }
        // Поллучения Данных об Участков
        public IList GetRegion() => _db.RegionDBSet.Select( r => new {r.TitleReg,  r.SubscriberDB, Postman= r.PostManDB.Surname}).ToList();
     
            // Запросы по заданию 
        public IList FindPostman(string Address)
        {
            return _db.PostalOfficeDBSet.Where(p => p.SubscriberDB.Address == Address).Select(c => new {c.PostManDB.Surname, c.SubscriberDB.Address})
                .ToList();

        }

        public IList FindMagazine(string Surname) => _db.PostalOfficeDBSet
            .Where(p => p.SubscriberDB.SurnameNpSub == Surname).Select(c => new {c.SubEditionDB.Title, c.SubscriberDB.SurnameNpSub}).ToList();

        public IList NumberOfPostmans()=> _db.PostManDBSet.GroupBy(p => p.Surname).Select(p => new { SurnamePost= p.Key, key=p.Count() }).ToList();

        public IList AvgDate()
        => _db.PostalOfficeDBSet.GroupBy( p => p.SubEditionDB.Title).Select(d => new {AveTerm = d.Average(p=>p.SubscriberDB.Term), Edition=d.Key}).ToList();


        public IList MaxSub() => _db.PostalOfficeDBSet.Where(d=> d.SubEditionDB.Title !="0").GroupBy( d=> d.RegionDB.TitleReg ).Select(p => new {Post=p.Key, Posds=p.Count()}).ToList();

        public IList NumberOfSubEdition() => _db.PostalOfficeDBSet.GroupBy(p => p.SubEditionDB.Title).Select(p => new {  numberofsubEdition = p.Count(), Books=p.Key  }).ToList();




       
    } // class DbController
}

