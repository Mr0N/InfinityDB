using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo
{
    public class ArrayLocal<T>
    {
        public void AddNewIndex(int count)
        {

        }
        public byte[] this[int index] { get => new byte[2]; }
        int maxElements;
        string saveFile;
        Stream infoStream;
        BigInteger[] integer;
        private void CreateStream(string file)
        {
            this.infoStream = File.Open(file, FileMode.Create, FileAccess.ReadWrite);
        }
        private void Write()
        {
            this.infoStream.Write(null, 0, 0);
        }
        public ArrayLocal(int maxElements,string saveFile)
        {
            BigInteger big = 2134;
            this.maxElements = maxElements;
            this.saveFile = saveFile;
        }
    }
}
