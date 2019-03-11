using System;
using System.Collections.Generic;
using System.Text;

namespace EmptyBox.ScriptRuntime.Resolving
{
    public enum UnaryOperatorType : byte
    {
        Negate,
        Not,
        Absolute,
        Cast
    }
}
