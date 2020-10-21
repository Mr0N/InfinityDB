using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{


    public class Destroyer : Creator
    {
        public void RemoveIndex(int index)
        {
            var rem = this.index[index];
            rem.remove = true;
            while (rem.next != null)
            {
                rem = rem.next;
                rem.remove = true;
            }
        }
        public void Clear()
        {
            ReadWrite(this.index.Where(x=>x.remove==true).ToList());
        }
        protected void ReadWrite(List<IndexType> list)
        {
            int read = 0;
            int write = 0;
            int pos = 0;
            while (this.length > pos)
            {
                if (CheckIsRange(pos, list))
                {
                    if (pos == 0)
                    {
                        pos++;
                        continue;
                    }
                    //write--;
                }
                else write++;

                read++;
                //-----------------------------------
                this.stream.Seek(read, SeekOrigin.Begin);
                int bytes = this.stream.ReadByte();
                ///-----------------------------------
                ////------------------------------------
                this.stream.Seek(write, SeekOrigin.Begin);
                this.stream.WriteByte((byte)bytes);
                ///--------------------------------------
                pos++;
                
            }
        }
        protected bool CheckIsRange(int index, in List<IndexType> position)
        {
            return position.Find(x => x.indexMaximum > index && x.indexMinimum <= index) != null;
        }
        //private int GetCountBytesOffset(int indexMax)
        //{
        //    int workCountMaxOffsetClear = 1;
        //    int offset = this.length - indexMax;
        //    if (countMaxOffsetClear > offset) workCountMaxOffsetClear = offset;
        //    else workCountMaxOffsetClear = countMaxOffsetClear;
        //    workCountMaxOffsetClear = workCountMaxOffsetClear > 2 ? workCountMaxOffsetClear / 2 : workCountMaxOffsetClear;
        //    return workCountMaxOffsetClear;
        //}

        //int countMaxOffsetClear;
        Stream stream;

        public Destroyer(int count, Stream stream) : base(count, stream)
        {
            //this.countMaxOffsetClear = countMaxOffsetClear;
            this.stream = stream;
        }
    }
}
