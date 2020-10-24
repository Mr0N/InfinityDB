using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection.RealizationEnumerator.SaveOrLoadInfo.Binary;
using System.IO;

namespace TestCollection
{
    public class Function
    {
        protected string GetString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
        protected byte[] GetByteToString(string result)
        {
            return Encoding.UTF8.GetBytes(result);
        }
        protected void RemoveFile()
        {
           if (File.Exists(name_file)) File.Delete(name_file);
        }
        protected string name_file = "save";
        protected (SetWrite set, ObjType obj) CreateObj()
        {
            var result = new ObjType(name_file, x => File.Open(x, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            return (new SetWrite(result),result);
        }
    }
}
