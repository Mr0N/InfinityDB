using System;
using System.IO;
using Collection.RealizationEnumerator.SaveOrLoadInfo.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace TestCollection
{
    [TestClass]
    public class UnitTest1:Function
    {
        /// <summary>
        /// Провірка колекцій на рівність
        /// </summary>
        [TestMethod]
        public void TestCollectionEqual()
        {
            var result = CreateTestCollection();
            CollectionAssert.AreEqual(result.test, result.nottest);
        }
        /// <summary>
        /// Тест на унікальність
        /// </summary>
        [TestMethod]
        public void AllItemsAreUnique()
        {
            var result = CreateTestCollection();
            CollectionAssert.AllItemsAreUnique(result.test);
        }
        /// <summary>
        /// Тест розмірів масиву
        /// </summary>
        [TestMethod]
        public void TestLength()
        {
            var result = CreateTestCollection();
            Debug.Assert(result.test.Count == result.nottest.Count);
        }
        [TestMethod]
        public void TestRemoveEqual()
        {
            var result =  CreateTestCollection(x => x.RemoveIndex(10), y => y.RemoveAt(10));
            CollectionAssert.AreEqual(result.test, result.nottest);
        }
        private (List<string> test,List<string> nottest) CreateTestCollection(Action<SetWrite> actionTest=null,Action<List<string>> notTest=null)
        {
            try
            {
                var obj = GetObj();
                using (obj.objType.stream)
                {
                    var result = obj.set;
                    if (actionTest != null)
                    {
                        obj.set.Update();
                        actionTest.Invoke(result);
                    }
                    if (notTest != null)
                    {
                        obj.set.Update();
                        notTest.Invoke(obj.ls);
                    }
                    
                    int count = result.Count();
                    List<string> list = new List<string>();
                    obj.set.Update();
                    for (int i = 0; i < count; i++)
                    {
                        list.Add(GetString(result[i]));
                    }
                    return (list, obj.ls);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                RemoveFile();
            }
        }
        private (SetWrite set,List<string> ls,ObjType objType) GetObj()
        {
            var obj = CreateObj();
            var enumerable =  Enumerable.Range(0, 1000).Select(y=>y.ToString())
                .ToList();
            enumerable.ForEach(x => obj.set.SetInfo(GetByteToString(x.ToString())));
            obj.set.Update();
            return (obj.set, enumerable,obj.obj);
        }
    }
}
