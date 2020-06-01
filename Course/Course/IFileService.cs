using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course;

namespace MVVM_Example_04
{
   
    public interface IFileService {
        ObservableCollection<Subscriber> Load(string filename);                    // загрузить коллекцию из файла
        void Save(string filename, ObservableCollection<Subscriber> subscribers);   // сохранить коллекцию в файле
    } // IFileService
}
