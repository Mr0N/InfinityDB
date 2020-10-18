using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class IndexType
    {
        public long index { set; get; }
        public bool remove { set; get; }
        public IndexType(long index)
        {
            this.index = index;
        }
    }
}
