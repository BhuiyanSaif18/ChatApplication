using System;

namespace Logger
{
    public class TextLogger : ILogger
    {
        public void Log(String message)
        {
            Console.WriteLine("[Text Logger]");
        }
    }

}
