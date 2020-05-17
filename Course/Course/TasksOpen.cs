using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Course
{
    class TasksOpen
    {

        public TasksOpen()
        {

          

        }

        public void OpenReq()
        {
            Requests reqwin = new Requests();
            reqwin.ShowDialog();


        }

        public void OpenReport(int countbooks, int countjurnal, int countsub)
        {
            Reference refwin = new Reference(countbooks,countjurnal,countsub);
            
            refwin.ShowDialog();
               

        }

    }
}
