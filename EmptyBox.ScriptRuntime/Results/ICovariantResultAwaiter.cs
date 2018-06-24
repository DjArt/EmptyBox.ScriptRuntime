using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EmptyBox.ScriptRuntime.Results
{
    public interface ICovariantResultAwaiter<out TResult> : ICriticalNotifyCompletion, INotifyCompletion
    {
        bool IsCompleted { get; }
        TResult GetResult();
    }
}
