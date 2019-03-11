using System;
using System.Collections.Generic;
using System.Text;

namespace EmptyBox.ScriptRuntime.Resolving
{
    public enum BinaryOperatorType : byte
    {
        Equality,
        Inequality,
        And,
        Or,
        XOr,
        GreaterThat,
        GreaterThenOrEqual,
        LessThan,
        LessThanOrEqual,
        Addition,
        Subtraction,
        Multiply,
        Division,
        Exponentiation,
        Modulo,
        LeftShift,
        RightShift,
    }
}
