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
        public string text { set; get; }
        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public Test SetInformation(byte[] information)
        {
            this.text = Encoding.UTF8.GetString(information);
            return this;
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
            Stopwatch watch = new Stopwatch();
            LocalList<Test> arrayLocal = new LocalList<Test>("save234");
            watch.Start();
            for (int i = 0; i < 100000; i++)
            {
                arrayLocal.Add(new Test() { text = i.ToString() }) ;
            }
            arrayLocal.CreateCount();
            arrayLocal.Update();
            watch.Stop();
            Console.WriteLine("Add="+watch.ElapsedMilliseconds);
            watch.Reset();
            watch.Start();
            string res = "";
            int countIteration = 0;
            int becap = 0;
            foreach (var item in arrayLocal)
            {
                countIteration++;
                if (countIteration > (becap+1000))
                {
                    Console.WriteLine(countIteration);
                    becap = countIteration;
                }
                res = item.text;
                //Console.WriteLine(res);
            }
            watch.Stop();
            Console.WriteLine("Echo="+watch.ElapsedMilliseconds);
            Console.WriteLine("OK");
            Console.ReadKey();
            //string res = "";
            //var bytes = Encoding.UTF8.GetBytes(res);
            //File.Delete("save");
            //var result = new ObjType("save", x => File.Open(x, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            //SetWrite creator = new SetWrite(result);
            //for (int i = 0; i < 10; i++)
            //{
            //    creator.SetInfo(GetByteToString((res + i)));
            //}
            //creator.RemoveIndex(5);
            //creator.RemoveIndex(3);
            //creator.Clear();
            //creator.SetInfo(GetByteToString("New"));
            //result.stream.Dispose();
            //string resZ = File.ReadAllText("save");
            //Console.WriteLine(resZ);
            //Console.WriteLine("OK");
            //Console.ReadKey();
            //while (true)
            //{
            //    Console.WriteLine("Index");
            //    int index = int.Parse(Console.ReadLine());
            //    Console.WriteLine("String:");
            //    creator[index] = GetByteToString(Console.ReadLine());
            //    Write(creator);
            //}
            //Console.ReadKey();
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
