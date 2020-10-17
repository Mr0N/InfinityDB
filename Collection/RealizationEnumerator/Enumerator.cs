using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
 
    public class Enumerator<T> :IEnumerator<T> where T : ISerializableObject<T>
    {
        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
