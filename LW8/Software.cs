namespace LW4
{
    public class Software
    {
        public string name;

        public Software(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}