using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmptyBox.ScriptRuntime.Results;

namespace EmptyBox.ScriptRuntime.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Test2();
            Console.ReadKey();
            IAsyncCovariantResult<object> objects = Test();
            object curr = objects.Result;
            Console.ReadKey();
        }

        static async IAsyncCovariantResult<IEnumerable<string>> Test()
        {
            await Task.Yield();
            List<string> res = new List<string>()
            {
                "123",
                "456",
                "789"
            };
            await Task.Delay(500);
            return res;
        }

        static async void Test2()
        {
            IEnumerable<object> a = await Test();
            foreach (object d in a) Console.WriteLine(d);
        }
    }
}
