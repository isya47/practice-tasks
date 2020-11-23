using System;
using System.Threading;

namespace Threadings
{
    class Program
    {
        public static Thread[] tid = new Thread[2];
        static void Main(string[] args)
        {
            tid[0] = new Thread(Action.pro);
            tid[0].Start();
            tid[1] = new Thread(Action.cons);
            tid[1].Start();
            Console.ReadLine();
            Console.WriteLine("Main thread done");
        }
    }

    class Action
    {
        private static Mutex mutexlock = new Mutex();
        // Счетчик последней прочитанный индекс
        private static int _consout;
        // Счетчик последней записанный индекс
        private static int _proin;
        // Буфер
        public static int[] mess = new int[8];

        public static void pro()
        {
            var rand = new Random();
            while (true)
            {
                mutexlock.WaitOne();
                mess[_proin] = rand.Next(0, 11);
                Console.WriteLine($"Produced {mess[_proin]}");
                Thread.Sleep(3000);
                
                _proin++;
                _proin %= 8;
                mutexlock.ReleaseMutex();
            }
        }

        public static void cons()
        {
            while (mess[_consout] != 5)
            {
                mutexlock.WaitOne();
                Console.WriteLine($"Consumed {mess[_consout]}");
                Thread.Sleep(3000);
                _consout++;
                _consout %= 8;
                mutexlock.ReleaseMutex();
            }

        }
    }

}