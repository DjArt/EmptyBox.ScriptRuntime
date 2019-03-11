using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EmptyBox.ScriptRuntime.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsAnonymousType(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            return type.GetTypeInfo().GetCustomAttribute(typeof(CompilerGeneratedAttribute), false) != null
                && type.GetTypeInfo().IsGenericType && type.Name.Contains("AnonymousType")
                && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                && (type.GetTypeInfo().Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
        }

        public static bool CanBeNull(this Type type)
        {
            return type == null ? true : type.GetTypeInfo().IsClass || Nullable.GetUnderlyingType(type) != null;
        }

        public static bool CanBeNull(this TypeInfo type)
        {
            return type == null ? true : type.IsClass || Nullable.GetUnderlyingType(type.AsType()) != null;
        }

        public static dynamic GenerateEmptyObject(this Type type)
        {
            dynamic r = null;
            if (type == typeof(string))
            {
                r = string.Empty;
            }
            else if (!type.IsArray && !type.IsAnonymousType() && !type.GetTypeInfo().IsAbstract && !type.GetTypeInfo().IsInterface)
            {
                r = Activator.CreateInstance(type);
            }
            return r;
        }

        /// <summary>
        /// Проверяет, является ли тип одним из вcтроенных типов. BigInteger и другие типы вернут false
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumericType(this Type type)
        {
            return type == typeof(decimal) ||
                   type == typeof(double) ||
                   type == typeof(float) ||
                   type == typeof(ulong) ||
                   type == typeof(long) ||
                   type == typeof(uint) ||
                   type == typeof(int) ||
                   type == typeof(ushort) ||
                   type == typeof(short) ||
                   type == typeof(byte) ||
                   type == typeof(sbyte);
        }

        /// <summary>
        /// Проверяет, является ли тип одним из вcтроенных типов. BigInteger и другие типы вернут false
        /// </summary>
        /// <returns></returns>
        public static bool IsNumericType<T>()
        {
            return typeof(T) == typeof(decimal) ||
                   typeof(T) == typeof(double) ||
                   typeof(T) == typeof(float) ||
                   typeof(T) == typeof(ulong) ||
                   typeof(T) == typeof(long) ||
                   typeof(T) == typeof(uint) ||
                   typeof(T) == typeof(int) ||
                   typeof(T) == typeof(ushort) ||
                   typeof(T) == typeof(short) ||
                   typeof(T) == typeof(byte) ||
                   typeof(T) == typeof(sbyte);
        }
    }
}
