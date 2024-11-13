using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructures.Examples
{
    class StackExample
    {
        static void mein()
        {
            try
            {
                // Вызываем некоторые методы, чтобы создать стек вызовов
                Method1();
            }
            catch (Exception ex)
            {
                // Получаем стек вызовов при возникновении исключения
                string stackTrace = ex.StackTrace;

                // Выводим стек вызовов
                Console.WriteLine("StackTrace:\n" + stackTrace);
            }
        }

        static void Method1()
        {
            Method2();
        }

        static void Method2()
        {
            Method3();
        }

        static void Method3()
        {
            // Генерируем исключение DivideByZero
            // int result = 5 / 0;
        }
    }
}
