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
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using Course.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Course
{

    // Работа с Основным ViewModel Приложения
    public class PostalOfficeViewModel
    {
        // Переменные, для работы с БД
        public SubscriberDB SubscriberDb { get; set; }
        public SubEditionDB SubEditionDb { get; set; }
        public PostManDB PostManDb { get; set; }
        public RegionDB RegionDb { get; set; }
        public List<SubscriberDB> SubscriberDbs { get; set; }
        public List<SubEditionDB> SubEditionDbs { get; set; }
        public List<PostManDB> PostManDbs{ get; set; }
        public List<RegionDB> RegionDbs { get; set; }
        public PostalOfficeDB PostalOfficeDBNew { get; set; }
        public ObservableCollection<PostalOfficeDB> PostalOfficeDbs { get; set; }
        //Переменные для работы с отчётами< справкой, заявками
        public ObservableCollection<Result> Results { get; set; }
        public ObservableCollection<Receipt> Receipts { get; set; }
        public ObservableCollection<PostMan> RequestPostMen { get; set; }
        private PostMan _selectedPostManRequest;

        // Переменная, для ввода данных в бп
        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;

                OnPropertyChanged();
            }

        }
        // Переменная, для ввода данных в бп
        private string _surname;

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value; OnPropertyChanged();
            }

        }
        
        private string _subeditionchoose;

        public string SubEditionChoose
        {
            get => _subeditionchoose;
            set
            {
                _subeditionchoose = value;
                OnPropertyChanged();
            }

        }

        // Контролллер БД, Для работы с самой БД
        private DbController _db;
        // Переменная для получения данных авторизации
        private string _names;

        public string Names
        {
            get { return _names;}
            set { _names = value; OnPropertyChanged(); }
        }
      
        private PostalOfficeDB _selectePostalOfficeDb;
     


        // Коолекция, для работы с авторизацией 
        public ObservableCollection<User> Users;
        // Названия Почтового отдела
        private string _title;
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
             
            }
        }

        public PostMan SelectedPostManRequest
        {
            get => _selectedPostManRequest;
            set
            {
                _selectedPostManRequest = value;
                OnPropertyChanged(); // 
                OnPropertyChanged("AddCommandEnabled");
            }
        } 



        private Subscriber _selectedSub;
        public Subscriber SelectedSub
        {
            get => _selectedSub;
            set
            {
                _selectedSub = value;
                OnPropertyChanged(); 
               
            }
        } 

   


        // Логин Пользователя 
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
        // пароль пользователя
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
                OnPropertyChanged(); 
                OnPropertyChanged("RemoveCommandEnabled");
            }
        } 

     
      
     // Коллекции, для работы с основными данными приложения 
        public ObservableCollection<PostMan> Postmans { get; set; }
        public ObservableCollection<Region> Regions { get; set; }
        public ObservableCollection<Subscriber> Subscribers { get; set; }
        public ObservableCollection<SubEdition> SubEditions { get; set; }
      
       
    
       // счётчик Газет
        private int _countBooks;

        public int countBooks
        {
            get => _countBooks;
            set
            {
                _countBooks = value;
                OnPropertyChanged();

            }
        }

        // счётский журналов
        public int countJurnal { get; set; }
       public int countSub { get; set; }
       // Конструктор ViewModela
        public PostalOfficeViewModel(string title)
        {

          // Установка значений по умолчанию
            countBooks = 0;
            countJurnal = 0;
           
            countSub = 0;
            
            _db =new DbController();
                _title = title;
                Postmans=new ObservableCollection<PostMan>();
                Regions = new ObservableCollection<Region>();
                // Заполнение данными 
                SubEditions = new ObservableCollection<SubEdition>
                {

                 
                    new SubEdition("Журнал 1-го издания", 2100),
                    new SubEdition("Журнал 2-го издания", 300),
                    new SubEdition("Журнал 3-го издания", 1500),
                    new SubEdition("Журнал 4-го издания", 2543),
                    new SubEdition("Газета 1-го издания",2252),
                    new SubEdition("Газета 2-го издания", 500),
                    new SubEdition("Газета 3-го издания", 4322),
                    new SubEdition("Газета 4-го издания", 1123),



                };
                Regions = new ObservableCollection<Region>
                {

                    new Region("Участок 1" ),
                    new Region("Участок 2" ),


                };
                // Установка значений по умолчанию
                PostalOfficeDB postalOffice = new PostalOfficeDB();
                postalOffice.TitlePostal = "отдел1";
            SubEditionDbs =new List<SubEditionDB>();
                SubscriberDbs=new List<SubscriberDB>();
                RegionDbs=new List<RegionDB>();
                PostManDbs=new List<PostManDB>();
                PostalOfficeDbs=new ObservableCollection<PostalOfficeDB>();
                // Заполнение данными 
            Subscribers = new ObservableCollection<Subscriber>
            {
                new Subscriber("З.Ш Михайловна","ул. Михайловский проезд, дом 71, квартира 439" , new DateTime(1000,1,1),new DateTime(1000,1,1) ),
                new Subscriber("Б.С Валентинович","ул. Скобелевская, дом 34, квартира 371", new DateTime(1000,1,1),new DateTime(1000,1,1)),
                new Subscriber("К.А Юрьевна","ул. Первомайский район тер, дом 26, квартира 19", new DateTime(1000,1,1),new DateTime(1000,1,1) ),
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


            RequestPostMen=new ObservableCollection<PostMan>
            {
                new PostMan{SurnameNPPost = "Павлов Азарий Станиславович"},
                new PostMan{SurnameNPPost = "Сидоров Владислав Серапионович"},
                new PostMan{SurnameNPPost = "Бирюков Лавр Адольфович"},
                new PostMan{SurnameNPPost = "Игнатьев Иннокентий Дмитрьевич"},
                new PostMan{SurnameNPPost = "Орлов Антон Павлович"},
                new PostMan{SurnameNPPost = "Киселёв Филипп Григорьевич"},
                new PostMan{SurnameNPPost = "Петров Нелли Платонович"},
                new PostMan{SurnameNPPost = "Беляев Павел Валентинович"},
                new PostMan{SurnameNPPost = "Титов Николай Тимофеевич"},
                new PostMan{SurnameNPPost = "Молчанов Иван Вячеславович"},


            };
            // Установка значений по умолчанию
             SubEditionDb =new SubEditionDB();
            SubscriberDb = new SubscriberDB();
           
            // Генерация региона, а точнее заполнение региона Почтальонами
            GenerateRegion(Regions);
           
         
            // Данные для авторизации 
            Users =new ObservableCollection<User>
           {

               new User("qwertyqwerty","131313"),
               new User("Mag1824","151515")

           };
            Results=new ObservableCollection<Result>();
            Receipts=new ObservableCollection<Receipt>();

        }
        // Генерация отчёта 
        public void GenerateResults()
        {
            foreach (var item in Postmans)
            {

                // Основная логика, Ходим по коллекциии Почтальонов, и через коллекцию регионов происходит заполнения данными 
                Result result=new Result();
                result.SurnamePostmanst = item.SurnameNPPost;
                result.CountPostmansRegions = item.Regions.Count;
                foreach (var item2 in item.Regions)
                {
                   
                    foreach (var item3 in item2.Subscribers)
                    {
                        result.AddressesSubscribers.Add( item3.HomeAddress);
                        result.TermSubscribers += item3.Term;
                       
                        result.AnySubEdition += item3.IndexEdition.Count;
                        foreach (var item4 in item3.IndexEdition)
                        {
                           
                            result.SubeditionsTitles.Add(item4.Title);
                        }
                       
                        
                    }
                    
                }
                // Добавления нового элемента отчёта 
                Results.Add(result);
                


            }


        }
        
       
        public  void GeneratePostaloficeDB()
        {

            //Добавление Данных Коллекции PoststalOfficeDbs в БД
            foreach (var item in PostalOfficeDbs)
            {
                _db.AddPostalOffice(item);
                break;
            }
           

           

        }

        public void GenerateRegion(ObservableCollection<Region> Reg)
        {

            // Заполение Регионов Почтальонами 
            int b = 0;
            foreach (var item in Reg)
                if (item.Postman == null)
                {
         
                        item.Postman = Postmans[b];
                        Postmans[b].Regions.Add(Reg[b]);
                        b++;

                }

        
         

        }

     

       // Комманда  Добавления Почтальона 
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                       (addCommand = new RelayCommand(obj => {
                           // Переменная, полученная в результате клика 
                           PostMan post = obj as PostMan;
                           // Валидация пароля и логина 
                           if (UsernameLog == "qwertyqwerty" && PasswordLog == "131313")
                           {
                                   if (post != null)
                                   {
                                       // Вставка Почтальона, 
                                       Postmans.Insert(0, post);
                                       // Удаление Почтальона из заявки 
                                       RequestPostMen.Remove(post);
                                   }

         
                           }

                           },
                           // Команда будет работать при эти условиях
                obj => _selectedPostManRequest != null && RequestPostMen.Count>0 ));
            }
        } 

        public bool AddCommandEnabled => AddCommand.CanExecute(_selectedPostManRequest);

        // Команда Удалающая почтальонов из основной коллекции 
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                       (removeCommand = new RelayCommand(obj => {

                           // Переменная, полученная в результате клика 
                           PostMan postrem =obj as PostMan;
                           // Валидация пароля и логина 
                           if (UsernameLog == "qwertyqwerty" && PasswordLog == "131313")
                               {
                               // Проверка на нулл значение 
                                   if (postrem != null)
                                   {
                                       // Удаление почтальона по задданому обьекту
                                       Postmans.Remove(postrem);
                                      
                                
                                     

  
                                   // Изьятие из участка почтальона
                                       foreach (var item2 in Regions)
                                       {
                                           if (item2.Postman == postrem) item2.Postman = null;
                                          

                                               

                                       }
                                       // Участко не может быть пустым, по этому добавляем след почтальона 
                                       foreach (var item in Postmans)
                                       {

                                           foreach (var item3 in Regions)
                                           {
                                               if (item3.Postman == null)
                                               {
                                                   // Добавление почтальона в участок 
                                                   item3.Postman = item;
                                                   item3.Postman.Regions.Add(item3);
                                                 
                                               }
                                           }
                                       }

                                   
                                   }
                               }
                           },
                           obj => Postmans.Count > 0 && _selectedPostMan != null));
            }
        } // RemoveCommand

        public bool RemoveCommandEnabled => removeCommand.CanExecute(_selectedPostMan);

        // Оформление подписки 
        private  RelayCommand _subscribe;
        public RelayCommand Subscribe
        {
            get
            {
                return _subscribe??
                       (_subscribe = new RelayCommand(obj => {
                           // Валидация пароля и логина
                               
                           if (UsernameLog == "Mag1824" && PasswordLog == "151515")
                           {
                               // Переменная в результате клика 
                                   Subscriber sub = obj as Subscriber;
                                   
                               // ОСновная логика приложения
                               foreach (var item in SubEditions)
                                   {
                                       if (item.Title == SubEditionChoose)
                                       {
                                           // переменная для пометки состояния цыкла
                                           bool flag = false;
                                           Random rand = new Random();
                                           
                                           sub.IndexEdition.Add(item);


                                           sub.DateStartSub = new DateTime(2020, rand.Next(01,06) , rand.Next(01,28));

                                           sub.DateEndSub = new DateTime(2020, rand.Next(07, 12), rand.Next(01, 28));
                                           sub.Term += sub.DateEndSub.DayOfYear - sub.DateStartSub.DayOfYear;
                                           // Создания чека
                                           Receipt rec = new Receipt(item.Price, item.Title, sub.Term, sub.SurnameNP);
                                           // Добавления чека в Коллекцию
                                         Receipts.Add(rec);
                                         // Расппределение подписчиков по региону
                                           foreach (var item2 in Regions)
                                           {
                                               for (int i = 0; i < Subscribers.Count; i++)
                                               {

                                                   if (item2.Subscribers.Count < 13 &&
                                                       Subscribers[i].IndexEdition.Count != 0 &&
                                                       Subscribers[i].IndexEdition.Count < 2 &&
                                                       sub.SurnameNP == Subscribers[i].SurnameNP)
                                                   {
                                                       Regions[0].Subscribers.Add(Subscribers[i]);
                                                       flag = true;

                                                   }

                                                   if (item2.Subscribers.Count >= 13 &&
                                                       Subscribers[i].IndexEdition.Count != 0 &&
                                                       Subscribers[i].IndexEdition.Count < 2 &&
                                                       sub.SurnameNP == Subscribers[i].SurnameNP)
                                                   {


                                                       flag = true;
                                                       Regions[1].Subscribers.Add(Subscribers[i]);




                                                   }



                                               }
                                               // Проверка того, какое издание было выбрато,
                                               foreach (var item3 in sub.IndexEdition)
                                               {
                                                
                                                   Regex rex = new Regex(@"Журнал.\d");
                                                   if (rex.IsMatch(item3.Title) )
                                                   {
                                                       
                                                       countJurnal += 1;
                                                       countSub++;
                                                   }
                                                   rex=new Regex(@"Газета.\d");
                                                   if (rex.IsMatch(item3.Title))
                                                   {
                                                       countBooks += 1;
                                                       countSub++;
                                                   }

                                               }

                                               if (flag != false)
                                               {
                                                   GeneratePostaffice(sub);
                                                   break;
                                               }

                                           }
                                     
                                           break;
                                           

                                       }
                                   }

                               // Создание новой коллекции для перерисовки DataGrid
                                   ObservableCollection<Subscriber> subnew =
                                       new ObservableCollection<Subscriber>(Subscribers);
                               // Очистка Основной коллекции
                               Subscribers.Clear();
                               // Добавление переменных из копиии коллекции в основую коллекцию
                                   foreach (var item in subnew)
                                   {
                                       Subscribers.Add(item);
                                       
                                   }

                                   
                                  
                                  

                                   

                           }
                             


                           },
                           obj => Subscribers.Count > 0 && _selectedSub != null));
                
            }
        } // RemoveCommand
        // Выход
        private RelayCommand _quitCommand;
        public RelayCommand QuitCommand
        {
            get
            {
                return _quitCommand ??
                       (_quitCommand = new RelayCommand(obj => Application.Current.Shutdown()));
            }
        } // QuitCommand
        // Команда для ввывода справки 
        private RelayCommand _ref;
        public RelayCommand Ref
        {
            get
            {
                return _ref??
                       (_ref = new RelayCommand(obj =>
                       {
                           TasksOpen tasks=new TasksOpen();
                           tasks.OpenReference(countBooks, countJurnal, countSub);

                       }));
            }
        }
        // Команда открытвающая окно About
        private RelayCommand _about;
        public RelayCommand About
        {
            get
            {
                return _about ??
                       (_about = new RelayCommand(obj =>
                       {
                           TasksOpen tasks = new TasksOpen();
                           tasks.OpenAbout();

                       }));
            }
        }

        // Команда для ввывода Отчёта 
        private RelayCommand _rep;
        public RelayCommand Rep
        {
            get
            {
                return _rep ??
                       (_rep = new RelayCommand(obj =>
                       {
                           TasksOpen tasks = new TasksOpen();
                           Results.Clear();
                           GenerateResults();
                           tasks.OpenRep(Results);

                       }));
            }
        }
        // Команда для ввывода БД
        private RelayCommand _database;
        public RelayCommand Database
        {
            get
            {
                return _database ??
                       (_database = new RelayCommand(obj =>
                       {
                           TasksOpen task = new TasksOpen();
                           task.OpenReq(Address, Surname);
                       }));
            }
        } 





        // Основная геннерация Данных для БД
        public  void GeneratePostaffice(Subscriber sub)
        {

            foreach (var item in Regions)
            {
                int i = 0;

                // Создание, и добавление Издания в БД
                PostalOfficeDBNew = new PostalOfficeDB();
                foreach (var item2 in sub.IndexEdition)
                {
                    
                        SubEditionDb = new SubEditionDB
                        {
                            Id = i++,
                            Price = item2.Price,
                            Title = item2.Title,
                           

                        };
                        SubEditionDb.SubscriberDB=new SubscriberDB();
                        SubEditionDb.SubscriberDB.SurnameNpSub = "-";
                        SubEditionDb.SubscriberDB.PostalOfficeDB = null;
                        SubEditionDb.SubscriberDB.SubEditionDB=new List<SubEditionDB>();
                        SubEditionDb.SubscriberDB.Address = "";
                        SubEditionDb.SubscriberDB.DateStart = new DateTime(1000,01,01);
                        SubEditionDb.SubscriberDB.DateEnd=new DateTime(1000,01,01);
                        SubEditionDb.SubscriberDB.RegionDB = null;


                        SubEditionDb.SubscriberDB.Term = SubscriberDb.Term;

                        _db.AddSubEdition(SubEditionDb);
                        PostalOfficeDBNew.SubEditionDB = SubEditionDb;
                        break;

                }



                // Создание, и добавление подписчика в БД
                SubscriberDb = new SubscriberDB
                {
                    Id = i++,
                    SurnameNpSub = sub.SurnameNP,
                    Address = sub.HomeAddress,
                    DateEnd = sub.DateEndSub,
                    DateStart = sub.DateStartSub,

                    Term = sub.DateEndSub.DayOfYear - sub.DateStartSub.DayOfYear,


                };
                _db.AddSubscriber(SubscriberDb);
                PostalOfficeDBNew.SubscriberDB = SubscriberDb;



                // Создание, и добавление Почтальона в БД
                foreach (var item2 in Postmans)
                {


                    PostManDb = new PostManDB
                    {
                        Id = i++,
                        Surname = item2.SurnameNPPost,
                       


                    };

                    _db.AddPostMan(PostManDb);
                    PostalOfficeDBNew.PostManDB = PostManDb;
                    PostManDbs.Add(PostManDb);



                    _db.AddPostMan(PostManDb);
                   
                    break;
                }

                // Создание, и добавление подписчика в БД
                // проверка количества подписчиков, Для определения участка
                if (item.Subscribers.Count  <Region.Max )
                    RegionDb = new RegionDB
                    {
                        Id = i++,
                        SubEditionDB = new List<SubEditionDB>(),
                        SubscriberDB = new List<SubscriberDB>(),
                        TitleReg = Regions[0].TitleReg,
                    };

                else if(item.Subscribers.Count ==Region.Max)
                {
                    RegionDb = null;
                    RegionDb = new RegionDB
                    {
                        Id = i++,
                        SubEditionDB = new List<SubEditionDB>(),
                        SubscriberDB = new List<SubscriberDB>(),
                        TitleReg =Regions[1].TitleReg,
                    };
                }



                
                RegionDbs.Add(RegionDb);
                    _db.AddRegion(RegionDb);
                PostalOfficeDBNew.RegionDB = RegionDb;
                PostalOfficeDBNew.TitlePostal = "Отдел1";
              
                break;
            }
            PostalOfficeDbs.Insert(0, PostalOfficeDBNew);
            // Добавление PostalOfficeDbs в БД
            GeneratePostaloficeDB();
           








        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        } // OnPropertyChanged
    }
}
