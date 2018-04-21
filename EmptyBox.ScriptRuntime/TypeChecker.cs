using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmptyBox.ScriptRuntime
{
    public static class TypeChecker
    {
        /// <summary>
        /// Проверяет, является ли тип одним из втроенных типов. BigInteger и другие типы вернут false
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumberType(Type type)
        {
            return type == typeof(double) ||
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
    }
}