using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobLogger;

namespace JobLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            JobLogger joblogger = new JobLogger(true, true, true, true, true, true);
            joblogger.LogMessage("Hello Message", true, false, false);
            joblogger.LogMessage("Hello Warning", false, true, false);
            joblogger.LogMessage("Hello Error", false, false, true);
            
            Console.ReadKey();
        }
    }
}
