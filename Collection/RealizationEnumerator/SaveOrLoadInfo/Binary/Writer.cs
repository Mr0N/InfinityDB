using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class Writer
    {
        long length;
        protected virtual long Write(byte[] array)
        {
            stream.Seek(length, SeekOrigin.Begin);
            stream.Write(array, 0, array.Length);
            length += array.Length;
            stream.Flush();
            return stream.Position;
        }
        protected virtual byte[] Read(long position, long count)
        {
            byte[] bytes = new byte[count];
            stream.Seek(position, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            return bytes;
        }
        Stream stream;
        protected Writer(Stream stream)
        {
            this.stream = stream;
        }
    }
}
