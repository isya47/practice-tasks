using System.Collections.Generic;

namespace MonitorQueue
{
    public class QueueClass
    {
        Queue<int> q;
        public QueueClass(int capacity)
        {
            q = new Queue<int>(capacity);
        }
        
        public void Enqueue(int element)
        {
            
            lock (q)
            {
                q.Enqueue(element);
                System.Threading.Monitor.Pulse(q);
            }
        }

        public int Dequeue()
        {
            lock (q)
            {
                while (true)
                {
                    if (q.Count > 0)
                    {
                        return q.Dequeue();
                    }
                    System.Threading.Monitor.Wait(q);
                }
            }
        }
    }
    
}