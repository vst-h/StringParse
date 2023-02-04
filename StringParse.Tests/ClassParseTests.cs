using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringParse.Tests {

    [TestClass]
    public class ClassParseTests {

        [TestClass]
        public class Custom {
            static Custom() {
                StrParse.RegisterParseClass(C1.Parse);
                StrParse.RegisterTryParseClass<C1>(C1.TryParse);
            }
            class C1 {
                public int S { get; set; }

                public static C1 Parse(string str) => new C1 { S = str.Parse<int>() };
                public static bool TryParse(string str, out C1 val) {
                    var bol = str.TryParse<int>(out var s);
                    val = new C1 { S = s };
                    return bol;
                }
            }

            [TestMethod]
            public void Parse() {
                Assert.AreEqual("3".Parse<C1>().S, 3);
                Assert.ThrowsException<FormatException>(() => "3s".Parse<C1>());
            }

            [TestMethod]
            public void ParseDef() {
                Assert.AreEqual("3".ParseOr(new C1 { S = 4 }).S, 3);
                Assert.AreEqual("3s".ParseOr(new C1 { S = 4 }).S, 4);
            }

            [TestMethod]
            public void TryParse() {
                Assert.AreEqual("3".TryParse(out C1 a1), true);
                Assert.AreEqual(a1.S, 3);
                Assert.AreEqual("3s".TryParse(out C1 _), false);
            }

        }

        [TestMethod]
        public void Parse() {
            Assert.AreEqual("1.2.3.4".Parse<Version>().ToString(), "1.2.3.4");
        }

        [TestMethod]
        public void ParseDef() {
            var v1 = new Version(1, 2, 3, 4);
            Assert.AreEqual("1.2.3.41".ParseOr(v1).ToString(), "1.2.3.41");
            Assert.AreEqual("1.2.3-4".ParseOr(v1), v1);
        }

    }
}