using System;
using System.Collections.Generic;
using System.Threading;

namespace MonitorQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueClass QC = new QueueClass(10);
            var enqueueThread = new Thread(new ParameterizedThreadStart(QC.Enqueue));
            enqueueThread.Start(5);
            var dequeueThread = new Thread(new ThreadStart(QC.Dequeue));
            dequeueThread.Start();

        }
    }
}