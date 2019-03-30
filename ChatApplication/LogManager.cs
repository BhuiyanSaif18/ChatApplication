using System;
using System.Collections.Generic;
using System.Text;
using Logger;

namespace ChatApplication
{
    class LogManager
    {   
        private ILogger _logger;
        public LogManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(String message)
        {
            _logger.Log(message);
        }


    }
}
