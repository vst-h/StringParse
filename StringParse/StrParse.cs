using System;
using System.Linq;
using System.Globalization;

namespace StringParse;

public delegate bool FnTry<in T, TValue>(T obj, out TValue val);
public delegate bool FnTry<in T0, in T1, in T2, TValue>(T0 obj, T1 arg1, T2 arg2, out TValue val);

static class StrParse<T> {
    public static Func<string, T>? Parse;
    public static FnTry<string?, T>? TryParse;
}

static class StrParseFormat<T> {
    public static Func<string, IFormatProvider?, T>? Parse;
}

static class StrParseNumberStyle<T> {
    public static Func<string, NumberStyles, IFormatProvider?, T>? Parse;
    public static FnTry<string?, NumberStyles, IFormatProvider?, T>? TryParse;
}


/// <summary>
/// Let string parse some common types, Nullable types of structures can also be parsed, the following are the registered types: 
/// <para/>
/// <see cref="bool"/>,
/// <see cref="char"/>,
/// <see cref="sbyte"/>,
/// <see cref="byte"/>,
/// <see cref="short"/>,
/// <see cref="ushort"/>,
/// <see cref="int"/>,
/// <see cref="uint"/>,
/// <see cref="long"/>,
/// <see cref="ulong"/>,
/// <see cref="float"/>,
/// <see cref="double"/>,
/// <see cref="decimal"/>,
/// <para/>
/// <see cref="Guid"/>,
/// <see cref="TimeSpan"/>,
/// <see cref="DateTime"/>,
/// <see cref="DateTimeOffset"/>,
/// <see cref="System.Numerics.BigInteger"/>, <para/>
/// <see cref="System.Buffers.StandardFormat"/> (Requires .netstandard2.1 version or higher), <para/>
/// <see cref="Half"/> (Requires .net5.0 version or higher), <para/>
/// <see cref="IntPtr"/> (Requires .net5.0 version or higher), <para/>
/// <see cref="UIntPtr"/> (Requires .net5.0 version or higher), <para/>
/// <para/>
/// All Enum types call these two methods by default <para/>
/// <see cref="Enum.Parse{TEnum}(string, bool)"/> (Requires .netstandard2.1 version or higher), <para/>
/// <see cref="Enum.TryParse{TEnum}(string, bool, out TEnum)"/>
/// <para/>
/// class: <para/>
/// <see cref="Version"/>,
/// <see cref="System.Net.IPAddress"/>,
/// <see cref="System.Net.NetworkInformation.PhysicalAddress"/>,
/// </summary>
public static class StrParse {
    static StrParse() {
        ////////////////// Parse(string)
        RegisterParse(bool.Parse);
        RegisterParse(char.Parse);
        RegisterParse(sbyte.Parse);
        RegisterParse(byte.Parse);
        RegisterParse(short.Parse);
        RegisterParse(ushort.Parse);
        RegisterParse(int.Parse);
        RegisterParse(uint.Parse);
        RegisterParse(long.Parse);
        RegisterParse(ulong.Parse);
        RegisterParse(float.Parse);
        RegisterParse(double.Parse);
        RegisterParse(decimal.Parse);
        RegisterParse(Guid.Parse);
        RegisterParse(TimeSpan.Parse);
        RegisterParse(DateTime.Parse);
        RegisterParse(DateTimeOffset.Parse);
        RegisterParse(System.Numerics.BigInteger.Parse);
#if NETSTANDARD2_1 || NET5_0
        RegisterParse(System.Buffers.StandardFormat.Parse);
#endif
#if NET5_0
        RegisterParse(Half.Parse);
        RegisterParse(IntPtr.Parse);
        RegisterParse(UIntPtr.Parse);
#endif

        RegisterParseClass(Version.Parse);
        RegisterParseClass(System.Net.IPAddress.Parse);
        RegisterParseClass(System.Net.NetworkInformation.PhysicalAddress.Parse);

        ///////////////////////// TryParse(string, out T)
        RegisterTryParse<bool>(bool.TryParse);
        RegisterTryParse<char>(char.TryParse);
        RegisterTryParse<sbyte>(sbyte.TryParse);
        RegisterTryParse<byte>(byte.TryParse);
        RegisterTryParse<short>(short.TryParse);
        RegisterTryParse<ushort>(ushort.TryParse);
        RegisterTryParse<int>(int.TryParse);
        RegisterTryParse<uint>(uint.TryParse);
        RegisterTryParse<long>(long.TryParse);
        RegisterTryParse<ulong>(ulong.TryParse);
        RegisterTryParse<float>(float.TryParse);
        RegisterTryParse<double>(double.TryParse);
        RegisterTryParse<decimal>(decimal.TryParse);
        RegisterTryParse<Guid>(Guid.TryParse);
        RegisterTryParse<TimeSpan>(TimeSpan.TryParse);
        RegisterTryParse<DateTime>(DateTime.TryParse);
        RegisterTryParse<DateTimeOffset>(DateTimeOffset.TryParse);
        RegisterTryParse<System.Numerics.BigInteger>(System.Numerics.BigInteger.TryParse);
#if NET5_0
        RegisterTryParse<Half>(Half.TryParse);
        RegisterTryParse<IntPtr>(IntPtr.TryParse);
        RegisterTryParse<UIntPtr>(UIntPtr.TryParse);
#endif

        RegisterTryParseClass<Version>(Version.TryParse!);
        RegisterTryParseClass<System.Net.IPAddress>(System.Net.IPAddress.TryParse!);
#if NET5_0
        RegisterTryParseClass<System.Net.NetworkInformation.PhysicalAddress>(System.Net.NetworkInformation.PhysicalAddress.TryParse!);
#endif

        ////////////////////// Parse(string, IFormatProvider)
        RegisterParseFormat(sbyte.Parse);
        RegisterParseFormat(byte.Parse);
        RegisterParseFormat(short.Parse);
        RegisterParseFormat(ushort.Parse);
        RegisterParseFormat(int.Parse);
        RegisterParseFormat(uint.Parse);
        RegisterParseFormat(long.Parse);
        RegisterParseFormat(ulong.Parse);
        RegisterParseFormat(float.Parse);
        RegisterParseFormat(double.Parse);
        RegisterParseFormat(decimal.Parse);
        RegisterParseFormat(TimeSpan.Parse);
        RegisterParseFormat(DateTime.Parse);
        RegisterParseFormat(DateTimeOffset.Parse);
        RegisterParseFormat(System.Numerics.BigInteger.Parse);
#if NET5_0
        RegisterParseFormat(Half.Parse);
        RegisterParseFormat(IntPtr.Parse);
        RegisterParseFormat(UIntPtr.Parse);
#endif


        ////////////////////// Parse(string, NumberStyles, IFormatProvider)
        RegisterParseStyle(sbyte.Parse);
        RegisterParseStyle(byte.Parse);
        RegisterParseStyle(short.Parse);
        RegisterParseStyle(ushort.Parse);
        RegisterParseStyle(int.Parse);
        RegisterParseStyle(uint.Parse);
        RegisterParseStyle(long.Parse);
        RegisterParseStyle(ulong.Parse);
        RegisterParseStyle(float.Parse);
        RegisterParseStyle(double.Parse);
        RegisterParseStyle(decimal.Parse);
        RegisterParseStyle(System.Numerics.BigInteger.Parse);
#if NET5_0
        RegisterParseStyle(Half.Parse);
        RegisterParseStyle(IntPtr.Parse);
        RegisterParseStyle(UIntPtr.Parse);
#endif

        ////////////////////// TryParse(string, NumberStyles, IFormatProvider, out T)
        RegisterTryParseStyle<sbyte>(sbyte.TryParse);
        RegisterTryParseStyle<byte>(byte.TryParse);
        RegisterTryParseStyle<short>(short.TryParse);
        RegisterTryParseStyle<ushort>(ushort.TryParse);
        RegisterTryParseStyle<int>(int.TryParse);
        RegisterTryParseStyle<uint>(uint.TryParse);
        RegisterTryParseStyle<long>(long.TryParse);
        RegisterTryParseStyle<ulong>(ulong.TryParse);
        RegisterTryParseStyle<float>(float.TryParse);
        RegisterTryParseStyle<double>(double.TryParse);
        RegisterTryParseStyle<decimal>(decimal.TryParse);
        RegisterTryParseStyle<System.Numerics.BigInteger>(System.Numerics.BigInteger.TryParse);
#if NET5_0
        RegisterTryParseStyle<Half>(Half.TryParse);
        RegisterTryParseStyle<IntPtr>(IntPtr.TryParse);
        RegisterTryParseStyle<UIntPtr>(UIntPtr.TryParse);
#endif

    }

