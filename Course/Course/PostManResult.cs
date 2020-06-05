using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [Serializable]
   public  class PostManResult
    {
        public int Id { get; set; }
        public string Surname { get; set; }

        public PostManResult(int id, string surname)
        {
            Id = id;
            Surname = surname;
        }

        public PostManResult() : this(0,"Имя") { }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
