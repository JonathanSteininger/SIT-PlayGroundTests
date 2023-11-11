using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensiontesting
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Temp temp = new Temp(0, 1, 2, "jono");
            Console.WriteLine($"\n{temp}");
            temp.Forward();
            Console.WriteLine($"\n{temp}");
            temp = temp.Forward(1);
            Console.WriteLine($"\n{temp}");

            Console.ReadLine();
        }

        static void Change2(ref string temp)
        {
            temp = "Hello";
        }
        static void Change(ref Temp temp)
        {
            temp = new Temp(1, 2, 3, "ben");
        }
    }

    /// <summary>
    /// Extensions allow you to add built in methods to any Type. 
    /// 
    /// Value Types like Struct will copy data through paramaters, need to return the object. 
    /// 
    /// reference Types like Classes will send theire reference, any changes will always apply
    /// </summary>
    /// 


    //editing a struct
    public static class MyStringExtensions
    {
        public static string Funny(this string _string, bool offset)
        {
            StringBuilder sb = new StringBuilder();
            bool sw = !offset;
            foreach (char c in _string.ToCharArray())
            {
                sb.Append(sw ? char.ToUpper(c) : char.ToLower(c));
                sw = !sw;
            }
            return sb.ToString();
        }
    }

    //editing a class
    public static class TempExtenstion
    {
        
        public static Temp Forward(this Temp temp) => temp.Forward(1);
        public static Temp Forward(this Temp temp, int distance) {
            temp.z += distance;
            return temp;
        }
    }
    public class rotation
    {

    }

    public class Temp
    {
        public int x, y, z;
        public string id;

        public Temp(int x, int y, int z, string id) => (this.x, this.y, this.z, this.id) = (x, y, z, id);

        public override string ToString() => $"{x},{y},{z},{id}";
    }
}
