using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructures
{
    class MyQueue<T> where T : notnull, IComparable<T>
    {
        public LinkedList<T> List { get; }

        public MyQueue()
        {
            List = new();
        }

        public void EnQueue(T element)
        {
            List.Insert(element);
            List.HeadToTail();
        }

        public bool IsEmpty()
        {
            if (List.Head != null)
                return false;
            return true;
        }

        public Node<T>? First()
        {
            return List.Head;
        }

        public T DeQueue()
        {
            if (IsEmpty())
                return (T)Convert.ChangeType("Невозможно взять элемент, " +
                    "так как очередь пустая", typeof(T));
            var element = List.Head;
            List.DeleteNode(element);
            return element.Data;
        }

        public void Print()
        {
            List?.Print();
        }

        public void ExecuteFile(string path)
        {
            string f = File.ReadAllText(path);
            Console.WriteLine(f);

            string[] commands = f.Split();

            ExecCommands(commands);
        }

        public void ExecuteUser(string commandsStr)
        {
            string[] commands = commandsStr.Split();

            ExecCommands(commands);
        }

        public void ExecCommands(string[] commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i].Substring(0, 1);
                switch (command)
                {
                    case "1":
                        string value = commands[i].Substring(2);
                        EnQueue((T)Convert.ChangeType(value, typeof(T)));
                        Console.WriteLine($"EnQueue {value}"); break;
                    case "2": 
                        Console.WriteLine($"DeQueue {DeQueue()}"); break;
                    case "3": 
                        Console.WriteLine($"IsEmpty {IsEmpty()}"); break;
                    case "4": 
                        Console.Write("Print: "); Print(); break;
                    case "5": 
                        Console.WriteLine($"First {First()}"); break;
                    default: 
                        Console.WriteLine("Введена недоступная команда"); break;
                }
            }
        }
    }
}
