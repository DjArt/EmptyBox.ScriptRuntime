using System;
using System.Collections.Generic;
using System.Text;

namespace EmptyBox.ScriptRuntime.Results
{
    public interface ICovariantResultSource<out TResult>
    {
        CovariantResultSourceStatus GetStatus(short token);
        void OnCompleted(Action<object> continuation, object state, short token, CovariantResultSourceOnCompletedFlags flags);
        TResult GetResult(short token);
    }
}
