using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
   public class User
    {
        // Класс, для работы с данными авторизации 
        // Логин
        private string _username;

        public string UserName
        {
            get => _username;
            set => _username = value;

        }
        // Пароль
        private string _password;

        public string  Password
        {
            get => _password;
            set => _password = value;

        }
        // Конструктор с парамметрами 
        public User(string username, string password)
        {
            _username = username;
            _password = password;


        }

    }
}
