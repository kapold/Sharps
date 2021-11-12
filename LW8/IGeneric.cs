namespace LW4
{
    public interface IGeneric<T>
    {
        public void Add(T a);
        public void Delete(T a);
        public void View();

        public void WriteFile();
        public void ReadFile();
    }
}