using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.ScriptRuntime.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Функция для сравнения двух одномерных массивов
        /// </summary>
        /// <typeparam name="T">Тип массива</typeparam>
        /// <param name="a1">Первый массив для сравнения</param>
        /// <param name="a2">Второй массив для сравнения</param>
        /// <param name="comparator">Функция, оценивающая равенство двух элементов</param>
        /// <returns></returns>
        public static bool Equals<T>(T[] a1, T[] a2, Func<T, T, bool> comparator)
        {
            if (a1.Length != a2.Length)
            {
                return false;
            }
            else
            {
                for (int i0 = 0; i0 < a1.Length; i0++)
                {
                    if (!comparator.Invoke(a1[i0], a2[i0]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static T[] Combine<T>(params T[][] arrs)
        {
            int l = 0;
            for (int i0 = 0; i0 < arrs.Length; i0++)
            {
                l += arrs[i0].Length;
            }
            T[] r = new T[l];
            l = 0;
            for (int i0 = 0; i0 < arrs.Length; i0++)
            {
                Array.Copy(arrs[i0], 0, r, l, arrs[i0].Length);
                l += arrs[i0].Length;
            }
            return r;
        }

        public static T[][] Expand<T>(T[] arr, int length)
        {
            if (arr.Length <= length)
            {
                throw new IndexOutOfRangeException("Поле length должно быть меньше длины массива.");
            }
            int count = (int)Math.Ceiling((double)arr.Length / length);
            int el = length - (length * count - arr.Length);
            T[][] r = new T[count][];
            for (int i0 = 0; i0 < count - 1; i0++)
            {
                r[i0] = new T[length];
                Array.Copy(arr, i0 * length, r[i0], 0, length);
            }
            r[count - 1] = new T[el];
            Array.Copy(arr, (count - 1) * length, r[count - 1], 0, el);
            return r;
        }

        public static int FindIndex<T>(this T[] arr, T val)
        {
            return FindIndex(arr, val, 0);
        }

        public static int FindIndex<T>(this T[] arr, T val, int startindex)
        {
            if (startindex >= arr.Length) throw new ArgumentException("Start index must be lower than array length.");
            for (int i0 = startindex; i0 < arr.Length; i0++)
            {
                if ((dynamic)val == arr[i0]) return i0;
            }
            return -1;
        }
    }
}
