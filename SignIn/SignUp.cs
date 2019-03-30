using System;
using Logger;
using DBConnection;

namespace SignUp
{
    public class SignUp
    {
        public void createUser(string userName, string password)
        {
            DBConnection.DBConnect db = new DBConnection.DBConnect();
            db.insertUser(userName, password);
            Console.WriteLine("User Creation Successful");
        }

    }
}
