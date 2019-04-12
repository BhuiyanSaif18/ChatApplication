using System;
using System.Collections.Generic;
using System.Text;
using DBConnection;

namespace Operation
{
    public class Query
    {
        public string[] ShowActiveUser()
        {
            string[] users = new string[120]; 
            DBConnect db = new DBConnect();
            users = db.queryActiveUser();
            return users;
        }    
    }
}
