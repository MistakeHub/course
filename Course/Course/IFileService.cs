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
        ObservableCollection<Subscriber> Load(string filename); // загрузить коллекцию из файла
        ObservableCollection<PostMan> LoadPostMan(string filename);
        void SaveSubscriber(string filename, ObservableCollection<Subscriber> subscribers);
        void SaveResult(string filename, ObservableCollection<Result> subscribers);// сохранить коллекцию в файле
        void SavePostResult(string filename, ObservableCollection<PostManResult> postManResults);
        void SaveResutlReport(string filename, ObservableCollection<ReportResult> resultReports);
        void SavePostMan(string filename, ObservableCollection<PostMan> postman);
    } // IFileService
}