    #region RegisterParse

    public static void RegisterParse<T>(Func<string, T>? parse) where T : struct {
        StrParse<T>.Parse = parse;
        StrParse<T?>.Parse = ParseNullable<T>;
    }

    public static void RegisterParseFormat<T>(Func<string, IFormatProvider?, T>? parse) where T : struct {
        StrParseFormat<T>.Parse = parse;
        StrParseFormat<T?>.Parse = ParseNullable<T>;
    }

    public static void RegisterParseStyle<T>(Func<string, NumberStyles, IFormatProvider?, T>? parse) where T : struct {
        StrParseNumberStyle<T>.Parse = parse;
        StrParseNumberStyle<T?>.Parse = ParseNullable<T>;
    }

    #endregion

    #region RegisterTryParse
    public static void RegisterTryParse<T>(FnTry<string?, T>? tryParse) where T : struct {
        StrParse<T>.TryParse = tryParse;
        StrParse<T?>.TryParse = TryParseNullable;
    }

    public static void RegisterTryParseStyle<T>(FnTry<string?, NumberStyles, IFormatProvider?, T>? parse) where T : struct {
        StrParseNumberStyle<T>.TryParse = parse;
        StrParseNumberStyle<T?>.TryParse = TryParseNullable;
    }

    #endregion

