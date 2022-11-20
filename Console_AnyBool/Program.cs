using System;
using System.Linq;

namespace ConsoleAnyBool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("False =");
            Console.WriteLine(AnyBool(""));
            Console.WriteLine(AnyBool("False"));
            Console.WriteLine(AnyBool("0"));
            Console.WriteLine(AnyBool(0));
            Console.WriteLine(AnyBool(null));
            Console.WriteLine(AnyBool(new { }));
            Console.WriteLine(AnyBool(new { a = 1, b = "x" }));

            Console.WriteLine();

            Console.WriteLine("True =");
            Console.WriteLine(AnyBool("1"));
            Console.WriteLine(AnyBool("hello"));
            Console.WriteLine(AnyBool("true"));
            Console.WriteLine(AnyBool(99));
            Console.WriteLine(AnyBool(100.001));

            Console.ReadKey();
        }

        // Получение BOOL в зависимости от содержимого
        static public bool AnyBool(dynamic Value)
        {
            try
            {
                // ничего? тогда false
                if (Value == null) return false;

                // строка?
                if (Value.GetType() == typeof(System.String))
                {
                    string[] myFalse = { "FALSE" , "NO" , "ЛОЖЬ" , "0"};
                    string str_Value = Convert.ToString(Value);
                    return (String.IsNullOrWhiteSpace(str_Value) || myFalse.Contains(str_Value.ToUpper())) ? false : true;
                }

                // если ничего из ранее описанного не подошло
                return Convert.ToBoolean(Value);

            }
            catch
            {
                return false;
            }
        }

    }
}
