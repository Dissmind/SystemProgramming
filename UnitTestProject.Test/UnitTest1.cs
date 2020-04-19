using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemProgramming.second_labs.forms.lab7;

namespace UnitTestProject.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTextReader()
        {
            Assert.AreEqual(TextRender.ChangeVowelCase("abceE"), "AbcEe");
            Assert.AreEqual(TextRender.ChangeVowelCase("sdf"), "sdf");
            Assert.AreEqual(TextRender.ChangeVowelCase("ûâà"), "ÛâÀ");
            Assert.AreEqual(TextRender.ChangeVowelCase("öö"), "öö");
            Assert.AreEqual(TextRender.ChangeVowelCase(""), "");
        }
    }
}
