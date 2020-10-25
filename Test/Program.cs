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
    class Test : IDisposable,ISerializableObject<Test>
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public byte[] GetBytes()
        {
            var bytes = ToBytes(this.Name);
            var SurnameBytes = ToBytes(this.Surname);
            byte[] result = new byte[bytes.Length + SurnameBytes.Length];
            Join(ref result, in bytes, SurnameBytes);
            bytes = null;
            SurnameBytes = null;
            return result;
        }
        private void Join(ref byte[] result, in byte[] one, in byte[] two)
        {
            int count = one.Length + two.Length;
            int pos = 0;
            for (int z = 0; z < one.Length; z++)
            {
                result[pos] = one[z];
                pos++;
            }
            for (int y = 0; y < two.Length; y++)
            {
                result[pos] = two[y];
                pos++;
            }
        }
        private byte[] ToBytes(string text)
        {
            var bytes =  Encoding.UTF8.GetBytes(text);
            var result = BitConverter.GetBytes(text.Length);
            byte[] r = new byte[bytes.Length + result.Length];
            Join(ref r, result, bytes);
            bytes = null;
            result = null;
            return r;
        } 
        public Test SetInformation(byte[] information)
        {
            int count = BitConverter.ToInt32(information, 0);
            this.Name = Encoding.UTF8.GetString(information, 4, count);
            int newCount = BitConverter.ToInt32(information, count+4);
            this.Surname = Encoding.UTF8.GetString(information, count + 8, newCount);
            return this;
        }
        public void Dispose()
        {
            this.Name = null;
            this.Surname = null;
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
            for (int i = 0; i < 500000; i++)
            {
                var test = new Test() { Name = new string('-',5000), Surname = i.ToString() };
                arrayLocal.Add(test);
                test = null;
            }
            watch.Stop();
            arrayLocal.CreateCount();
            arrayLocal.Update();
            Console.WriteLine("Записування:" + watch.ElapsedMilliseconds);
            watch.Reset();
            watch.Start();
            var result = arrayLocal.Sum(x => (x.Name.Length - 4f)).ToString();
            watch.Stop();
            Console.WriteLine("Результат:" + result);
            Console.WriteLine("Читання=" + watch.ElapsedMilliseconds);
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
