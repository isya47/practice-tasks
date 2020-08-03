using System;
using System.Collections.Generic;
using System.Threading;

namespace MonitorQueue
{
    class Program
    {
        public static Thread[] tid = new Thread[8];

        static void Main(string[] args)
        {
            //Test1
            /* tid[0] = new Thread(Action.pro);
             tid[0].Start();
             tid[1] = new Thread(Action.cons);
             tid[1].Start();
             Console.ReadLine();
             Console.WriteLine("Main thread done");
             */

            //Test2
            QueueClass QC = new QueueClass(16);
            var rand = new Random();
            for (int i = 0; i < 8; i = i + 2)
            {
                tid[i] = new Thread(new ParameterizedThreadStart(QC.Enqueue));
                tid[i].Start(rand.Next(0, 10));
                tid[i + 1] = new Thread(new ThreadStart(QC.Dequeue));
                tid[i + 1].Start();
            }
        }
    }
}