using System.Runtime.Serialization.Json;

namespace RefReturnAndRefLocal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Remember ref keyword :
            int _a = 5;
            ChangeValueWithRefKeyword(ref _a);
            Console.WriteLine(_a);  //6

            //ref return :
            int _b = 5;
            /*
            ref int referenceOf_b = ref AMethod(ref _b);
            ChangeValueWithRefKeyword(ref referenceOf_b);
            */
            ChangeValueWithRefKeyword(ref AMethod(ref _b));
            Console.WriteLine(_b);  //126

            Console.WriteLine("\n---- Ref Local ------");

            int a = 12;
            ref int b = ref a;
            b = 23;
            Console.WriteLine(a);   //23
        }

        static void ChangeValueWithRefKeyword(ref int number)
        {
            number++;
            Console.WriteLine("number changed");
        }

        static ref int AMethod(ref int number)
        {
            number = 125;
            return ref number;
        }
    }
}
