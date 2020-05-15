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
        private ModelMailContainer _db;

        public DbController()
        {
            _db = new ModelMailContainer();
        }

        public int AddSub(SubscriberDB sub)
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

            return 1; 
        } 

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
                
                c.SubEditionDB,
                c.Address,
                c.SurnameNpSub
                
                
            }).ToList();

        public IList GetSubEdition() => _db
            .SubEditionDBSet.Select(e => new
            {
                e.Id,
                e.Price,
                e.Title

            }).ToList();

      
        public IList GetPostMant() => _db
            .PostManDBSet
            .Select(m => new
            {
                m.Id,
                m.Surname,
               Regions= m.RegionDB,
                
                

            }).ToList();

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

        public IList GetRegion() => _db.RegionDBSet.Select( r => new {r.TitleReg,  r.SubscriberDB, Postman= r.PostManDB.Surname}).ToList();
        // Поиск города по названию в коллекции/таблице городов

        public IList FihdPostmane(string Address)
        {
            return _db.PostalOfficeDBSet.Where(p => p.SubscriberDB.Address == Address).Select(c => new {c.PostManDB.Surname})
                .ToList();

        }

        public IList FindMagazine(string Surname) => _db.PostalOfficeDBSet
            .Where(p => p.SubscriberDB.SurnameNpSub == Surname).Select(c => new {c.SubEditionDB.Title, c.SubscriberDB.SurnameNpSub}).ToList();

        public IList NumberOfPostmans()=> _db.PostManDBSet.GroupBy(p => p.Surname).Select(p => new { SurnamePost= p.Key, key=p.Count() }).ToList();

        public IList AvgDate()
        => _db.PostalOfficeDBSet.GroupBy( p => p.SubscriberDB.Term).Select(d => new {AveTerm = d.Average(c=>c.SubscriberDB.Term)}).ToList();


        public IList MaxSub() => _db.PostalOfficeDBSet.Where(d=> d.SubEditionDB.Title !="0").GroupBy( d=> d.RegionDB.TitleReg ).Select(p => new {Post=p.Key, Posds=p.Count()}).ToList();

        public IList NumberOfSubEdition() => _db.PostalOfficeDBSet.GroupBy(p => p.SubEditionDB.Title).Select(p => new {  numberofsubEdition = p.Count(), Books=p.Key  }).ToList();




       
    } // class DbController
}

