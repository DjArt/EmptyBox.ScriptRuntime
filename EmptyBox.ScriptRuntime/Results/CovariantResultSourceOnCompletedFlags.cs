using System;
using System.Collections.Generic;
using System.Text;

namespace EmptyBox.ScriptRuntime.Results
{
    [Flags]
    public enum CovariantResultSourceOnCompletedFlags
    {
        None = 0,
        UseSchedulingContext = 1,
        FlowExecutionContext = 2,
    }
}
