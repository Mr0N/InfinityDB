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
            int lengthBytes = (int)(obj.indexMaximum - obj.indexMinimum);
            if (lengthBytes == bytes.Length)//Якщо розмір байтів не помінявся
            {
                this.Write(bytes, 0, bytes.Length, obj.indexMaximum);//Повторний записа байтів, на то саме місце
            }
            else if (bytes.Length < lengthBytes)//Якщо кількість байтів зменшилася
            {
                var result = this.Write(bytes, 0, bytes.Length, obj.indexMinimum);
                this.index.RemoveAt(ind);
                var x = new IndexType(result.one_position, result.two_position);
                this.index.Add(x);
                this.index.Add(new IndexType(result.two_position, obj.indexMaximum, true));//Видаляєм елемент пам'яті
                this.index.Insert(ind, x);
            }
            else if (lengthBytes < bytes.Length)//Якщо кількість байтів збільшилася
            {
                //int maxLength = bytes.Length - lengthBytes;//Кількість байтів яку треба записати в комірці
                var resultWrite = this.Write(bytes, 0, lengthBytes, obj.indexMinimum);
                var result_two = this.WriteNew(bytes, lengthBytes, bytes.Length- lengthBytes);
                this.index.RemoveAt(ind);
                var indexZ = new IndexType(result_two.one_position, result_two.two_position, block: true);
                var indexType = new IndexType(resultWrite.one_position, resultWrite.two_position);
                indexType.next = indexZ;
                this.index.Add(indexZ);
                this.index.Insert(ind, indexType);
            }
        }
        public SetWrite(int count, ObjType objType)
            : base(count, objType)
        {

        }
    }
}
