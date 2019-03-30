using System;

namespace LogIn
{
    public class LogIn
    {
        public void findUser(string userName, string password)
        {
            DBConnection.DBConnect db = new DBConnection.DBConnect();
            if (db.queryUser(userName, password))
            {
                Console.WriteLine("User Login Successfull");
            }
            else Console.WriteLine("User Login Failed!");
        }
    }
}
