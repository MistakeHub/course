using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32; // для диалогов открытия/сохранения
using System.Windows;

namespace MVVM_Example_04
{
    public class DefaultDialogService : IDialogService
    {
        // Реализация интерфейса - свойство задано интерфейсом  
        public string FilePath { get; set; }

        // диалог открытия файла
        public bool OpenFileDialog() {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "файлы XML (*.xml)|*.xmk|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true) {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog() {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "файлы XML (*.xml)|*.xml|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true) {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowMessage(string message) {
            MessageBox.Show(message, "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
