using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.API
{
    abstract class Exscind
    {
        public abstract bool Start(string file, int endBytes);
    }
}
