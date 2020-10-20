using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class Creator : Create
    {
        public byte[] GetInfo(int index)
        {
            if (index < 0) throw new NotSupportedException("index < 0");
            var type = this.index[index];
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                while ((result = this.Read(type.indexMaximum, type.indexMinimum)) != null)
                {
                    string res = Encoding.UTF8.GetString(result);
                    memoryStream.Write(result, 0, result.Length);
                    if (type.next == null)
                        break;
                    type = type.next;
                }
                return memoryStream.ToArray();
            }

        }
        public byte[] GetInfoBytes(int one,int two)
        {
            return this.Read(two, one - two);
        }
        public void SetInfo(byte[] info)
        {
            base.WriteInfo(info);
        }
        public Creator(int count, Stream stream) : base(stream)
        {

        }
    }
}
