using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemProgramming.second_labs.forms.lab7;

namespace UnitTestProject.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(TextRender.ChangeVowelCase("abc"), "Abc");
        }
    }
}
