using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using MVVM_Example_04;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Course
{
 public class XmlSereliazable:IFileService
    {

        public ObservableCollection<Subscriber> Load(string filename)
        {
            ObservableCollection<Subscriber> subscribers=new ObservableCollection<Subscriber>();
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Subscriber>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {

                subscribers = (ObservableCollection<Subscriber>) formatter.Deserialize(fs);

            }

            return subscribers;
        } // Load

        // сохранение коллекции в файл - сериализация
        public void Save(string filename, ObservableCollection<Subscriber> subscribers)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Subscriber>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, subscribers);
            }
        } // Save
    }
}
