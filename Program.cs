using System;
using HelloWorld.first;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            First first = new First();
            object second = new First();
            Console.WriteLine(first.GetType());
            first.A = 5;
            Console.WriteLine(first.A);
            
            Console.WriteLine(second.GetType());
            Console.WriteLine("Hello World!");
        }
    }
}
