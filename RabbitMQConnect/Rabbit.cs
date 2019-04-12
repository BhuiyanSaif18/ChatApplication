using System;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQConnect
{
    
    public class Rabbit
    {
        static IConnection connection = new ConnectionFactory().CreateConnection();
        static IModel channel = connection.CreateModel();
        public Rabbit()
        {
            GetConnection("172.16.0.160", "test", "test");
        }
        public IConnection GetConnection(string hostName, string userName, string password)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "172.16.0.160";
            connectionFactory.UserName = "test";
            connectionFactory.Password = "test";
            try{
                System.Console.WriteLine("Connection established");
                return connectionFactory.CreateConnection();
            }catch(Exception e){
                System.Console.WriteLine(e.Message);
                return connectionFactory.CreateConnection();
            }
            
        }
        public void Send(string queue, string data)
        {
            channel.QueueDeclare(queue, false, false, false, null);
            channel.BasicPublish(string.Empty, queue, null, Encoding.UTF8.GetBytes(data));
        }
        public void Receive(string queue)
        {
            
            channel.QueueDeclare(queue, false, false, false, null);
            var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
            BasicGetResult result = channel.BasicGet(queue, true);
            if (result != null)
                {
                    string data =
                    Encoding.UTF8.GetString(result.Body);
                    Console.WriteLine(data);
                    //System.Console.WriteLine(result.MessageCount);
                }
        }
        public int getCount(string queue){
            channel.QueueDeclare(queue, false, false, false, null);
            var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
            BasicGetResult result = channel.BasicGet(queue, true);
            if (result != null)
                {
                    return Convert.ToInt32(result.MessageCount);
                    
                }
            return 0;
        }
        // static void Main(string[] args)
        // {
        //     Send("IDG","Hello World!");
        //     Receive("IDG");
        //     Console.ReadLine();
        // }
        public void Destroy(){
            channel.Close();
            connection.Close();
        }
        
    }
}
