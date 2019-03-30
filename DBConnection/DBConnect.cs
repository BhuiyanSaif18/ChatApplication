using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DBConnection
{
    public class DBConnect
    {
        //private Object db;
        IMongoClient client;
        IMongoDatabase db;
        IMongoCollection<UserAuth> colauth;
        
        public DBConnect()
        {
            client = new MongoClient();
            db = client.GetDatabase("ChatApplication");
            colauth = db.GetCollection<UserAuth>("UserAuth");
            Console.WriteLine("Db Constructor");
        }
        public void insertUser(string userName, string password)
        {
            UserAuth document = new UserAuth();
            var id = Guid.NewGuid().ToString();

            document._id = id;
            document.login = false;
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
                    colauth.UpdateOne(filter, update);
                    return true;
                }
                    
            }
            return false;
        }
        public string queryActiveUser()
        {
            var user = colauth.Find(b => b.login == true).Limit(100).ToListAsync().Result;
            foreach (var u in user)
            {
                Console.WriteLine(u.username);
            }
            return "user";
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
