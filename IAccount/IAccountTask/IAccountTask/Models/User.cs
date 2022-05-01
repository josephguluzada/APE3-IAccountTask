using IAccountTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAccountTask.Models
{
    class User : IAccount
    {
        private static int _id = 0;
        private string _password;
        public int Id { get;}
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password
        {
            get => _password;
            set 
            {
                if (PasswordChecker(value)) _password = value;
            }
        }


        public User(string email, string password,string fullname)
        {
            Id = ++_id;
            Email = email;
            Password = password;
            Fullname = fullname;
        }

        public bool PasswordChecker(string password)
        {
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            if (!String.IsNullOrWhiteSpace(password) && password.Length >= 8)
            {
                foreach (char cr in password)
                {
                    if (char.IsUpper(cr)) hasUpper = true;
                    else if (char.IsLower(cr)) hasLower = true;
                    else if (char.IsDigit(cr)) hasDigit = true;

                    if (hasUpper && hasDigit && hasLower) return true;
                }
            }
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id- {Id} - Fullname: {Fullname} Email: {Email}");
        }
    }
}
