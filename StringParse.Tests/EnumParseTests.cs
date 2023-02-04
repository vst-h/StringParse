using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringParse.Tests {

    [TestClass]
    public class EnumParseTests {


        [TestMethod]
        public void ParseEnum() {
            Assert.AreEqual("Monday".ParseEnum<DayOfWeek>(), DayOfWeek.Monday);
            Assert.AreEqual("monday".ParseEnum<DayOfWeek>(true), DayOfWeek.Monday);
            Assert.AreEqual("Monday".ParseEnum<DayOfWeek>(false), DayOfWeek.Monday);
            Assert.ThrowsException<ArgumentException>(() => "monday".ParseEnum<DayOfWeek>(false));
        }

        [TestMethod]
        public void ParseEnumDef() {
            Assert.AreEqual("Monday".ParseEnumOr(DayOfWeek.Wednesday), DayOfWeek.Monday);
            Assert.AreEqual("Monday-".ParseEnumOr(DayOfWeek.Wednesday), DayOfWeek.Wednesday);
            Assert.AreEqual("monday".ParseEnumOr(DayOfWeek.Wednesday, true), DayOfWeek.Monday);
            Assert.AreEqual("Monday".ParseEnumOr(DayOfWeek.Wednesday, false), DayOfWeek.Monday);
            Assert.AreEqual("monday".ParseEnumOr(DayOfWeek.Wednesday, false), DayOfWeek.Wednesday);
        }

        [TestMethod]
        public void Parse() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => "Monday".Parse<DayOfWeek>());
            Assert.IsTrue(e.Message.Contains("for Enum types"));
        }

        [TestMethod]
        public void ParseDef() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => "Monday".ParseOr(DayOfWeek.Monday));
            Assert.IsTrue(e.Message.Contains("for Enum types"));
        }

        [TestMethod]
        public void TryParse() {
            var e = Assert.ThrowsException<StrParseUnregisteredException>(() => {
                _ = "Monday".TryParse<DayOfWeek>(out DayOfWeek _);
            });
            Assert.IsTrue(e.Message.Contains("for Enum types"));
        }

        [TestMethod]
        public void TryParseWithBool() {
            Assert.AreEqual("monday".TryParse(out DayOfWeek day1, true), true);
            Assert.AreEqual(day1, DayOfWeek.Monday);

            Assert.AreEqual("Monday".TryParse(out DayOfWeek day2, false), true);
            Assert.AreEqual(day2, DayOfWeek.Monday);

            Assert.AreEqual("monday".TryParse(out DayOfWeek _, false), false);
        }

        [TestMethod]
        public void TryParseEnum() {
            Assert.AreEqual("monday".TryParseEnum(out DayOfWeek day1), true);
            Assert.AreEqual(day1, DayOfWeek.Monday);

            Assert.AreEqual("monday".TryParseEnum(out DayOfWeek day2, true), true);
            Assert.AreEqual(day2, DayOfWeek.Monday);

            Assert.AreEqual("Monday".TryParseEnum(out DayOfWeek day3, false), true);
            Assert.AreEqual(day3, DayOfWeek.Monday);

            Assert.AreEqual("monday".TryParseEnum(out DayOfWeek _, false), false);
        }
    }
}
