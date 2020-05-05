﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    //Работа с Участком
    class Region
    {
        //Название Участка
        private string _titleReg;
        
        public string TitleReg
        {
            get { return _titleReg; }
            set {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Неверный формат  названия ");
                _titleReg = value;
            }
        }
       // Почтальон Участка
        public PostMan Postman { get; set; }
        // Подписчики Участка
        public List<Subscriber> Subscribers { get; set; }
        //Конструктор с параметрами 
        public Region(string title, PostMan postman, List<Subscriber> subscribers)
        {
            _titleReg = title;
            Postman = postman;
            Subscribers = subscribers;

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}