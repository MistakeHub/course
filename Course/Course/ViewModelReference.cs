using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
 public    class ViewModelReference
    {
        // ViewModel Справки
        // счётчик газет
        public int CountBooks { get; set; }
        // счётчик Журналов
        public int CountJurnal { get; set; }
        // Счётчик Подписчиков
        public int CountSubs { get; set; }
        // конструктор с парамметрами 
        public ViewModelReference(int countBooks, int countJurnal, int countSubs)
        {

            CountBooks = countBooks;
            CountJurnal = countJurnal;
            CountSubs = countSubs;

        }
        //конструктор по умолчанию
        public ViewModelReference() : this(0, 0, 0) { }
    }
}
