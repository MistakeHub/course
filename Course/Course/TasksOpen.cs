using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Course.Views;

namespace Course
{
    class TasksOpen
    {
        // Класс для взаимодействием между окнами

        public TasksOpen()
        {

          

        }


        // Открытие Окна со БД
        public void OpenReq(string address, string  surname)
        {
            Requests reqwin = new Requests(address, surname);
            reqwin.ShowDialog();


        }
        // Открытие Окна со Справкой
        public void OpenReference(int countbooks, int countjurnal, int countsub)
        {
            Reference refwin = new Reference(countbooks,countjurnal,countsub);
            
            refwin.ShowDialog();
               

        }
        // Открытие окна с Отчётом
        public void OpenRep(ObservableCollection<Result> _results)
        {
            ResultReport result=new ResultReport(_results);
            result.ShowDialog();


        }

        public void OpenAbout()
        {
            About about=new About();
            about.ShowDialog();


        }

    }
}
