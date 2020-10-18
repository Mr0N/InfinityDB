﻿using System;
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
            string res = "1234567890|";
            var bytes = Encoding.UTF8.GetBytes(res);
            var stream = File.Open("save", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Info creator = new Info(10, stream);
            for (int i = 0; i < 10; i++)
            {
                creator.SetInfo(GetByteToString((res+i)));
            }
            creator.RemoveIndex(3);
            creator.RemoveIndex(6);
            int count = creator.Count();
            for (int i = 0; i < count; i++)
            {
                var result = creator[i];
               var save = GetString(result);
               Console.WriteLine(save);
            }
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
