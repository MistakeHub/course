using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class User
    {

        private string _username;

        public string UserName
        {
            get => _username;
            set => _username = value;

        }

        private string _password;

        public string  Password
        {
            get => _password;
            set => _password = value;

        }

        public User(string username, string password)
        {
            _username = username;
            _password = password;


        }

    }
}
