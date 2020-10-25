using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class IndexType
    {
        public long indexMinimum { set; get; }
        public long indexMaximum { set; get; }
        public bool remove { set; get; }
        public bool block { set; get; }
        public IndexType next { set; get; }
        public IndexType(long indexMax,
                    long indexMin,bool remove = false,
                    bool block = false,IndexType next=null)
        {
            this.indexMinimum = indexMax;
            this.indexMaximum = indexMin;
            this.remove = remove;
            this.block = block;
            this.next = next;
        }
    }
}
