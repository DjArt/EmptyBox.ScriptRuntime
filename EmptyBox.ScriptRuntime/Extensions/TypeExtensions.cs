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
    }
}
