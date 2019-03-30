using System;
using Logger;
using DBConnection;

namespace Auth
{
    public class SignUp
    {
        public void createUser(string userName, string password)
        {
            DBConnect db = new DBConnect();
            db.insertUser(userName, password);
            Console.WriteLine("User Creation Successful");
        }

    }
}
