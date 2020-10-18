using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
   public class SetWrite : Info
    {
        public override byte[] this[int index]
        {
            get => base[index];
            set => Set(index, value);
        }
        private void Set(int index, byte[] bytes)
        {
            
            int ind = this.GetIlusionIndex(index);
            var obj = this.index[ind];
            int valBytes = (int)(obj.indexMin - obj.indexMax);
            if (valBytes == bytes.Length)//Якщо розмір байтів не помінявся
            {
                this.Write(bytes, 0, bytes.Length, obj.indexMin);
            }
            else if (bytes.Length < valBytes)//Якщо кількість байтів зменшилася
            {
                var result = this.Write(bytes, 0, bytes.Length, obj.indexMax);
                this.index.RemoveAt(ind);
                this.index.Add(new IndexType(result.one_position, result.two_position));
                this.index.Add(new IndexType(result.two_position, obj.indexMin, true));//Видаляєм елемент пам'яті
            }
            else if (valBytes < bytes.Length)//Якщо кількість байтів збільшилася
            {
                //int maxBig = bytes.Length - valBytes;
                //var resultWrite = this.Write(bytes, 0, maxBig, obj.indexMax);
                //var writeAdd = this.WriteNew(bytes, maxBig, bytes.Length - maxBig);
                //this.index.Add(new IndexType(resultWrite.one_position, resultWrite.two_position));
                //this.index.Add(new IndexType(writeAdd.one_position, writeAdd.two_position));
                //this.index.RemoveAt(ind);
            }
        }
        public SetWrite(int count, Stream stream)
            : base(count, stream)
        {

        }
    }
}
