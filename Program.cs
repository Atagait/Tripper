using System;

namespace Tripping
{
    class Program
    {
        static void Main(string[] args)
        {
            var Tripping = new Tripping();
            string Tripcode = Tripping.Tripcode("AAAAAAA");
            Console.WriteLine(Tripcode);
        }
    }
}
