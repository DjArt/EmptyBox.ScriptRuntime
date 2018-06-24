using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.ScriptRuntime.Results
{
    [AsyncMethodBuilder(typeof(AsyncCovariantResultMethodBuilder<>))]
    public interface IAsyncCovariantResult<out TResult>
    {
        ICovariantResultAwaiter<TResult> GetAwaiter();
        IAsyncCovariantResult<TResult> Preserve();
        bool IsCompleted { get; }
        bool IsCompletedSuccessfully { get; }
        bool IsFaulted { get; }
        bool IsCanceled { get; }
        TResult Result { get; }
        Task AsTask();
    }
}
