using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{


    public class Destroyer:Creator
    {
        public void RemoveIndex(int index)
        {
           this.index[index].remove = true;
        }
        public Destroyer(int count,Stream stream):base(count,stream)
        {
        }
    }
}
