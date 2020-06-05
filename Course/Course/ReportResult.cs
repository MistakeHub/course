using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Course
{
    [Serializable]
   public  class ReportResult
    {

        public int Id { get; set; }
        public string Region { get; set; }
        public string Postman { get; set; }
        public double AverageTerm { get; set; }
        public int NumberSubscriber { get; set; }
        public int AnySubscriber { get; set; }

        public ReportResult(int id, string region, string postman, double averageTerm, int numberSubscriber, int anySubscriber)
        {
            Id = id;
            Region = region;
            Postman = postman;
            AverageTerm = averageTerm;
            NumberSubscriber = numberSubscriber;
            AnySubscriber = anySubscriber;
        }

        public ReportResult() : this( 0,"регион", "Почтальон", 0, 0, 0) { }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
