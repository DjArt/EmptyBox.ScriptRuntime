using System;

namespace EmptyBox.ScriptRuntime.Results
{
    public struct RefResult<TResult, TStatus> where TResult : class
    {
        public static implicit operator TResult(RefResult<TResult, TStatus> x)
        {
            return x.Result;
        }

        public TResult Result { get; }
        public TStatus Status { get; }
        public Exception Exception { get; }

        public RefResult(TResult result, TStatus status, Exception exception)
        {
            Result = result;
            Status = status;
            Exception = exception;
        }
    }
}
