using System;
using System.Collections.Generic;
using System.Text;
using DBConnection;

namespace Operation
{
    public class Query
    {
        public void ShowActiveUser()
        {
            DBConnect db = new DBConnect();
            db.queryActiveUser();
        }    
    }
}
