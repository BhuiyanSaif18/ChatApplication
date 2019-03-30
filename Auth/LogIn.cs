using System;
using Logger;
using DBConnection;

namespace Auth
{
    public class LogIn
    {
        public bool findUser(string userName, string password)
        {
            DBConnect db = new DBConnect();
            if (db.loginUser(userName, password))
            {
                Console.WriteLine("User Login Success");
                return true;
            }
            else
            {
                Console.WriteLine("User Login Failed!");
                return false;
            }

        }
    }
}
