using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class CommonHelperTests
    {
        [TestMethod()]
        public void SBCToDBCTest()
        {
            string name = "（）";
            name = CommonHelper.SBCToDBC(name);
            Assert.AreEqual(name, "()");
        }

        [TestMethod()]
        public void WriteFileTest()
        {
            string path = Environment.CurrentDirectory + DateTime.Now.ToString("yyyyMMdd");
            string filename = "test";
            CommonHelper.WriteFile(path, filename);
        }
    }
}