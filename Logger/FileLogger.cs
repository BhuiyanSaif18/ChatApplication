using System;


namespace Logger
{
    public class FileLogger : ILogger
    {
        public void Log(String message)
        {
            Console.WriteLine("[File Logger] {0} ", message);
        }
    }
}
