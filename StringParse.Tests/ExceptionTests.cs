using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringParse.Tests {

    [TestClass]
    public class ExceptionTests {
        static ExceptionTests() {
            StrParse.RegisterParseClass(ThrowNullRefException.Parse);
            StrParse.RegisterTryParseClass<ThrowNullRefException>(ThrowNullRefException.TryParse);
        }

        [TestMethod]
        public void Parse() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                "".Parse<object>();
            });
            Assert.IsTrue(e.Message.Contains($"Parse<Object>(string)"));
        }

        [TestMethod]
        public void ParseDef() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                "".Parse<object>(new object());
            });
            Assert.IsTrue(e.Message.Contains($"TryParse<Object>(string, out Object)"));
        }

        [TestMethod]
        public void ParseFormat() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                "".Parse<object>(null);
            });
            Assert.IsTrue(e.Message.Contains($"Parse<Object>(string, IFormatProvider)"));
        }

        [TestMethod]
        public void ParseNumberStyle() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                "".Parse<Guid?>(NumberStyles.HexNumber, null);
            });
            Assert.IsTrue(e.Message.Contains($"Parse<Guid?>(string, NumberStyles, IFormatProvider)"));
        }

        [TestMethod]
        public void ParseNumberStyleDef() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                "".Parse<Guid?>(Guid.NewGuid(), NumberStyles.HexNumber, null);
            });
            Assert.IsTrue(e.Message.Contains($"TryParse<Guid?>(string, NumberStyles, IFormatProvider, out Guid?)"));
        }

        [TestMethod]
        public void TryParse() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                _ = "".TryParse<object>(out var _);
            });
            Assert.IsTrue(e.Message.Contains($"TryParse<Object>(string, out Object)"));
        }

        [TestMethod]
        public void TryParseNumberStyle() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                _ = "".TryParse<object>(NumberStyles.HexNumber, null, out var _);
            });
            Assert.IsTrue(e.Message.Contains($"TryParse<Object>(string, NumberStyles, IFormatProvider, out Object)"));
        }


        class ThrowNullRefException {
            public static ThrowNullRefException Parse(string _) => throw new NullReferenceException();
            public static bool TryParse(string _, out ThrowNullRefException val)
                => throw new NullReferenceException();
        }

        [TestMethod]
        public void ParseNullReferenceException() {
            var e = Assert.ThrowsException<NullReferenceException>(() => {
                "".Parse<ThrowNullRefException>();
            });
        }

        [TestMethod]
        public void ParseGenericErr() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                "".Parse<Action<Action<Guid?>, Guid?>>();
            });
            Assert.IsTrue(e.Message.Contains($"Parse<Action<Action<Guid?>, Guid?>>(string)"), e.Message);
        }
    }
}
