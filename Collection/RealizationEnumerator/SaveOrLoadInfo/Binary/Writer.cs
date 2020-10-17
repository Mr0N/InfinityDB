using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class Writer
    {
        protected virtual long Write(byte[] array)
        {
            stream.Write(array, 0, array.Length);
            stream.Flush();
            return stream.Position;
        }
        protected virtual byte[] Read(long position, long count)
        {
            byte[] bytes = new byte[count];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, (int)position, bytes.Length);
            return bytes;
        }
        Stream stream;
        protected Writer(Stream stream)
        {
            this.stream = stream;
        }
    }
}
