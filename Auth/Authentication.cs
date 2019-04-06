using System;
using Logger;
using DBConnection;

namespace Auth
{
    public class Authentication
    {
        private DBConnect db = new DBConnect();
        public bool findUser(string userName, string password)
        {
            
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
        public void createUser(string userName, string password)
        {
            db.insertUser(userName, password);
            Console.WriteLine("User Creation Successful");
        }
        public void logOutUser(string userName)
        {
            db.logOut(userName);
            Console.WriteLine("User Logout Successful");
        }
    }
}
