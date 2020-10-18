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
            return this.Read(this.index[index].indexMin, this.index[index].indexMax);
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
