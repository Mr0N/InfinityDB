using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class Writer
    {
        protected int length;
        protected virtual (int one_position, int two_position) WriteNew(byte[] array)
        {
            return WriteNew(array, 0, array.Length);
        }
        protected virtual (int one_position, int two_position) WriteNew(byte[] array, int offset, int count)
        {
            int becap = length;
            stream.Seek(length, SeekOrigin.Begin);
            stream.Write(array, offset, count);
            length += array.Length;
            stream.Flush();
            return (becap, length);
        }
        protected virtual (int one_position, int two_position) Write(byte[] array, int offsetArray, int countArray, int offsetSeek)
        {
            stream.Seek(offsetSeek, SeekOrigin.Begin);
            if (countArray > array.Length) countArray = array.Length;
            stream.Write(array, offsetArray, countArray);
            return (offsetSeek, (int)stream.Position);
        }
        protected virtual byte[] Read(int one, int two)
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
