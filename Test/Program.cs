using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Collection.RealizationEnumerator.SaveOrLoadInfo.Binary;
using Collection.RealizationEnumerator.SaveOrLoadInfo;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string res = "1234567890";
            res = string.Join("", Enumerable.Repeat(res, 300).SelectMany(y => y));
            var bytes = Encoding.UTF8.GetBytes(res);
            var stream = File.Open("save", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Creator creator = new Creator(10, stream);
            creator.SetInfo(bytes);
            var result = creator.GetInfo(0);
             string x = Encoding.UTF8.GetString(result);
            Console.WriteLine(x);
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
