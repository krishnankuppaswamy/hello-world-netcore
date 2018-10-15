using System;

namespace hello_world_netcore
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args?.Length > 0)
            {
                Console.WriteLine($"Hello World! - {args[0]}");
            }
            else
                Console.WriteLine("Hello World!");
        }
    }
}
