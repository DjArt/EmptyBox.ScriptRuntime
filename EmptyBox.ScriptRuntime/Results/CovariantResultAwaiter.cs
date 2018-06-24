using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.ScriptRuntime.Results
{
    public struct CovariantResultAwaiter<TResult> : ICovariantResultAwaiter<TResult>
    {
        internal static readonly Action<object> s_invokeActionDelegate = (state =>
        {
            Action action;
            if ((action = state as Action) == null)
                throw new ArgumentOutOfRangeException("state");
            else
                action();
        });

        private readonly AsyncCovariantResult<TResult> _value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal CovariantResultAwaiter(AsyncCovariantResult<TResult> value)
        {
            _value = value;
        }

        public bool IsCompleted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this._value.IsCompleted;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TResult GetResult()
        {
            return this._value.Result;
        }
        
        public void OnCompleted(Action continuation)
        {
            object obj = _value._obj;
            if (obj is Task<TResult> task)
                task.GetAwaiter().OnCompleted(continuation);
            else if (obj != null)
                (obj as ICovariantResultSource<TResult>).OnCompleted(s_invokeActionDelegate, continuation, _value._token, CovariantResultSourceOnCompletedFlags.UseSchedulingContext | CovariantResultSourceOnCompletedFlags.FlowExecutionContext);
            else
                AsyncCovariantResult<TResult>.CompletedTask.GetAwaiter().OnCompleted(continuation);
        }

        /// <param name="continuation"></param>
        public void UnsafeOnCompleted(Action continuation)
        {
            object obj = _value._obj;
            if (obj is Task<TResult> task)
                task.GetAwaiter().UnsafeOnCompleted(continuation);
            else if (obj != null)
                (obj as ICovariantResultSource<TResult>).OnCompleted(s_invokeActionDelegate, continuation, _value._token, CovariantResultSourceOnCompletedFlags.UseSchedulingContext);
            else
                AsyncCovariantResult<TResult>.CompletedTask.GetAwaiter().UnsafeOnCompleted(continuation);
        }
    }
}
