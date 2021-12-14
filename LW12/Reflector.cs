using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LW12
{
    public class Reflector
    {
        // Имя сборки, в которой определен класс
        public static Assembly AssName(object obj)
        {
            Type type = obj.GetType();     // это прописываем всегда, чтобы работать с рефлексией и System.Type
            Assembly ass = Assembly.GetAssembly(type);
            Console.WriteLine("Класс " + type.FullName + " определен в сборке " + ass.FullName);
            return ass;
        }
        
        // Есть ли публичные конструкторы
        public static ConstructorInfo PublicConstruct(object obj)
        {
            Type type = obj.GetType();
            ConstructorInfo[] constrArray = type.GetConstructors();
            foreach (ConstructorInfo constructor in constrArray)
            {
                if (!constrArray.Equals(null))
                {
                    Console.WriteLine("\nКонструктор: " + constructor);
                    return constructor;
                }
                else
                {
                    Console.WriteLine("В классе нет публичных классов!");
                }
            }

            return constrArray[0];
        }

        // Возвращает публичные методы
        public static MethodInfo[] Methods(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] methods = type.GetMethods();
            Console.WriteLine("\nМетоды класса: ");
            foreach (MethodInfo method in methods)
            {
                if (!methods.Equals(null))
                {
                    Console.WriteLine($"<-- {method.ReturnType.Name} --- {method.Name}()");
                }
            }

            return methods;
        }
        
        // Возвращает поля и свойства
        public static PropertyInfo[] Fields(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();
            
            Console.WriteLine("\nПоля и свойства класса: ");
            foreach (FieldInfo field in fields)
            {
                if (!field.Equals(null))
                {
                    Console.WriteLine("Поле " + field.Name);
                }
                else
                {
                    Console.WriteLine("Поля отсутствуют!");
                }
            }

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (!properties.Equals(null))
                {
                    Console.WriteLine("Свойство: " + property.PropertyType + "---" + property.Name);
                }
                else
                {
                    Console.WriteLine("Свойства отсутствуют!");
                }
            }

            return properties;
        }
        
        // Возвращает интерфейсы
        public static Type[] Interfaces(object obj)
        {
            Type type = obj.GetType();
            Type[] interfaces = type.GetInterfaces();
            Console.WriteLine("\nИнтерфейсы: ");
            foreach (Type interf in interfaces)
            {
                Console.WriteLine(interf.Name);
            }

            return interfaces;
        }
        
        // Получает методы с задаваемым возвращаемым параметром в задаваемом классе
        public static dynamic GetSomeMethods(object obj, Type param)
        {
            Type type = obj.GetType();
            var methods = type.GetMethods();
            var result = methods.Where(a => a.GetParameters().Where(t => t.ParameterType == param).Count() != 0);
            
            Console.WriteLine($"\nМетоды с параметром {param}: ");
            foreach (var meth in result)
            {
                Console.WriteLine(meth.Name);
            }

            return result;
        }
        
        // Всё то же самое, что и выше, но записываем в файл, а не в консоль
        public static void ToFile(object obj, Type param)
        {
            Type type = obj.GetType();
            string filePath = @"D:\Универ 2 курс\Университет 3 семестр\ООП\LW12\info.txt";
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default))
            {
                // Имя сборки
                sw.WriteLine("Класс " + type.FullName + " определен в сборке " + AssName(obj).FullName);
                // Контрукторы
                sw.WriteLine("\nКонструкторы: " + PublicConstruct(obj));
                // Методы
                sw.WriteLine("\nМетоды: ");
                foreach (MethodInfo method in Methods(obj))
                    sw.WriteLine("--> " + method.ReturnType.Name + "\t\t" + method.Name + "()");
                // Свойства
                sw.WriteLine("\nСвойства:");
                foreach (PropertyInfo property in Fields(obj))
                    sw.WriteLine(property.PropertyType + "\t" + property.Name);
                // Интерфейсы
                sw.WriteLine("\nИнтерфейсы:");
                foreach (Type inter in Interfaces(obj))
                    sw.WriteLine(inter.Name);
                // Определенные методы
                sw.WriteLine($"\nМетоды с параметром {param}:");
                foreach (var res in GetSomeMethods(obj, param))
                    sw.WriteLine(res.Name);
                // Task 2
                sw.WriteLine("\nTask 2:");
                sw.WriteLine("Parameters");
                sw.WriteLine("Sapper Program");
            }
        }

        // Метод Invoke
        public static void InvokeClass(object obj, string methodName)
        {
            Type type = obj.GetType();
            string filePath = @"D:\Универ 2 курс\Университет 3 семестр\ООП\LW12\params.txt";
            string fileInf = "";

            List<string> paramsList = new List<string>();
            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string symbol = sr.ReadLine();
                    paramsList.Add(symbol);
                }
            }
            
            var method = type.GetMethod(methodName);
            string stringParam1 = "";
            string stringParam2 = "";
            stringParam1 = paramsList.First();
            stringParam2 = paramsList.Last();


            object objWord = Activator.CreateInstance(type);
            if (paramsList.Count() != 0)
                method.Invoke(objWord, new object[] { stringParam1, stringParam2 });
            else
                method.Invoke(objWord, new object[] { });
        }
        
        // Cоздает объект переданного типа и возвращает
        // его пользователю
        public static object CreateObj(object obj)
        {
            Type type = obj.GetType();
            object result = Activator.CreateInstance(type);
            return result;
        }
        /*
        Type type = obj.GetType();
        string filePath = @"D:\Универ 2 курс\Университет 3 семестр\ООП\LW12\info.txt";
        string fileInf = "";
        string strParams = "parameters";

            using (StreamReader sr = new StreamReader(filePath, Encoding.Default))
        fileInf = sr.ReadToEnd();

        int index = fileInf.IndexOf(strParams);

        List<string> paramsList = new List<string>();
        string currentParam = "";
            for (int i = index + strParams.Length + 2; i < fileInf.Length; i++)
        {
            if (fileInf[i] == ' ' || fileInf[i] == '\n')
            {
                paramsList.Add(currentParam);
                currentParam = "";
            }
            else
                currentParam += fileInf[i];
        }

        var method = type.GetMethod(methodName);
        string stringParam1 = "";
        string stringParam2 = "";
        stringParam1 = paramsList.First();
        stringParam2 = paramsList.Last();

        object objWord = Activator.CreateInstance(type);
            if (paramsList.Count() != 0)
        method.Invoke(objWord, new object[] { stringParam1, stringParam2 });
        else
        method.Invoke(objWord, new object[] { });*/
    }
}