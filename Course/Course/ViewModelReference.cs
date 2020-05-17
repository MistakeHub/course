using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
 public    class ViewModelReference
    {

        public int CountBooks { get; set; }
        public int CountJurnal { get; set; }
        public int CountSubs { get; set; }

        public ViewModelReference(int countBooks, int countJurnal, int countSubs)
        {

            CountBooks = countBooks;
            CountJurnal = countJurnal;
            CountSubs = countSubs;

        }
        public ViewModelReference() : this(0, 0, 0) { }
    }
}
