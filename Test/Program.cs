using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Collection.RealizationEnumerator.SaveOrLoadInfo.Binary;
using Collection.RealizationEnumerator.SaveOrLoadInfo;
using System.IO;
using System.IO.Pipes;
using Microsoft.WindowsAPICodePack;
using System.Drawing;
using System.Threading;
using Collection;
using System.Diagnostics;

namespace Test
{
    class Test : ISerializableObject<Test>
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(ToBase64(this.Name) +"|"+ToBase64(this.Surname));
        }
        public Test SetInformation(byte[] information)
        {
           var res =  Encoding.UTF8.GetString(information).Split('|');
            this.Name = FromBase64(res[0]);
            this.Surname = FromBase64(res[1]);
            return this;
        }
        private string ToBase64(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }
        private string FromBase64(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
        public Test()
        {
        }
    }
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
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Stopwatch watch = new Stopwatch();
            LocalList<Test> arrayLocal = new LocalList<Test>("baza1234");
            watch.Start();
            for (int i = 0; i < 50000; i++)
            {
                arrayLocal.Add(new Test() { Name="MyName",Surname=i+"NameNot" });
            }
            watch.Stop();
            arrayLocal.CreateCount();
            arrayLocal.Update();
            Console.WriteLine("Second:"+watch.ElapsedMilliseconds/1000);
            watch.Reset();
            watch.Start();
            var suma = arrayLocal;
            var result = arrayLocal.Where(x => x.Surname.StartsWith("1"))
                .Select(x => x.Surname);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Suma:"+suma);
            watch.Stop();
            Console.WriteLine("Секунд Echo="+watch.ElapsedMilliseconds/1000);
            Console.WriteLine("OK");
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
