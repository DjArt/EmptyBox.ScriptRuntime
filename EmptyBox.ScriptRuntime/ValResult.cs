using System;

namespace EmptyBox.ScriptRuntime
{
    public struct ValResult<TResult, TStatus> where TResult : struct
    {
        public static implicit operator TResult? (ValResult<TResult, TStatus> x)
        {
            return x.Result;
        }

        public TResult? Result { get; private set; }
        public TStatus Status { get; private set; }
        public Exception Exception { get; private set; }

        public ValResult(TResult? result, TStatus status, Exception exception)
        {
            Result = result;
            Status = status;
            Exception = exception;
        }
    }
}
