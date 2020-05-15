using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations.Model;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using Course.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Course
{
    public class PostalOfficeViewModel
    {
        public SubscriberDB _subscriberDb { get; set; }
        public SubEditionDB _subEditionDb { get; set; }
        public PostManDB _postManDb { get; set; }
        public RegionDB _regionDb { get; set; }
        public List<SubscriberDB> _subscriberDbs { get; set; }
        public List<SubEditionDB> _subEditionDbs { get; set; }
        public List<PostManDB> _postManDbs{ get; set; }
        public List<RegionDB> _regionDbs { get; set; }
        public PostalOfficeDB PostalOfficeDBnew { get; set; }
        public ObservableCollection<PostalOfficeDB> PostalOfficeDbs { get; set; }
        private DbController _db;
        private string _title;
        public PostalOfficeDB _selectePostalOfficeDb;
       public  IList sadsada { get; set; }
       public IList sadsadad { get; set; }



        public ObservableCollection<User> Users;
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат");
                _title = Title;
            }
        }

       
        public PostalOfficeDB SelectedPostOffice
        {
            get => _selectePostalOfficeDb;
            set
            {
                _selectePostalOfficeDb = value;
                OnPropertyChanged(); // "SelectedPhone"
                OnPropertyChanged("RemoveCommandEnabled");
            }
        } // SelectedPhone

        private Subscriber _selectedSub;
        public Subscriber SelectedSub
        {
            get => _selectedSub;
            set
            {
                _selectedSub = value;
                OnPropertyChanged(); // "SelectedPhone"
                OnPropertyChanged("RemoveCommandEnabled");
            }
        } // SelectedPhone

        

        private string _usernamelog;

        public string UsernameLog
        {
            get => _usernamelog;
            set
            {
                _usernamelog = value;

                OnPropertyChanged();
            }
        }
        private string _passwordLog;
        public string PasswordLog
        {
            get => _passwordLog;
            set
            {
                _passwordLog = value;

                OnPropertyChanged();
            }
        }

        private PostMan _selectedPostMan;
        public PostMan SelectedPostMan
        {
            get => _selectedPostMan;
            set
            {
                _selectedPostMan = value;
                OnPropertyChanged(); // "SelectedPhone"
                OnPropertyChanged("RemoveCommandEnabled");
            }
        } // SelectedPhone

      private string _names;

      public string Names
      {

          get => _names;
          set
          {
              _names= value;

              OnPropertyChanged();
          }

        }
        
  

        public SubEdition sb = new SubEdition("Комиксы ", 900);
     
        public ObservableCollection<PostMan> Postmans { get; set; }
        public ObservableCollection<Region> Regions { get; set; }
        public ObservableCollection<Subscriber> Subscribers { get; set; }
        public ObservableCollection<SubEdition> SubEditions { get; set; }
        public Dictionary<Receipt, Subscriber> SubRec { get; set; }
        public PostalOfficeDB postalOffice;
        private SubscriberDB sub;

        public PostalOfficeViewModel(string title)
        {

            
            
            _db =new DbController();
                _title = title;
                Postmans=new ObservableCollection<PostMan>();
                Regions = new ObservableCollection<Region>();
                SubEditions = new ObservableCollection<SubEdition>
                {

                    new SubEdition("Книга ", 3000),
                    new SubEdition("Журнал ", 2100),
                    new SubEdition("Газета ", 1000),
                    new SubEdition("Комиксы ", 900),


                };
                Regions = new ObservableCollection<Region>
                {

                    new Region("Участок 1" ),
                    new Region("Участок 2" ),


                };
                PostalOfficeDB postalOffice = new PostalOfficeDB();
                postalOffice.TitlePostal = "отдел1";
            _subEditionDbs =new List<SubEditionDB>();
                _subscriberDbs=new List<SubscriberDB>();
                _regionDbs=new List<RegionDB>();
                _postManDbs=new List<PostManDB>();
                PostalOfficeDbs=new ObservableCollection<PostalOfficeDB>();

            Subscribers = new ObservableCollection<Subscriber>
            {
                new Subscriber("З.Ш Михайловна","ул. Михайловский проезд, дом 71, квартира 439" , new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Б.С Валентинович","ул. Скобелевская, дом 34, квартира 371", new DateTime(1000,1,1),new DateTime(1000,1,1)),
                new Subscriber("Крымская.А Юрьевна","ул. Первомайский район тер, дом 26, квартира 19", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("П.М Данилович","ул. Сосновский лесопарк парк, дом 20, квартира 250", new DateTime(1000,1,1),new DateTime(1000,1,1)),
                new Subscriber("В.Т Евгеньевич","ул. Фадеева 2-й пер, дом 31, квартира 451", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Х.Й Ярославовна","ул. Комсомольская, дом 34, квартира 391", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Д.А Богданович","ул. Новосибирская, дом 53, квартира 492", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("С.Б Алексеевна","ул. Поселковая дор, дом 25, квартира 316", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("В.Ж Андреевна","ул. Белогорская 2-я, дом 72, квартира 385", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Б.И Алексеевна","ул. Дегунинская, дом 88, квартира 387", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Д.И Эльдарович","ул. Муринский 2-й пр-кт, дом 16, квартира 468", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("М.А Ярославович","ул. Всеволожский пер, дом 79, квартира 464", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Р.Л Михайлович","ул. Кунцевская, дом 21, квартира 20", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("П.А Вячеславович","ул. Люботинский пр-кт, дом 45, квартира 379", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("К.А Юрьевич","ул. Тракторный пер, дом 57, квартира 110", new DateTime(1000,1,1),new DateTime(1000,1,1)),
                new Subscriber("Х.Ж Георгиевна","ул. Краснопрудный М. туп, дом 26, квартира 212", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Ч.П Егорович","ул. Чернышевского пр-кт, дом 28, квартира 188", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Б.А Иосифовна","ул. Заячий пер, дом 80, квартира 172", new DateTime(1000,1,1),new DateTime(1000,1,1)),
                new Subscriber("Д.А Викторович","ул. Рашетова, дом 60, квартира 10", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Ф.А Федоровна","ул. Большая Озерная, дом 69, квартира 263", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Б.Х Артемовна","ул. Якиманка М., дом 65, квартира 62", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("О.Р Артемович","ул. Прибрежная, дом 4, квартира 289", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("А.Х Григорьевна","ул. Загребский б-р, дом 15, квартира 441", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Б.Г Григорьевна","ул. Пантелеевская, дом 29, квартира 134", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("С.Я Юрьевна","ул. Новоостаповская, дом 7, квартира 184", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Л.Т Эльдарович","ул. Сорокин пер, дом 12, квартира 38", new DateTime(1000,1,1),new DateTime(1000,1,1) ),


            };

            SubRec = new Dictionary<Receipt, Subscriber >();


            Postmans = new ObservableCollection<PostMan>
            {
                new PostMan{SurnameNPPost = "Горшков Эрик Авксентьевич"},
                new PostMan{SurnameNPPost = "Сергеев Гарри Георгиевич"},
                new PostMan{SurnameNPPost = "Сафонов Натан Данилович"},
                new PostMan{SurnameNPPost = "Орлов Леонард Олегович"},
                new PostMan{SurnameNPPost = "Калашников Модест Кимович"},
                new PostMan{SurnameNPPost = "Смирнов Гарри Евгеньевич"},
                new PostMan{SurnameNPPost = "Белов Ефрем Геласьевич"},
                new PostMan{SurnameNPPost = "Наумов Тимофей Серапионович"},
                new PostMan{SurnameNPPost = "Моисеев Артур Альбертович"},
                new PostMan{SurnameNPPost = "Сысоев Архип Кириллович"},



            };

            _postManDb=new PostManDB{  Surname = "dasdassadasda", };
           

            _subEditionDb =new SubEditionDB();
            _subscriberDb = new SubscriberDB();
           



          

            
          
            GenerateRegion(Regions);
           
         

            Users =new ObservableCollection<User>
           {

               new User("qwerty123123","131313"),
               new User("rofl","151515")

           };
          
            sadsada = new ObservableCollection<PostalOfficeDB>();
            GeneratePostaffice();
          
            sadsada = _db.GetPostalOffice();
            sadsadad = new ObservableCollection<PostalOfficeDB>();
            sadsadad = _db.AvgDate();





        }


       
        public  void GeneratePostaloficeDB()
        {


            foreach (var item in PostalOfficeDbs)
            {
                _db.AddPostalOffice(item);
                break;
            }
           

           

        }

        public void GenerateRegion(ObservableCollection<Region> Reg)
        {
            int b = 0;
            foreach (var item in Reg)
            {
                var rgdb=new RegionDB();
               
                rgdb.TitleReg = item.TitleReg;
              
            }

           
            foreach (var item in Reg)
                if (item.Postman == null)
                {
         
                        item.Postman = Postmans[b];
                        Postmans[b].Regions.Add(Reg[b]);
                        b++;

                }

            int d = 0;
            foreach (var item in Reg)
            {
               for(int i=0; i<Subscribers.Count; i++)

                   if (i < 15) item.Subscribers.Add(Subscribers[i]);
               else if (i>15) item.Subscribers.Add(Subscribers[i]);




            }

        }

     

        
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj => {
                          
                           
                               if (UsernameLog == "qwerty123123" && PasswordLog == "131313")
                               {


                                   PostMan post  = new PostMan("О.П Папич");

                                   Postmans.Insert(0, post);

                                   PostalOfficeDB pod=new PostalOfficeDB();
                                   pod.TitlePostal = PostalOfficeDBnew.TitlePostal;
                                   pod.SubscriberDB = new SubscriberDB();
                                   pod.SubscriberDB.SurnameNpSub = "0";
                                   pod.SubscriberDB.Address = "0";
                                   pod.RegionDB = new RegionDB();
                                   pod.SubEditionDB=new SubEditionDB();
                                   pod.SubEditionDB.Title = PostalOfficeDBnew.SubEditionDB.Title;
                                   pod.PostManDB =new PostManDB();
                                   pod.PostManDB.Surname = post.SurnameNPPost;
                                   _db.AddPostalOffice(pod);
                                   PostManDB postManDb=new PostManDB();
                                   postManDb.Surname = post.SurnameNPPost;
                                   postManDb.PostalOfficeDB = PostalOfficeDBnew;
                                   postManDb.RegionDB = _regionDbs;
                                 
                               _postManDbs.Insert(0,postManDb);

                               TasksOpen task = new TasksOpen();
                                   task.OpenReq();

                               }
                               else
                               {
                                   MessageBox.Show("Недостаточно прав", "Ошибка",  MessageBoxButton.OK,
                                       MessageBoxImage.Warning);
                               }
                           

                       }));
            }
        } // AddCommand


        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                       (removeCommand = new RelayCommand(obj => {
                           
                           
                               PostMan postrem=obj as PostMan;
                               if (UsernameLog == "qwerty123123" && PasswordLog == "131313")
                               {

                                   if (postrem != null)
                                   {
                                       Postmans.Remove(postrem);
                                       var postrems = new PostManDB();

  

                                       foreach (var item2 in Regions)
                                       {
                                           if (item2.Postman == postrem) item2.Postman = null;
                                          

                                               

                                       }

                                       foreach (var item in Postmans)
                                       {

                                           foreach (var item3 in Regions)
                                           {
                                               if (item3.Postman == null)
                                               {

                                                   item3.Postman = item;
                                                   item3.Postman.Regions.Add(item3);
                                                   RegionDB postremss = new RegionDB();
                                               postremss.PostManDB=new PostManDB{Surname = item.SurnameNPPost, RegionDB = new List<RegionDB>{ new RegionDB{TitleReg = item3.TitleReg }}};

                                               _db.AddRegion(postremss);
                                               }
                                           }
                                       }

                                   
                                   }
                               }
                               else
                               {
                                   MessageBox.Show("Недостаточно прав", "Ошибка", MessageBoxButton.OK,
                                       MessageBoxImage.Warning);
                               } },
                           obj => Postmans.Count > 0 && _selectedPostMan != null));
            }
        } // RemoveCommand

        public bool RemoveCommandEnabled => removeCommand.CanExecute(_selectedPostMan);


        private  RelayCommand _subscribe;
        public RelayCommand Subscribe
        {
            get
            {
                return _subscribe??
                       (_subscribe = new RelayCommand(obj => {

                               if (UsernameLog == "rofl" && PasswordLog == "151515")
                               {

                                   Subscriber sub = obj as Subscriber;
                                

                                   foreach (var item in SubEditions)
                                   {

                                       sub.IndexEdition.Add(item);

                                   
                                       sub.DateStartSub = new DateTime(1900, 07, 01);

                                       sub.DateEndSub = new DateTime(1900, 09, 30);
                                       Receipt rec = new Receipt(item.Price, item.Title, item.Price);
                                   foreach (var item2 in PostalOfficeDbs)
                                   {
                                       if (sub.SurnameNP == item2.SubscriberDB.SurnameNpSub &&
                                           item2.SubscriberDB.DateStart == sub.DateStartSub) break;
                                       if (sub.SurnameNP == item2.SubscriberDB.SurnameNpSub)
                                       {
                                        
                                           
                                           item2.SubEditionDB.Title = item.Title;
                                           item2.SubscriberDB.DateStart = sub.DateStartSub;
                                           item2.SubscriberDB.DateEnd = sub.DateEndSub;
                                           item2.SubscriberDB.Term = sub.Term;
                                           
                                           _db.UptadePostalOffice(item2);
                              

                                           break;
                                       }

                                     
                                      

                                   }
                                 

                                   SubRec.Add(rec, sub);

                                   }

                                   ObservableCollection<Subscriber> subnew =
                                       new ObservableCollection<Subscriber>(Subscribers);
                              

                              
                               Subscribers.Clear();
                                   foreach (var item in subnew)
                                   {
                                       Subscribers.Add(item);
                                       
                                   }


                                   TasksOpen task = new TasksOpen();
                                   task.OpenReq();



                           }
                               else
                               {
                                   MessageBox.Show("Недостаточно прав", "Ошибка", MessageBoxButton.OK,
                                       MessageBoxImage.Warning);
                               }


                           },
                           obj => Subscribers.Count > 0 && _selectedSub != null));
                
            }
        } // RemoveCommand

        private RelayCommand _quitCommand;
        public RelayCommand QuitCommand
        {
            get
            {
                return _quitCommand ??
                       (_quitCommand = new RelayCommand(obj => Application.Current.Shutdown()));
            }
        } // QuitCommand


        public void SetNull()
        {

            _subscriberDb=null;
            _subEditionDb=null;
            _postManDb=null;
            _regionDb = null;

            _subEditionDbs = null;
            _subscriberDbs =null;
            _regionDbs = null;
            _postManDbs = null;


            _postManDb = new PostManDB { };


            _subEditionDb = new SubEditionDB();
            _subscriberDb = new SubscriberDB();
            _regionDb=new RegionDB();

            _subEditionDbs = new List<SubEditionDB>();
            _subscriberDbs = new List<SubscriberDB>();
            _regionDbs = new List<RegionDB>();
            _postManDbs = new List<PostManDB>();
            PostalOfficeDbs.Clear();
            PostalOfficeDBnew = null;
            PostalOfficeDBnew = new PostalOfficeDB { TitlePostal = "отдел 1", SubscriberDB = _subscriberDb, RegionDB = _regionDb, PostManDB = _postManDb, SubEditionDB = _subEditionDb };
            PostalOfficeDbs=new ObservableCollection<PostalOfficeDB>();




        }
       



        public  void GeneratePostaffice()
        {
            int i = 0;

            PostalOfficeDBnew=new PostalOfficeDB();
            foreach (var item2 in Postmans)
            {

                _postManDb = new PostManDB { Id = i++, Surname = item2.SurnameNPPost, };

                _db.AddPostMan(_postManDb);
                PostalOfficeDBnew.PostManDB = _postManDb;
                _postManDbs.Add(_postManDb);
            }


            foreach (var item in Regions)
            {

                    _regionDb = new RegionDB
                    {
                        Id = i++,
                        SubEditionDB = new List<SubEditionDB>(),
                        SubscriberDB = new List<SubscriberDB>(),
                        TitleReg = item.TitleReg,
                    };


                int coundt = 0;
                foreach (var item2 in _postManDbs)
                {
                    if (coundt == 2) break;
                    _regionDb.PostManDB = item2;
                    coundt++;
                    
                }
                _regionDbs.Add(_regionDb);
                
            }

            int count = 0;


                    foreach (var item2 in SubEditions)
                    {
                        _subEditionDb = new SubEditionDB
                        {
                            Id = i++,
                            Price = item2.Price,
                            Title = item2.Title,

                        };
                        _db.AddSubEdition(_subEditionDb);
                        
                        _subEditionDbs.Add(_subEditionDb);
                    }
                   
                    
                    
                foreach (var item2 in Subscribers) 
                {
   
                           
                           if(item2.IndexEdition!=null)
                               for (int j=0;j<item2.IndexEdition.Count; j++)
                               {
                                   _subscriberDb.SubEditionDB = _subEditionDbs;
                                   break;
                               }
                                _subscriberDb = new SubscriberDB
                                {
                                    Id = i++,
                                    SurnameNpSub = item2.SurnameNP,
                                    Address = item2.HomeAddress,
                                    DateEnd = item2.DateEndSub,
                                    DateStart = item2.DateStartSub,
                                    
                                    Term = item2.DateEndSub.DayOfYear-item2.DateStartSub.DayOfYear,
                                    
                                    
                                };
                              
                               
                                _db.AddSubscriber(_subscriberDb);
                                _subscriberDbs.Add(_subscriberDb);
                            

                          
                    
                }

                foreach (var item in SubEditions)
                {
                    _subEditionDb = new SubEditionDB
                    {
                        Id = i++,
                        Price = item.Price,
                        Title = item.Title,


                    };

                }


            int coutnt = 0;
            foreach (var item in _subscriberDbs)
            {

               

                foreach (var item2 in _regionDbs)
                {
                    if (coutnt <= 15)
                    {
                        PostalOfficeDBnew.RegionDB = _regionDbs[0];
                     
                        
                        break;


                    }
                    else
                    {
                        PostalOfficeDBnew.RegionDB = _regionDbs[1];
                        break;

                    }
                    
                }

               
                foreach (var item2 in _postManDbs)
                {

                    if (coutnt <= 15)
                    {
                        PostalOfficeDBnew.PostManDB = _postManDbs[0];
                        break;

                    }
                    else if (coutnt > 15)
                    {
                        PostalOfficeDBnew.PostManDB = _postManDbs[1];
                        break;

                    }
                }

                foreach (var item3 in Subscribers)
                {
                    if (item3.IndexEdition.Count==0)
                    {
                        foreach (var item2 in _subEditionDbs)
                        {
                            
                                PostalOfficeDBnew.SubEditionDB = _subEditionDb = new SubEditionDB
                                {
                                    Id = i++,
                                    Price = 0,
                                    Title = "0"


                                };
                            break;

                         

                        }
                       
                       
                    }
                    else
                    {
                        foreach (var item2 in _subEditionDbs)
                        {

                            PostalOfficeDBnew.SubEditionDB = _subEditionDb = new SubEditionDB
                            {
                                Id = i++,
                                Price = 0,
                                Title = "0"


                            };
                            break;



                        }
                    }
                    break;
                }
              
                PostalOfficeDBnew.SubscriberDB = item;
                PostalOfficeDBnew.TitlePostal = "Отдел1";

                PostalOfficeDbs.Insert(coutnt,PostalOfficeDBnew);
                GeneratePostaloficeDB();



                coutnt++;

            }

            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        } // OnPropertyChanged
    }
}
