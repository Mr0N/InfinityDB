using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class IndexType
    {
        public int indexMax { set; get; }
        public int indexMin { set; get; }
        public bool remove { set; get; }
        public IndexType(int indexMax,int indexMin,bool remove = false)
        {
            this.indexMax = indexMax;
            this.indexMin = indexMin;
            this.remove = remove;
        }
    }
}
