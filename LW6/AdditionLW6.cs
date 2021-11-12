using System;

namespace LW5
{
    public partial class Developer
    {
        public string subDeveloper { set; get; }

        public void SubDev()
        {
            Console.WriteLine($"SubDev is {subDeveloper}");
        }
    }
}