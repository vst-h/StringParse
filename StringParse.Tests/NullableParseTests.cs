using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringParse.Tests {
    [TestClass]
    public class NullableParseTests {

        [TestClass]
        public class Custom {
            static Custom() {
                StrParse.RegisterParse(S1.Parse);
                StrParse.RegisterTryParse<S1>(S1.TryParse);
            }
            struct S1 {
                public int S { get; set; }

                public static S1 Parse(string str) => new S1 { S = str.Parse<int>() };
                public static bool TryParse(string str, out S1 val) {
                    var bol = str.TryParse<int>(out var s);
                    val = new S1 { S = s };
                    return bol;
                }
            }

            [TestMethod]
            public void Parse() {
                Assert.AreEqual("3".Parse<S1?>().Value.S, 3);
                Assert.ThrowsException<FormatException>(() => "3s".Parse<S1?>());
            }

            [TestMethod]
            public void ParseDef() {
                Assert.AreEqual("3".ParseOr<S1?>(new S1 { S = 4 }).Value.S, 3);
                Assert.AreEqual("3s".ParseOr<S1?>(new S1 { S = 4 }).Value.S, 4);
            }

            [TestMethod]
            public void TryParse() {
                Assert.AreEqual("3".TryParse(out S1? a1), true);
                Assert.AreEqual(a1.Value.S, 3);
                Assert.AreEqual("3s".TryParse(out S1? _), false);
            }

            //[TestMethod]
            //public void TryParseDef() {
            //    Assert.AreEqual("3".TryParse(out S1? a, new S1 { S = 4 }), true);
            //    Assert.AreEqual(a.Value.S, 3);
            //    Assert.AreEqual("3s".TryParse(out S1? a2, new S1 { S = 4 }), false);
            //    Assert.AreEqual(a2.Value.S, 4);
            //}

        }


        [TestMethod]
        public void Parse() {
            Assert.AreEqual("3".Parse<int?>(), 3);
            Assert.ThrowsException<FormatException>(() => "3s".Parse<int?>());
        }

        [TestMethod]
        public void ParseDef() {
            Assert.AreEqual("3".ParseOr<int?>(1), 3);
            Assert.AreEqual("3s".ParseOr<int?>(1), 1);
        }

        [TestMethod]
        public void ParseFormat() {
            Assert.AreEqual("3".Parse<int?>((IFormatProvider)null), 3);
            Assert.ThrowsException<FormatException>(() => "3s".Parse<int?>((IFormatProvider)null));
        }

        [TestMethod]
        public void ParseNumberStyle() {
            Assert.AreEqual("F".Parse<int?>(NumberStyles.HexNumber, null), 15);
            Assert.ThrowsException<FormatException>(() => "3s".Parse<int?>(NumberStyles.HexNumber, null));
        }

        [TestMethod]
        public void ParseNumberStyleDef() {
            Assert.AreEqual("F".ParseOr<int?>(1, NumberStyles.HexNumber, null), 15);
            Assert.AreEqual("Q".ParseOr<int?>(1, NumberStyles.HexNumber, null), 1);
            Assert.AreEqual("Q".ParseOr<int?>(1, NumberStyles.HexNumber), 1);
        }

        [TestMethod]
        public void TryParse() {
            Assert.AreEqual("3".TryParse(out int? a1), true);
            Assert.AreEqual(a1, 3);
            Assert.AreEqual("3s".TryParse(out int? a2), false);
            Assert.AreEqual(a2, null);
        }

        [TestMethod]
        public void TryParseNumberStyle() {
            Assert.AreEqual("F".TryParse(NumberStyles.HexNumber, null, out int? a1), true);
            Assert.AreEqual(a1, 15);
            Assert.AreEqual("Q".TryParse(NumberStyles.HexNumber, null, out int? a2), false);
            Assert.AreEqual(a2, null);
        }

    }
}
