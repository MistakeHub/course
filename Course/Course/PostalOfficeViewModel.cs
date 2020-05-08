using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations.Model;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using Course.Model;

namespace Course
{
    public class PostalOfficeViewModel
    {
        private DbController _db;
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

        public SubEdition sb = new SubEdition("Комиксы ", 900);
     
        public ObservableCollection<PostMan> Postmans { get; set; }
        public ObservableCollection<Region> Regions { get; set; }
        public ObservableCollection<Subscriber> Subscribers { get; set; }
        public ObservableCollection<SubEdition> SubEditions { get; set; }
        public Dictionary<Subscriber, Receipt> SubRec { get; set; }

        public PostalOfficeViewModel(string title)
        {
            _db=new DbController();
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
            SubRec = new Dictionary<Subscriber, Receipt>();
 

             


               GeneratePostMan(Postmans);
     GenerateRegion(Regions);
     GenerateSubEdit(SubEditions);
     GenerateSub(Subscribers);


            Subscribe(sb, new Subscriber("З.Ш Михайловна", "ул. Михайловский проезд, дом 71, квартира 439", new DateTime(1000, 1, 1), new DateTime(1000, 1, 1)), 13, 19);

        }

        public void GeneratePostMan(ObservableCollection<PostMan> post)
        {

            post = new ObservableCollection<PostMan>
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

            
            foreach (var item in post)
            {
                var postdb=new PostManDB();
                postdb.Surname = item.SurnameNPPost;
                _db.AddPostMan(postdb);
            }

        }

        public void GenerateRegion(ObservableCollection<Region> Reg)
        {
            Reg = new ObservableCollection<Region>
            {

                new Region("Участок 1" ),
                new Region("Участок 2" ),


            };
            foreach (var item in Reg)
            {
                var rgdb=new RegionDB();
               
                rgdb.TitleReg = item.TitleReg;
                _db.AddRegion(rgdb);
            }

            foreach (var item in Reg)
            {
                foreach (var item2 in Postmans)
                {

                    if (item.Postman == null) item.Postman = item2;
                    
                }
                
            }

            for (int i = 0; i < Subscribers.Count ; i++)
            {
                foreach (var item in Subscribers)
                {
               
                }
               
                


            }

        }

        public void GenerateSub(ObservableCollection<Subscriber> sub)
        {

         
            foreach (var item in sub)
            {
             var subdb=new SubscriberDB();
             subdb.SurnameNpSub = item.SurnameNP;
             _db.AddSub(subdb);
            }

        }

        public void GenerateSubEdit(ObservableCollection<SubEdition> se)
        {


        
            foreach (var item in se)
            {
                var subeddb=new SubEditionDB();
                subeddb.Title = item.Title;
                subeddb.Price = item.Price;
                _db.AddSubEdition(subeddb);

            }
        }
        public ObservableCollection<PostMan> AddPostMen(PostMan postMan)
        {
            
            Postmans.Add(postMan);
            var postdb=new PostManDB();
            postdb.Surname = postMan.SurnameNPPost;
            return Postmans;
        }
        
        

        public void DeleTPostMen(PostMan postMan)
        {

            foreach (var item in Postmans)
            {
                if (postMan == item)
                {
                   
                    Postmans.Remove(item);
                    var postrem=new PostManDB();
                    postrem.Surname = item.SurnameNPPost;
                    _db.RemovePostMan(postrem);

                    

                    foreach (var item2 in Regions)
                    {
                        if (item2.Postman == item) item2.Postman=null;
                        
                    }
                };

                foreach (var item3 in Regions)
                {
                    if (item3.Postman == null)
                    {
                        
                        item3.Postman = item;
                        item3.Postman.Regions.Add(item3);
                        var postrem = new RegionDB();
                        postrem.PostManDB.Surname= item3.Postman.SurnameNPPost;
                      
                        _db.AddRegion(postrem);

                    }
                   


                }


            }





        }

        public void Subscribe(SubEdition subed,Subscriber sub,  int daystart, int dateend)
        {
            foreach (var item in SubEditions)
            {
                if (subed.Title == item.Title)
                {

                    foreach (var item2 in Subscribers)
                    {
                        if (sub.SurnameNP == item2.SurnameNP)
                        {
                           
                            
                            item2.IndexEdition.Add(subed);

                            
                        item2.DateStartSub = new DateTime(1900,07,daystart);
                          
                            item2.DateEndSub = new DateTime(1900,07,dateend);
                            Receipt rec=new Receipt(subed.Price,subed.Title,item.Price );
                           SubRec.Add(sub,rec);
                           SelectedSub = sub;

                            
                        }
                    }

                }
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        } // OnPropertyChanged
    }
}
