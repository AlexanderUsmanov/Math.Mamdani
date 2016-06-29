using System.IO;
using System.Linq;
using System.Text;
using FuzzyLogic.Mamdani.Problems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuzzyLogic.Mamdani.Test
{
    [TestClass]
    public class ProblemConditionsReaderTest
    {
        [TestMethod]
        public void ReadConditionsFromXmlStringTest()
        {
            var result = ProblemSamples.ReadConditionsFromXmlString(Resources.input);

            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Data);

            Assert.AreEqual(result.Data.Variables.Count, 3);
            Assert.AreEqual(result.Data.Rules.Count, 12);

            Assert.IsTrue(result.Data.Variables.Any(x => x.Name == "X1"));
            Assert.IsTrue(result.Data.Variables.Any(x => x.Name == "X1" && x.Terms.Any(t => t.Name == "низкий")));

            Assert.IsTrue(result.Data.Rules.All(x => x.Conditions.Any(c => c.LingVariable.Name == "X1")
                                                    && x.Conditions.Any(c => c.LingVariable.Name == "X2")
                                                    && x.Conclusion.LingVariable.Name == "Y"));
        }

        [TestMethod]
        public void ReadConditionsFromXmlStreamTest()
        {
            using (var mem = new MemoryStream())
            {
                var str = Resources.input;
                var buffer = Encoding.UTF8.GetBytes(str);
                mem.Write(buffer, 0, buffer.Length);
                mem.Seek(0, SeekOrigin.Begin);

                var result = ProblemSamples.ReadConditionsFromXmlStream(mem);
                Assert.IsTrue(result.Success);
                Assert.IsNotNull(result.Data);

                Assert.AreEqual(result.Data.Variables.Count, 3);
                Assert.AreEqual(result.Data.Rules.Count, 12);

                Assert.IsTrue(result.Data.Variables.Any(x => x.Name == "X1"));
                Assert.IsTrue(result.Data.Variables.Any(x => x.Name == "X1" && x.Terms.Any(t => t.Name == "низкий")));

                Assert.IsTrue(result.Data.Rules.All(x => x.Conditions.Any(c => c.LingVariable.Name == "X1")
                                                        && x.Conditions.Any(c => c.LingVariable.Name == "X2")
                                                        && x.Conclusion.LingVariable.Name == "Y"));
            }
        }
    }
}
