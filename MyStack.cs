using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructures
{
    public class MyStack<T> where T : notnull, IComparable<T>
    {
        public LinkedList<T> List { get; }
        public int Count = 0;
        public MyStack()
        {
            List = new();
        }

        public bool IsEmpty()
        {
            if (List.Head != null)
                return false;
            return true;
        }

        public void Push(T element)
        {
            List.Insert(element);
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty())
                return (T)Convert.ChangeType("Невозможно взять элемент, " +
                    "так как стек пустой", typeof(T));
            var element = List.Head;
            List.DeleteNode(element!);
            Count--;
            return element.Data;
        }

        public Node<T>? Top()
        {
            return List.Head;
        }

        public void Print()
        {
            List.Print();
        }

        public void ExecuteFile(string path)
        {
            path = "..\\..\\..\\files\\input.txt";
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
                        Push((T)Convert.ChangeType(value, typeof(T)));
                        Console.WriteLine($"Push {value}"); break;
                    case "2": 
                        Console.WriteLine($"Pop {Pop()}"); break;
                    case "3": 
                        Console.WriteLine($"Top {Top()}"); break;
                    case "4": 
                        Console.WriteLine($"IsEmpty {IsEmpty()}"); break;
                    case "5": 
                        Console.Write("Print: "); Print(); break;
                    default: 
                        Console.WriteLine("Введена недоступная команда"); break;
                }
            }
        }
    }
}
