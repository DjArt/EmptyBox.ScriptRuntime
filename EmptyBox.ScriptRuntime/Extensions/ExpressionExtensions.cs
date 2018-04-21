using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EmptyBox.ScriptRuntime.Extensions
{
    public static class ExpressionExtensions
    {
        public static bool HasSameParameter(BinaryExpression exp0, BinaryExpression exp1)
        {
            return exp0.Left == exp1.Left || exp0.Left == exp1.Right || exp0.Right == exp1.Left || exp0.Right == exp1.Right;
        }

        public static int HasParameter(this BinaryExpression exp0, ParameterExpression exp1)
        {
            return exp0.Left == exp1 ? -1 : exp0.Right == exp1 ? 1 : 0;
        }
    }
}
