using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Collection.RealizationEnumerator.SaveOrLoadInfo.API;
using System.Threading;

namespace Collection.RealizationEnumerator.SaveOrLoadInfo.Binary
{
    public class ObjType: ExscindWork
    {
        public bool Exscind(int endBytes)
        {
            Stop();
            var result =  base.Start(this.file, endBytes);
            Run();
            return result;
        }
        private void Stop()
        {
            if (stream == null) throw new ArgumentNullException("stream == null");
            stream.Dispose();
        }
        private void Run()
        {
            try
            {
                this.mutex.WaitOne();
                TryRun();
            }
            catch(Exception ex) { throw ex; }
            finally
            {
                this.mutex.ReleaseMutex();
            }
        }
        private void TryRun()
        {
            this.stream = createFile.Invoke(this.file);
        }
        public Stream stream { private set; get; }
        public string file {private set; get; }
        Func<string, Stream> createFile;
        Mutex mutex;
        public ObjType(string file,Func<string,Stream> createFile)
        {
            Initialization(file, createFile);
            this.Run();
        }
        private void Initialization(string file, Func<string, Stream> createFile)
        {
            this.mutex = new Mutex(true, "eb2ac5b04180d8d6011a016aeb8f75b3!@");
            this.createFile = createFile;
            this.file = file;
        }
    }
}
