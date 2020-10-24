using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.API
{
    public class ExscindWork
    {
        protected bool Start(string file, int endBytes)
        {
            return work.Start(file, endBytes);
        }
        Exscind work;
        private void Create()
        {
            this.work = new ExscindWindows();
        }
        public ExscindWork()
        {
            Create();
        }
    }
}