    #region RegisterClass
    public static void RegisterParseClass<T>(Func<string, T>? parse) where T : class {
        StrParse<T>.Parse = parse;
    }
    public static void RegisterTryParseClass<T>(FnTry<string?, T>? tryParse) where T : class {
        StrParse<T>.TryParse = tryParse;
    }

    #endregion

    #region ParseNullable

    static T? ParseNullable<T>(this string str) where T : struct {
        try {
            return string.IsNullOrWhiteSpace(str) ? default : StrParse<T>.Parse!(str);
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("Parse<{0}>(string)");
        }
    }

    static T? ParseNullable<T>(this string str, IFormatProvider? provider) where T : struct {
        try {
            return string.IsNullOrWhiteSpace(str) ? default : StrParseFormat<T>.Parse!(str, provider);
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("Parse<{0}>(string, IFormatProvider)");
        }
    }

    static T? ParseNullable<T>(this string str, NumberStyles style, IFormatProvider? provider) where T : struct {
        try {
            return string.IsNullOrWhiteSpace(str) ? default : StrParseNumberStyle<T>.Parse!(str, style, provider);
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("Parse<{0}>(string, NumberStyles, IFormatProvider)");
        }
    }


    #endregion

    #region Parse<T>(this string str)
    public static T Parse<T>(this string str) {
        try {
            return StrParse<T>.Parse!(str);
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            // NullReferenceException 可能来自 StrParse<T>.Parse 方法里面的异常
            throw StrParseUnregisteredException.New<T>("Parse<{0}>(string)");
        }
    }

    public static T ParseOr<T>(this string str, T defaultValue) {
        try {
            return StrParse<T>.TryParse!(str, out var val) ? val : defaultValue;
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("TryParse<{0}>(string, out {0})");
        }
    }

    public static T Parse<T>(this string str, IFormatProvider? provider) {
        try {
            return StrParseFormat<T>.Parse!(str, provider);
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("Parse<{0}>(string, IFormatProvider)");
        }
    }

    public static T Parse<T>(this string str, NumberStyles style, IFormatProvider? provider = null) {
        try {
            return StrParseNumberStyle<T>.Parse!(str, style, provider);
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("Parse<{0}>(string, NumberStyles, IFormatProvider)");
        }
    }

    public static T ParseOr<T>(this string str, T defaultValue, NumberStyles style, IFormatProvider? provider = null) {
        try {
            return StrParseNumberStyle<T>.TryParse!(str, style, provider, out var val) ? val : defaultValue;
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("TryParse<{0}>(string, NumberStyles, IFormatProvider, out {0})");
        }
    }

    #endregion

    #region TryParse<T>(this string str)
    public static bool TryParse<T>(this string? str, out T val) {
        try {
            return StrParse<T>.TryParse!(str, out val);
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("TryParse<{0}>(string, out {0})");
        }
    }

    public static bool TryParse<T>(this string? str, NumberStyles style, IFormatProvider? provider, out T val) {
        try {
            return StrParseNumberStyle<T>.TryParse!(str, style, provider, out val);
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("TryParse<{0}>(string, NumberStyles, IFormatProvider, out {0})");
        }
    }

    #endregion

    #region TryParseNullable

    static bool TryParseNullable<T>(this string? str, out T? val) where T : struct {
        try {
            var bol = StrParse<T>.TryParse!(str, out var temp);
            val = bol ? (T?)temp : null;  // T => Nullable<T>
            return bol;
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("TryParse<{0}>(string, out {0})");
        }
    }

    static bool TryParseNullable<T>(this string? str, NumberStyles style, IFormatProvider? provider, out T? val)
    where T : struct {
        try {
            var bol = StrParseNumberStyle<T>.TryParse!(str, style, provider, out var temp);
            val = bol ? (T?)temp : null;  // T => Nullable<T>
            return bol;
        } catch (NullReferenceException e) when (e.TargetSite!.DeclaringType == typeof(StrParse)) {
            throw StrParseUnregisteredException.New<T>("TryParse<{0}>(string, NumberStyles, IFormatProvider, out {0})");
        }
    }

    #endregion

    #region Enum

#if NETSTANDARD2_1 || NET5_0

    public static T ParseEnum<T>(this string str, bool ignoreCase = true) where T : struct, Enum {
        return Enum.Parse<T>(str, ignoreCase);
    }

#endif

    public static T ParseEnumOr<T>(this string str, T defaultValue, bool ignoreCase = true) where T : struct, Enum {
        return Enum.TryParse<T>(str, ignoreCase, out var val) ? val : defaultValue;
    }


    public static bool TryParse<T>(this string str, out T val, bool ignoreCase) where T : struct, Enum {
        return Enum.TryParse(str, ignoreCase, out val);
    }

    public static bool TryParseEnum<T>(this string str, out T val, bool ignoreCase = true) where T : struct, Enum {
        return Enum.TryParse(str, ignoreCase, out val);
    }

    #endregion

}


