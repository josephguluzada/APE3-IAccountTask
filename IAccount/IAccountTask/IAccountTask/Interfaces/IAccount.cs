using System;
using System.Collections.Generic;
using System.Text;

namespace IAccountTask.Interfaces
{
    interface IAccount
    {
        public bool PasswordChecker(string password);
        public void ShowInfo();
    }
}
