using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class Create : Writer
    {
        protected override byte[] Read(long position, long count)
        {
            return base.Read(position, count);
        }
        protected override long Write(byte[] array)
        {
            long result = base.Write(array);
            index.Add(new IndexType(result));
            return result;
        }
        protected List<IndexType> index { private set; get; }
        protected Create(Stream stream) : base(stream)
        {
            this.index = new List<IndexType>();
        }
    }
}
