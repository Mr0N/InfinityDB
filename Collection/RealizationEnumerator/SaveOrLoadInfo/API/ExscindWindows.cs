using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vanara;
using static Vanara.PInvoke.Kernel32;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.API
{
    class ExscindWindows : Exscind
    {
        public override bool Start(string file, int endBytes)
        {
            var x = OFSTRUCT.Default;
            using (var file_load = OpenFile(file, ref x, OpenFileAction.OF_READWRITE))
            {
                int cc = 0;
                SetFilePointer(file_load, endBytes, ref cc, SeekOrigin.Current);
                return SetEndOfFile(file_load);
            }
        }
    }
}
