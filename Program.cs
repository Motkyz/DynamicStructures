using DynamicStructures;
using DynamicStructures.RPN;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

public class Point
{
    public double X, Y;
    public Point(double x, double y)
    {  X = x; Y = y; }
}
class Program
{
    private static int _elCount = default;
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите, что вы хотите сделать\n" +
            "1. Выполнить команды Stack (из файла)\n" +
            "2. Выполнить команды Stack (ручной ввод)\n" +
            "3. Ввести выражение для решения в постфиксной записи (из файла)\n" +
            "4. Ввести выражение для решения в постфиксной записи (ручной ввод)\n" +
            "5. Выполнить команды Queue (из файла)\n" +
            "6. Выполнить команлы Queue (ручной ввод)\n" +
            "7. Выполнить все алгоритмы со связными списками (4 часть)\n");

        
            MyStack<string> myStack = new MyStack<string>();
            MyQueue<string> myQueue = new MyQueue<string>();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": 
                    myStack.ExecuteFile("input.txt"); break;
                case "2": 
                    myStack.ExecuteUser(Console.ReadLine()); break; 
                case "3": 
                    RPN rpn = new RPN(File.ReadAllText("input1.txt"));
                    Console.WriteLine($"Выражение в инфиксном виде: {rpn.Input}");
                    Console.WriteLine($"Выражение в постфиксном виде: {rpn.Rpn}");
                    Console.WriteLine($"Ответ: {rpn.Result}");
                    break;
                case "4": 
                    rpn = new RPN(Console.ReadLine());
                    Console.WriteLine($"Выражение в инфиксном виде: {rpn.Input}");
                    Console.WriteLine($"Выражение в постфиксном виде: {rpn.Rpn}");
                    Console.WriteLine($"Ответ: {rpn.Result}");
                    break;
                case "5": 
                    myQueue.ExecuteFile("input.txt"); break; 
                case "6": 
                    myQueue.ExecuteUser(Console.ReadLine()); break;
                case "7": 
                    LinkedListDemonstartion(); break;
                default: 
                    Console.WriteLine("Такой команды нет"); Thread.Sleep(1000); Console.Clear(); break;
            }
            Console.WriteLine("\n*Enter, чтобы продолжить");
            Console.ReadLine();
            Console.Clear();
        }

        static void LinkedListDemonstartion()
        {
            var list = new DynamicStructures.LinkedList<int>();

            Console.WriteLine("Список");
            for (int i = 0; i < 20; i++)
            {
                list.Insert(i / 2);
            }
            list.Print();
            Console.WriteLine();

            Console.WriteLine("1) Перевернуть список");
            list.Reverse();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("2) Поменять head и tail местами");
            list.HeadToTail();
            list.Print();
            Console.WriteLine("И обратно");
            list.TailToHead();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("3) Колличество уникальных элементов");
            Console.WriteLine(list.UniqueNumber() + "\n");

            Console.WriteLine("4) Удалить неуникальные элементы");
            list.DeleteDuplicates();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("5) Вставить самого себя после вхождения x(5)");
            var list1 = new DynamicStructures.LinkedList<int>();
            list1.Insert(list);
            list.InsertSelf(5);
            list.Print();
            Console.WriteLine();

            Console.WriteLine("6) Вставить, не нарушая порядок (цифра 7)");
            list1.InsertOrder(7);
            list1.Print();
            Console.WriteLine();

            Console.WriteLine("7) Удалить все узлы со значением E(7)");
            list.DeleteNodes(7);
            list.Print();
            Console.WriteLine();

            Console.WriteLine("8) Вставить F(7) перед E(8)");
            list.TryInsertBefore(7, 8);
            list.TryInsertBefore(6, 20);
            list.Print();
            Console.WriteLine();

            Console.WriteLine("9) Добавить список E к списку L");
            var list2 = list.CreateCopy();
            list2.Reverse();
            list.Insert(list2);
            list.Print();
            Console.WriteLine();

            Console.WriteLine("10) Разделить список по значению");
            DynamicStructures.LinkedList<int>[] split = list.Split(1);
            Console.WriteLine("Первая часть:");
            split[0].Print();
            Console.WriteLine("Вторая часть:");
            split[1].Print();
            Console.WriteLine();

            Console.WriteLine("11) Умножить список на два");
            list.InsertSelfEnd();
            list.Print();
            Console.WriteLine();

            Console.WriteLine("12) Поменять местами элементы 5 и 9");
            list.Swap(list.Find(5), list.Find(9));
            list.Print();
            Console.WriteLine();

            Console.WriteLine("13) Обход дерева:");
            var tree = new Tree();
            Console.WriteLine("Прямой");
            Console.WriteLine(TreeTraversal.DirectPrint(tree.root));
            Console.WriteLine("Симметричный");
            Console.WriteLine(TreeTraversal.SymmetricalPrint(tree.root));
            Console.WriteLine("Обратный");
            Console.WriteLine(TreeTraversal.ReversePrint(tree.root));
        }
    }
}