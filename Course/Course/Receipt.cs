using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Receipt
    {

        private double _prices;
        public double Prices
        {
            get => _prices;
            set => _prices = value;
        }
        private string _titlesubed;
        public string TuitleSubEd
        {
            get => _titlesubed;
            set => _titlesubed = value;
        }
        private double _term;
        public double Term
        {
            get => _term;
            set => _term= value;
        }

        public Receipt(double prices, string titleEdSub, double term)
        {
            _prices = prices;
            _titlesubed = titleEdSub;
            _term = term;


        }

    }
}
