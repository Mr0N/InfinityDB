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
            string res = "1234567890|23456789";
            var bytes = Encoding.UTF8.GetBytes(res);
            var stream = File.Open("save", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            SetWrite creator = new SetWrite(10, stream);
            for (int i = 0; i < 10; i++)
            {
                creator.SetInfo(GetByteToString((res+i)));
            }
            WriteLine(creator);
            creator[4] = GetByteToString("111111111111111111111111");
            creator[4] = GetByteToString("user");
            creator[4] = GetByteToString("12345");
            Console.WriteLine("Res");
            WriteLine(creator);
            Console.WriteLine("OK");
            Console.ReadKey();
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
