using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
   public class Info:Destroyer
    {
        public byte[] this[int index] {
            get
            {
                int res = GetIlusionIndex(index);
                return GetInfo(res);
            }
        }
        public int Count()
            => index.Where(x => x.remove == false).Count();
        public int GetIlusionIndex(int index)
        {
             var obj = this.index.Where(x => x.remove != true).ElementAt(index);
            return this.index.FindIndex(t => t == obj);
        }
        public Info(int count,Stream stream):base(count,stream)
        {

        }
    }
}
