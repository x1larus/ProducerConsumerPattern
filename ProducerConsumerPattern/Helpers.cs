using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerPattern
{
    internal static class IdHelper
    {
        private static int _id = 0;
        private static readonly object Lock = new object();

        public static int GetNextId()
        {
            lock (Lock)
            {
                return _id++;
            }
        }
    }

    internal static class ConsoleLogHelper
    {
        private static readonly object Lock = new object();

        public static void Log(string msg, ConsoleColor color = ConsoleColor.White)
        {
            lock (Lock)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
        }
    }
}
