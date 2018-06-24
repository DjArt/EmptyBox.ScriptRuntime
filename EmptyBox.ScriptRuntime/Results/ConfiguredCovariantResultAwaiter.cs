using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.ScriptRuntime.Results
{
    public struct ConfiguredCovariantResultAwaiter<TResult>
    {
        private readonly IAsyncCovariantResult<TResult> _value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ConfiguredCovariantResultAwaiter(IAsyncCovariantResult<TResult> value)
        {
            this._value = value;
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ConfiguredIAsyncCovariantResultAwaiter GetAwaiter()
        {
            return new ConfiguredIAsyncCovariantResultAwaiter(_value);
        }
        
        [StructLayout(LayoutKind.Auto)]
        public struct ConfiguredIAsyncCovariantResultAwaiter : ICriticalNotifyCompletion, INotifyCompletion
        {
            private readonly AsyncCovariantResult<TResult> _value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal ConfiguredIAsyncCovariantResultAwaiter(IAsyncCovariantResult<TResult> value)
            {
                _value = value as AsyncCovariantResult<TResult>;
            }

            /// <returns></returns>
            public bool IsCompleted
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return _value.IsCompleted;
                }
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TResult GetResult()
            {
                return _value.Result;
            }

            /// <param name="continuation"></param>
            public void OnCompleted(Action continuation)
            {
                object obj = _value._obj;
                if (obj is Task<TResult> task)
                {
                    task.ConfigureAwait(_value._continueOnCapturedContext).GetAwaiter().OnCompleted(continuation);
                }
                else if (obj != null)
                {
                    (obj as ICovariantResultSource<TResult>).OnCompleted(CovariantResultAwaiter<TResult>.s_invokeActionDelegate, continuation, _value._token, (CovariantResultSourceOnCompletedFlags)(2 | (_value._continueOnCapturedContext ? 1 : 0)));
                }
                else
                {
                    AsyncCovariantResult<TResult>.CompletedTask.ConfigureAwait(_value._continueOnCapturedContext).GetAwaiter().OnCompleted(continuation);
                }
            }
            
            public void UnsafeOnCompleted(Action continuation)
            {
                object obj = this._value._obj;
                if (obj is Task<TResult> task)
                {
                    task.ConfigureAwait(_value._continueOnCapturedContext).GetAwaiter().UnsafeOnCompleted(continuation);
                }
                else if (obj != null)
                {
                    (obj as ICovariantResultSource<TResult>).OnCompleted(CovariantResultAwaiter<TResult>.s_invokeActionDelegate, (object)continuation, this._value._token, this._value._continueOnCapturedContext ? CovariantResultSourceOnCompletedFlags.UseSchedulingContext : CovariantResultSourceOnCompletedFlags.None);
                }
                else
                {
                    AsyncCovariantResult<TResult>.CompletedTask.ConfigureAwait(this._value._continueOnCapturedContext).GetAwaiter().UnsafeOnCompleted(continuation);
                }
            }
        }
    }
}
