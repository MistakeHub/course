using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example_04
{
    // Интерфейс для реализации диалогов
    public interface IDialogService {
        void ShowMessage(string message);   // показать сообщение
        
        bool OpenFileDialog();  // открытие файла
        bool SaveFileDialog();  // сохранение файла

        string FilePath { get; set; }   // путь к выбранному файлу
    }
}
