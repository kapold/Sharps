namespace LW9
{
    public static class String
    {
        // Удалить все знаки препинания
        public static string RemoveStr(string str)
        {
            str = str.Replace(".", string.Empty);
            str = str.Replace(",", string.Empty);
            str = str.Replace("!", string.Empty);
            str = str.Replace("?", string.Empty);
            return str;
        }
        // Добавление строки
        public static string AddToString(string str)
        {
            return str += "!";
        }
        // Удаление пробелов
        public static string DeleteSpaces(string str)
        {
            str = str.Replace(" ", "");
            return str;
        }
        // Замена на заглавные
        public static string Upper(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], char.ToUpper(str[i]));
            }
            return str;
        }
        // Замена на строчные
        public static string Lower(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], char.ToLower(str[i]));
            }
            return str;
        }
    }
}