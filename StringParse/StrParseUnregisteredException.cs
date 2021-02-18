using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringParse {

    /// <summary>
    /// The type does not have a corresponding Parse method,
    /// Try registering methods for the type using the RegisterParse method
    /// </summary>
    public class StrParseUnregisteredException : Exception {
        public Type ParseType { get; }
        public StrParseUnregisteredException(string message, Type parseType) : base(message) {
            ParseType = parseType;
        }

        public static StrParseUnregisteredException New<T>(string method) {
            var type = typeof(T);
            var enumMsg = type.IsEnum ? $"\nPlease use method `ParseEnum` or method `TryParseEnum` for Enum types" : "";
            return new StrParseUnregisteredException(
                $"Method not registered: {string.Format(method, GetTypeName(type))};{enumMsg}",
                type
            );

            static string GetTypeName(Type type) {
                return type.IsGenericType
                    ? type.GetGenericTypeDefinition() == typeof(Nullable<>)
                        ? GetTypeName(type.GetGenericArguments()[0]) + "?"
                        : $"{type.Name.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(GetTypeName))}>"
                    : type.Name;
            }
        }
    }

}
