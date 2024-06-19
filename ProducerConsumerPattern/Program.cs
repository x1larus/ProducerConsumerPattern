using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProducerConsumerPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProducerConsumerExample().Run();
            Console.ReadKey();
        }
    }

    
}