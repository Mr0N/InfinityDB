using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Collection.RealizationEnumerator.SaveOrLoadInfo.Binary;
using Collection.RealizationEnumerator.SaveOrLoadInfo;
using System.IO;
using System.Drawing;

namespace Test
{
    class Program
    {
        static string GetString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
        static byte[] GetByteToString(string result)
        {
            return Encoding.UTF8.GetBytes(result);
        }
        static void Main(string[] args)
        {
            string res = "";
            var bytes = Encoding.UTF8.GetBytes(res);
            File.Delete("save");
            var stream = File.Open("save", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var becap = File.Open("save1", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SetWrite creator = new SetWrite(10, stream, becap);
            for (int i = 0; i < 10; i++)
            {
                creator.SetInfo(GetByteToString((res+i)));
            }
            creator.RemoveIndex(5);
            creator.RemoveIndex(3);
            while (true)
            {
                Console.WriteLine("Index");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine("String:");
                creator[index] = GetByteToString(Console.ReadLine());
                Write(creator);
            }
            Console.ReadKey();
        }
        private static void Write(in SetWrite set)
        {
            Console.WriteLine(new string('-', 20));
            WriteLine(set);
            Console.WriteLine(new string('-', 20));
        }
        private static void WriteLine(SetWrite set)
        {
            int count = set.Count();
            for (int i = 0; i < count; i++)
            {
                var result = set[i];
                var save = GetString(result);
                Console.WriteLine(save);
            }
        }
    }
}
