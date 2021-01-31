using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringParse.Tests {
    [TestClass]
    public class RegisterTests {


        [TestMethod]
        public void Parse() {
            "true".Parse<bool?>();
            "3".Parse<char?>();
            "3".Parse<sbyte?>();
            "3".Parse<byte?>();
            "3".Parse<short?>();
            "3".Parse<ushort?>();
            "3".Parse<int?>();
            "3".Parse<uint?>();
            "3".Parse<long?>();
            "3".Parse<ulong?>();
            "3".Parse<float?>();
            "3".Parse<double?>();
            "3".Parse<decimal?>();
            Guid.NewGuid().ToString().Parse<Guid?>();
            "3".Parse<TimeSpan?>();
            DateTime.Now.ToString().Parse<DateTime?>();
            DateTimeOffset.Now.ToString().Parse<DateTimeOffset?>();
            "3".Parse<System.Numerics.BigInteger?>();
            "3".Parse<System.Buffers.StandardFormat?>();
            "3".Parse<Half?>();
            "3".Parse<IntPtr?>();
            "3".Parse<UIntPtr?>();

            "3.1".Parse<Version>();
            "3.1.2.3".Parse<System.Net.IPAddress>();
            "01030405".Parse<System.Net.NetworkInformation.PhysicalAddress>();

        }

        [TestMethod]
        public void ParseFormat() {
            "3".Parse<sbyte?>((IFormatProvider)null);
            "3".Parse<byte?>((IFormatProvider)null);
            "3".Parse<short?>((IFormatProvider)null);
            "3".Parse<ushort?>((IFormatProvider)null);
            "3".Parse<int?>((IFormatProvider)null);
            "3".Parse<uint?>((IFormatProvider)null);
            "3".Parse<long?>((IFormatProvider)null);
            "3".Parse<ulong?>((IFormatProvider)null);
            "3.3".Parse<float?>((IFormatProvider)null);
            "3.3".Parse<double?>((IFormatProvider)null);
            "3.3".Parse<decimal?>((IFormatProvider)null);
            "3".Parse<TimeSpan?>((IFormatProvider)null);
            DateTime.Now.ToString().Parse<DateTime?>((IFormatProvider)null);
            DateTimeOffset.Now.ToString().Parse<DateTimeOffset?>((IFormatProvider)null);
            "3".Parse<System.Numerics.BigInteger?>((IFormatProvider)null);
            "3.3".Parse<Half?>((IFormatProvider)null);
            "3".Parse<IntPtr?>((IFormatProvider)null);
            "3".Parse<UIntPtr?>((IFormatProvider)null);
        }

        [TestMethod]
        public void ParseNumberStyle() {
            "F".Parse<sbyte?>(NumberStyles.HexNumber, null);
            "F".Parse<byte?>(NumberStyles.HexNumber, null);
            "F".Parse<short?>(NumberStyles.HexNumber, null);
            "F".Parse<ushort?>(NumberStyles.HexNumber, null);
            "F".Parse<int?>(NumberStyles.HexNumber, null);
            "F".Parse<uint?>(NumberStyles.HexNumber, null);
            "F".Parse<long?>(NumberStyles.HexNumber, null);
            "F".Parse<ulong?>(NumberStyles.HexNumber, null);
            "3.3".Parse<float?>(NumberStyles.Number, null);
            "3.3".Parse<double?>(NumberStyles.Number, null);
            "3.3".Parse<decimal?>(NumberStyles.Number, null);
            "F".Parse<System.Numerics.BigInteger?>(NumberStyles.HexNumber, null);
            "3.3".Parse<Half?>(NumberStyles.Number, null);
            "F".Parse<IntPtr?>(NumberStyles.HexNumber, null);
            "F".Parse<UIntPtr?>(NumberStyles.HexNumber, null);
        }

        [TestMethod]
        public void TryParse() {
           _ = "true".TryParse<bool?>(out var _);
           _ = "3".TryParse<char?>(out var _);
           _ = "3".TryParse<sbyte?>(out var _);
           _ = "3".TryParse<byte?>(out var _);
           _ = "3".TryParse<short?>(out var _);
           _ = "3".TryParse<ushort?>(out var _);
           _ = "3".TryParse<int?>(out var _);
           _ = "3".TryParse<uint?>(out var _);
           _ = "3".TryParse<long?>(out var _);
           _ = "3".TryParse<ulong?>(out var _);
           _ = "3".TryParse<float?>(out var _);
           _ = "3".TryParse<double?>(out var _);
           _ = "3".TryParse<decimal?>(out var _);
           _ = Guid.NewGuid().ToString().TryParse<Guid?>(out var _);
           _ = "3".TryParse<TimeSpan?>(out var _);
           _ = DateTime.Now.ToString().TryParse<DateTime?>(out var _);
           _ = DateTimeOffset.Now.ToString().TryParse<DateTimeOffset?>(out var _);
           _ = "3".TryParse<System.Numerics.BigInteger?>(out var _);
           _ = "3".TryParse<Half?>(out var _);
           _ = "3".TryParse<IntPtr?>(out var _);
           _ = "3".TryParse<UIntPtr?>(out var _);

           _ = "3.1".TryParse<Version>(out var _);
           _ = "3.1.2.3".TryParse<System.Net.IPAddress>(out var _);
           _ = "01030405".TryParse<System.Net.NetworkInformation.PhysicalAddress>(out var _);
        }

        [TestMethod]
        public void TryParseNumberStyle() {
            "F".TryParse(NumberStyles.HexNumber, null, out sbyte? _);
            "F".TryParse(NumberStyles.HexNumber, null, out byte? _);
            "F".TryParse(NumberStyles.HexNumber, null, out short? _);
            "F".TryParse(NumberStyles.HexNumber, null, out ushort? _);
            "F".TryParse(NumberStyles.HexNumber, null, out int? _);
            "F".TryParse(NumberStyles.HexNumber, null, out uint? _);
            "F".TryParse(NumberStyles.HexNumber, null, out long? _);
            "F".TryParse(NumberStyles.HexNumber, null, out ulong? _);
            "3.3".TryParse(NumberStyles.Number, null, out float? _);
            "3.3".TryParse(NumberStyles.Number, null, out double? _);
            "3.3".TryParse(NumberStyles.Number, null, out decimal? _);
            "F".TryParse(NumberStyles.HexNumber, null, out System.Numerics.BigInteger? _);
            "3".TryParse(NumberStyles.Number, null, out Half? _);
            "F".TryParse(NumberStyles.Number, null, out IntPtr? _);
            "F".TryParse(NumberStyles.Number, null, out UIntPtr? _);
        }

    }
}
