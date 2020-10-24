using Collection.RealizationEnumerator.SaveOrLoadInfo;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
 
    public class LocalList<T> :IList<T>,IEnumerator<T> where T : class, ISerializableObject<T>,new()
    {
        public LocalList()
        {
            CreateCount(); 
        }
        public T Current => 
            this.array[count_iteration];

        object IEnumerator.Current => 
            this.array[count_iteration];

        public int Count => count;
        int count = 0;
        public bool IsReadOnly => true;

        public T this[int index] { get => array[index]; set => array[index] = value; }

        ArrayLocal<T> array;
        public LocalList(string file="save")
        {
            Reset();
            this.array = new ArrayLocal<T>(file);
        }
        int count_iteration;
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }

        public bool MoveNext()
        {
           
            count_iteration++;
            if (this.Count <= count_iteration) 
                return false;
            return true;
        }

        public void Reset()
        {
            count_iteration = -1;
        }

        public int IndexOf(T item)
        {
            int count = this.array.Count();
            for (int i = 0; i < count; i++)
            {
                if (this.array[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
           // CreateCount();
            this.array.RemoveIndex(index);
        }

        public void Add(T item)
        {
         //   CreateCount();
            this.array.Add(item);
        }
        public void Update()
        {
            this.array.Update();
        }
        public void CreateCount()
        {
            this.count = array.Count();
        }
        public void Clear()
        {
            int count = array.Count();
            for (int i = 0; i < count; i++)
            {
                this.array.RemoveIndex(i);
            }
            this.array.Clear();
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int count =  this.Count;
            for (int i = 0; i < count; i++)
            {
                array[arrayIndex++] = this.array[i];
            }
        }

        public bool Remove(T item)
        {
           var remove_index =  this.IndexOf(item);
            if (remove_index == -1) return false;
            this.RemoveAt(remove_index);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
