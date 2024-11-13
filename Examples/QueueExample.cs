using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructures
{
    class QueueExample
    {
        public class PrinterQueue<T> : Queue<T> where T : notnull, IComparable<T>
        {
            private MyQueue<string> printQueue = new MyQueue<string>();

            public void EnqueuePrintJob(string document)
            {
                printQueue.EnQueue(document);
                Console.WriteLine($"Added to print queue: {document}");
            }

            public void Print()
            {
                if (printQueue.IsEmpty())
                {
                    string document = printQueue.DeQueue();
                    Console.WriteLine($"Printing: {document}");
                }
                else
                {
                    Console.WriteLine("Print queue is empty.");
                }
            }
        }
    }
}
