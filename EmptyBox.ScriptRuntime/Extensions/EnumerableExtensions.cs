using EmptyBox.ScriptRuntime.Resolving;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EmptyBox.ScriptRuntime.Extensions
{
    public static class EnumerableExtensions
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
                if (!result.Exists(x => OperatorCache<T, T, bool>.Equality(x, value)))
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

        /// <summary>
        /// Возвращает элементы, порядковые номера которых не находятся в списке исключений.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Исходное множество</param>
        /// <param name="indexes">Исключённые индексы</param>
        /// <returns></returns>
        public static IEnumerable<T> TakeWithout<T>(this IEnumerable<T> source, IEnumerable<int> indexes)
        {
            if (indexes != null && indexes.Count() > 0)
            {
                IEnumerable<T> iterator()
                {
                    IEnumerable<int> sorted = indexes.OrderBy(x => x);
                    IEnumerator<int> enumerator = sorted.GetEnumerator();
                    bool lastIndex = false;
                    for (int i0 = 0; i0 < source.Count(); i0++)
                    {
                        if (!lastIndex && i0 == enumerator.Current)
                        {
                            lastIndex = enumerator.MoveNext();
                        }
                        else
                        {
                            yield return source.ElementAt(i0);
                        }
                    }
                    yield break;
                }
                return iterator();
            }
            else
            {
                return source;
            }
        }
    }
}