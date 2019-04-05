﻿using System;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQConnect
{
    public class Rabbit
    {
        public IConnection GetConnection(string hostName, string userName, string password)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = "172.20.10.2";
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";
            try{
                System.Console.WriteLine("Connection established");
                return connectionFactory.CreateConnection();
            }catch(Exception e){
                System.Console.WriteLine(e.Message);
                return connectionFactory.CreateConnection();
            }
            
        }
        public static void Send(string queue, string data)
        {
            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    channel.BasicPublish(string.Empty, queue, null, Encoding.UTF8.GetBytes(data));
                }
            }
        }
        public static void Receive(string queue)
        {
            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
               channel.QueueDeclare(queue, false, false, false, null);
               var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
               BasicGetResult result = channel.BasicGet(queue, true);
                    if (result != null)
                    {
                      string data =
                      Encoding.UTF8.GetString(result.Body);
                        Console.WriteLine(data);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Send("IDG","Hello World!");
            Receive("IDG");
            Console.ReadLine();
        }
        
    }
}