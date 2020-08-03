using System;
using System.Collections.Generic;
using System.Threading;

namespace MonitorQueue
{
    public class QueueClass
    {
        Queue<int> q;
        static object locker = new object();
        private readonly int _capacity;
        
        public QueueClass(int capacity)
        {
            _capacity = capacity;
            q = new Queue<int>(_capacity);
        }
        
        public void Enqueue(object passedElement)
        {
            var element = (int) passedElement;
            try
            {
                Monitor.Enter(locker);
                
                if (q.Count >= _capacity)
                {
                    Monitor.Wait(locker);
                }
                else if (q.Count < _capacity)
                {
                    Monitor.Pulse(locker);
                    q.Enqueue(element);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
        public void Dequeue()
        {
            try
            {
                while (true)
                {
                    Monitor.Enter(locker);
                    if (q.Count == 0)
                    {
                        Monitor.Wait(locker);
                    }
                    else if (q.Count > 0)
                    {
                        Monitor.Pulse(locker);
                        Console.WriteLine(q.Dequeue());
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
    }
    

}