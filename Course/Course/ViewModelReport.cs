using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_Example_04;

namespace Course
{
    public class ViewModelReport
    {
        //VM Отчёта
        // Коолекция Элементов Отчёта
        IFileService _fileService;
        IDialogService _dialogService;
        public ObservableCollection<Result> Results { get; set; }

        public string SelectedSubEditionsTitles { get; set; }

        public string SelectedSubscribersSurnames { get; set; }
        // Конструктор с парамметрами 
        public ViewModelReport(ObservableCollection<Result> _results, IFileService fileService, IDialogService dialogService)
        {
            _fileService = fileService;
            _dialogService = dialogService;
            
            Results = _results;

        }

        private RelayCommand _savecommand;

        public RelayCommand SaveCommand
        {

            get
            {
                return _savecommand ?? (_savecommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (_dialogService.SaveFileDialog())
                        {
                            // для сохранения передаем преобразованную в список коллекцию
                            _fileService.SaveResult(_dialogService.FilePath, Results);
                            _dialogService.ShowMessage("Файл сохранен");
                        }
                    }
                    catch (Exception ex)
                    {
                        _dialogService.ShowMessage(ex.Message);
                    }

                }));
            }
        }
    }
}
