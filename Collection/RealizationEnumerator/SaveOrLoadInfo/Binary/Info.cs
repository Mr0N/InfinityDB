using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class Info : Destroyer
    {
        public override void RemoveIndex(int index)
        {
            int ind = GetIlusionIndex(index);
            base.RemoveIndex(ind);
        }
        public virtual byte[] this[int index]
        {
            get
            {
                //int res = GetIlusionIndex(index);
                return GetInfo(index);
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public int Count()
            => index.Where(x => x.remove == false && x.block != true).Count();
        public int GetIlusionIndex(int index)
        {
            var obj = this.index.Where(x => x.remove != true && x.block != true).ElementAt(index);
            return this.index.FindIndex(t => t == obj);
        }

        public Info(ObjType objType) : base(objType)
        {

        }
    }
}
