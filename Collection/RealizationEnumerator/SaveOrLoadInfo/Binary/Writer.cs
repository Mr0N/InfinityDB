using System.Collections.Generic;
using System.IO;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class Writer
    {
        protected long length;
        protected virtual (long one_position, long two_position) WriteNew(ref byte[] array)
        {
            return WriteNew(ref array, 0, array.Length);
        }
        protected virtual (long one_position, long two_position) WriteNew(ref byte[] array, int offset, int count)
        {
            long becap = length;
            stream.Seek(length, SeekOrigin.Begin);
            stream.Write(array, offset, count);
            length += array.Length;
            array = null;
            return (becap, length);
        }
        protected virtual (long one_position, long two_position) Write(ref byte[] array, int offsetArray, int countArray, long offsetSeek)
        {
            stream.Seek(offsetSeek, SeekOrigin.Begin);
            if (countArray > array.Length) countArray = array.Length;
            stream.Write(array, offsetArray, countArray);
            array = null;
            return (offsetSeek, stream.Position);
        }
        protected virtual byte[] Read(long one, long two)
        {
            byte[] bytes = new byte[one-two];
            stream.Seek(two, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            return bytes;
        }

        protected virtual  void ReadToWrite(List<IndexType> list)
        {

        }
        protected Stream stream { get => this.objType.stream; }
        protected ObjType objType;
        protected Writer(ObjType obj)
        {
            this.objType = obj;
        }
    }
}
