using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPP_SingletonPattern
{
    public class Logger
    {
        private static Logger instance=null;
        private Logger()
        {
            Console.WriteLine("Instance created.");
        }
        public static Logger getInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger l1 = Logger.getInstance();
            Logger l2 = Logger.getInstance();
            if (l1 == l2)
            {
                Console.WriteLine("l1 and l2 use same instance");
            }
            else
            {
                Console.WriteLine("l1 and l2 use different instance");
            }
            
        }
    }
}
