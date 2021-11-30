using System;

namespace LW12
{
    class Program
    {
        static void Main(string[] args)
        {
            Word word = new Word { name = "Word", type = "Program", developer = "Microsoft" };
            Sapper sapper = new Sapper { name = "Sapper", type = "Game", developer = "Microsoft" };
            
            Console.WriteLine(new string('-', 100));
            Reflector.ToFile(word, typeof(int));
            Console.WriteLine(new string('-', 100));
            Reflector.ToFile(sapper, typeof(int));
            Console.WriteLine(new string('-', 100));
            Reflector.InvokeClass(word, "LW12_INVOKE");
        }
    }
}