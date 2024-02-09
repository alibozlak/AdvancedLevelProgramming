namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.R)
                {
                    throw new CustomException("R harfine bastınız..!");
                }
                else
                {
                    Console.WriteLine(key.Key);
                }
            }
        }
    }

    class CustomException : Exception
    {
        public CustomException() : base("Custom message....")
        {
        }

        public CustomException(string message) : base(message)
        {
        }
    }
}
