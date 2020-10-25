using Collection.RealizationEnumerator.SaveOrLoadInfo.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo
{
    public class ArrayLocal<T> where T : ISerializableObject<T>, new()
    {

        public int Count()
        {
           return this.writer.Count();
        }
        public void Add(T t)
        {
            var re = t.GetBytes();
            writer.SetInfo(ref re);
        }
        public void Update()
        {
            this.writer.Update();
        }
        public void RemoveIndex(int index)
        {
            this.writer.RemoveIndex(index);
        }
        public void Clear()
        {
            this.writer.Clear();
        }
        public T this[int index]
        {
            get 
            {
                T result = new T();
                result.SetInformation(this.writer[index]);
                return result;
            }
            set
            {
                if (value == null) throw new NullReferenceException("value == null");
                this.writer[index] = value.GetBytes();
            }
        }

        SetWrite writer;
        public ArrayLocal(string saveFile)
        {
            var result = new ObjType(saveFile, x => File.Open(x, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            writer = new SetWrite(result);
        }
    }
}
