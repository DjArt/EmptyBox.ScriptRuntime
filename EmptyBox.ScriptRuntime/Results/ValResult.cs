using System;

namespace EmptyBox.ScriptRuntime.Results
{
    public struct ValResult<TResult, TStatus> where TResult : struct
    {
        public static implicit operator TResult? (ValResult<TResult, TStatus> x)
        {
            return x.Result;
        }

        public TResult? Result { get; }
        public TStatus Status { get; }
        public Exception Exception { get; }

        public ValResult(TResult? result, TStatus status, Exception exception)
        {
            Result = result;
            Status = status;
            Exception = exception;
        }
    }
}
