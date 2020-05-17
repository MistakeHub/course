using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Receipt
    {
        // Работа с чеком
        // Имя подписчика
        private string _surname;
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        // Ценна издания
        private double _prices;
        public double Prices
        {
            get => _prices;
            set => _prices = value;
        }
        // Название Издания
        private string _titlesubed;
        public string TuitleSubEd
        {
            get => _titlesubed;
            set => _titlesubed = value;
        }
        // Срок подписки
        private double _term;
        public double Term
        {
            get => _term;
            set => _term= value;
        }
        // конкструктор с параметрами 
        public Receipt(double prices, string titleEdSub, double term, string surname)
        {
            _prices = prices;
            _titlesubed = titleEdSub;
            _term = term;
            _surname = surname;


        }
        // конструктор без параметров 
        public Receipt() : this(0, "0", 0,"0") { }
        
    }
}
