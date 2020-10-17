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
            long result = this.index[index];
            long resultTwo = /*index == 0 ? 0 : */this.index[index - 1];
            return this.Read(resultTwo, result-resultTwo);
        }
        public void SetInfo(byte[] info)
        {
            this.Write(info);
        }
        public long Count { get => this.index.Count; }
        public Creator(int count, Stream stream) : base(stream)
        {

        }
    }
}
