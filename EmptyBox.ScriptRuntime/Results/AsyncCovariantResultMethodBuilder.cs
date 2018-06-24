using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

namespace EmptyBox.ScriptRuntime.Results
{
    public sealed class AsyncCovariantResultMethodBuilder<TResult>
    {
        public static AsyncCovariantResultMethodBuilder<TResult> Create()
        {
            return new AsyncCovariantResultMethodBuilder<TResult>();
        }

        private AsyncTaskMethodBuilder<TResult> _methodBuilder;
        private TResult Result;
        private bool HaveResult;
        private bool UseBuilder;
        
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            _methodBuilder.Start(ref stateMachine);
        }
        
        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            _methodBuilder.SetStateMachine(stateMachine);
        }
        
        public void SetResult(TResult result)
        {
            if (UseBuilder)
            {
                _methodBuilder.SetResult(result);
            }
            else
            {
                Result = result;
                HaveResult = true;
            }
        }
        
        public void SetException(Exception exception)
        {
            _methodBuilder.SetException(exception);
        }
        
        public IAsyncCovariantResult<TResult> Task
        {
            get
            {
                if (HaveResult)
                {
                    return new AsyncCovariantResult<TResult>(Result);
                }
                else
                {
                    UseBuilder = true;
                    return new AsyncCovariantResult<TResult>(_methodBuilder.Task);
                }
            }
        }

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            UseBuilder = true;
            _methodBuilder.AwaitOnCompleted(ref awaiter, ref stateMachine);
        }

        [SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
        {
            UseBuilder = true;
            _methodBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
        }
    }
}
