using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public interface ISerializableObject<T>
    {
        byte[] GetBytes();
        T SetInformation(byte[] information);
    }
}
