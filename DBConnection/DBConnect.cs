using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DBConnection
{
    public class DBConnect
    {
        //private Object db;
        static IMongoClient client = new MongoClient();
        static IMongoDatabase db;
        static IMongoCollection<UserAuth> colauth;
        
        public DBConnect()
        {
            //client = ;
            db = client.GetDatabase("ChatApplication");
            colauth = db.GetCollection<UserAuth>("UserAuth");
        }
        public void insertUser(string userName, string password)
        {
            UserAuth document = new UserAuth();
            var id = Guid.NewGuid().ToString();

            document._id = id;
            document.login = true;
            document.username = userName;
            document.password = password;


           colauth.InsertOneAsync(document);
        }
        public bool loginUser(string userName, string password)
        {
            
            var user = colauth.Find(b => b.username == userName).Limit(100).ToListAsync().Result;
            
            foreach (var u in user)
            { 
                if (u.password == password)
                {
                    var filter = Builders<UserAuth>.Filter.Eq("login", false);
                    var update = Builders<UserAuth>.Update.Set("login", true);
                    colauth.UpdateOneAsync(filter, update);
                    return true;
                }
                    
            }
            return false;
        }
        public void logOut(string userName)
        {
            
            var user = colauth.Find(b => b.username == userName).Limit(100).ToListAsync().Result;
            
            foreach (var u in user)
            { 
                if (u.username == userName)
                {
                    var filter = Builders<UserAuth>.Filter.Eq("login", true);
                    var update = Builders<UserAuth>.Update.Set("login", false);
                    colauth.UpdateOneAsync(filter, update);
                }       
            }
        }
        public string[] queryActiveUser()
        {
            var user = colauth.Find(b => b.login == true).Limit(100).ToListAsync().Result;
            string[] userList = new string[120];
            //Console.WriteLine(user.Count);
            var i = 0;
            foreach (var u in user)
            {
                userList[i] = u.username;
                i++;
                //Console.WriteLine(u.username);
            }
            return userList;
        }
        public string queryMessage()
        {
            string a = "sadaosd";
            return a;
        }
    }
}
public class UserAuth
{
    public string _id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public bool login { get; set; }
}
