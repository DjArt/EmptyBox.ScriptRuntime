using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EmptyBox.ScriptRuntime.Extensions
{
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Создаёт последовательность из неповторяющихся элементов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg">Исходная последовательность</param>
        /// <returns></returns>
        public static IEnumerable<T> Unique<T>(this IEnumerable<T> arg)
        {
            List<T> result = new List<T>();
            foreach (T value in arg)
            {
                if (!result.Exists(x => OperatorCache<T, T, bool>.Equal(x, value)))
                {
                    result.Add(value);
                }
            }
            return result;
        }

        /// <summary>
        /// Сравнивает два множества без учёта порядка и с учётом повторяющихся элементов
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        /// <param name="first">Первое множество</param>
        /// <param name="second">Второе множество</param>
        /// <returns>Результат сравнения</returns>
        public static bool SetEqual<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first.Count() != second.Count())
            {
                return false;
            }
            List<T> _first = new List<T>(first);
            List<T> _second = new List<T>(second);
            foreach (T element in first)
            {
                bool removed0 = _first.Remove(element);
                bool removed1 = _second.Remove(element);
                if (!removed0 || !removed1)
                {
                    return false;
                }
            }
            return _first.Count == 0 && _second.Count == 0;
        }

        public static IEnumerable<T> SetExcept<T>(this IEnumerable<T> collection, IEnumerable<T> values)
        {
            List<T> _values = new List<T>(values);
            foreach (T element in collection)
            {
                int index = -1;
                if ((index = _values.FindIndex(x => element.Equals(x))) > -1)
                {
                    _values.RemoveAt(index);
                }
                else
                {
                    yield return element;
                }
            }
        }

        public static object Cast(this IEnumerable collection, Type type)
        {
            MethodInfo cast = typeof(Enumerable).GetTypeInfo().GetDeclaredMethod("Cast").MakeGenericMethod(type);
            return cast.Invoke(null, new object[] { collection });
        }

        public static IEnumerable<TOutput> Convert<TInput, TOutput>(this IEnumerable<TInput> collection)
        {
            return Convert(collection, typeof(TOutput)).Cast<TOutput>();
        }

        public static IEnumerable Convert<TInput>(this IEnumerable<TInput> collection, Type type)
        {
            Delegate convert = (Delegate)typeof(OperatorCache<,>).GetTypeInfo().MakeGenericType(new Type[] { typeof(TInput), type }).GetTypeInfo().GetDeclaredProperty("Convert").GetValue(null);
            foreach(TInput value in collection)
            {
                yield return convert.DynamicInvoke(new object[] { value });
            }
        }
    }
}