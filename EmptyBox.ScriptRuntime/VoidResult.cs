using System;

namespace EmptyBox.ScriptRuntime
{
    public struct VoidResult<TStatus>
    {
        public TStatus Status { get; private set; }
        public Exception Exception { get; private set; }

        public VoidResult(TStatus status, Exception exception)
        {
            Status = status;
            Exception = exception;
        }
    }
}
