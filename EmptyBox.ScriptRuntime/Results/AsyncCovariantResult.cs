using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmptyBox.ScriptRuntime.Results
{
    [AsyncMethodBuilder(typeof(AsyncCovariantResultMethodBuilder<>))]
    internal sealed class AsyncCovariantResult<TResult> : IAsyncCovariantResult<TResult>
    {
        internal static Task CompletedTask { get; } = Task.Delay(0);

        private static Task<TResult> s_canceledTask;
        internal readonly object _obj;
        internal readonly TResult _result;
        internal readonly short _token;
        internal readonly bool _continueOnCapturedContext;
        
        public AsyncCovariantResult(TResult result)
        {
            _result = result;
            _obj = null;
            _continueOnCapturedContext = true;
            _token = 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AsyncCovariantResult(Task<TResult> task)
        {
            if (task == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _obj = task;
                _result = default;
                _continueOnCapturedContext = true;
                _token = 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AsyncCovariantResult(ICovariantResultSource<TResult> source, short token)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            else
            {
                _obj = source;
                _token = token;
                _result = default;
                _continueOnCapturedContext = true;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private AsyncCovariantResult(object obj, TResult result, short token, bool continueOnCapturedContext)
        {
            _obj = obj;
            _result = result;
            _token = token;
            _continueOnCapturedContext = continueOnCapturedContext;
        }

        public override int GetHashCode()
        {
            if (_obj != null)
            {
                return _obj.GetHashCode();
            }
            else if (_result == null)
            {
                return 0;
            }
            else
            {
                return _result.GetHashCode();
            }
        }

        public Task AsTask()
        {
            object obj = _obj;
            if (obj == null)
            {
                return Task.FromResult(_result);
            }
            else if (obj is Task<TResult> task)
            {
                return task;
            }
            else
            {
                return GetTaskForAsyncCovariantResultSource(obj as ICovariantResultSource<TResult>);
            }
        }

        public IAsyncCovariantResult<TResult> Preserve()
        {
            if (_obj != null)
            {
                return new AsyncCovariantResult<TResult>(AsTask() as Task<TResult>);
            }
            else
            {
                return this;
            }
        }

        private Task<TResult> GetTaskForAsyncCovariantResultSource(ICovariantResultSource<TResult> t)
        {
            CovariantResultSourceStatus status = t.GetStatus(_token);
            if (status == CovariantResultSourceStatus.Pending)
                return new AsyncCovariantResult<TResult>.AsyncCovariantResultSourceAsTask(t, _token).Task;
            try
            {
                return Task.FromResult<TResult>(t.GetResult(_token));
            }
            catch (Exception ex)
            {
                if (status == CovariantResultSourceStatus.Canceled)
                {
                    Task<TResult> task = AsyncCovariantResult<TResult>.s_canceledTask;
                    if (task == null)
                    {
                        TaskCompletionSource<TResult> completionSource = new TaskCompletionSource<TResult>();
                        completionSource.TrySetCanceled();
                        task = completionSource.Task;
                        AsyncCovariantResult<TResult>.s_canceledTask = task;
                    }
                    return task;
                }
                TaskCompletionSource<TResult> completionSource1 = new TaskCompletionSource<TResult>();
                completionSource1.TrySetException(ex);
                return completionSource1.Task;
            }
        }

        public bool IsCompleted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                object obj = _obj;
                if (obj == null)
                    return true;
                Task<TResult> task;
                if ((task = obj as Task<TResult>) != null)
                    return task.IsCompleted;
                return (uint)(obj as ICovariantResultSource<TResult>).GetStatus(_token) > 0U;
            }
        }

        public bool IsCompletedSuccessfully
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                object obj = _obj;
                if (obj == null)
                    return true;
                Task<TResult> task;
                if ((task = obj as Task<TResult>) != null)
                    return task.Status == TaskStatus.RanToCompletion;
                return (obj as ICovariantResultSource<TResult>).GetStatus(_token) == CovariantResultSourceStatus.Succeeded;
            }
        }

        public bool IsFaulted
        {
            get
            {
                object obj = _obj;
                if (obj == null)
                    return false;
                Task<TResult> task;
                if ((task = obj as Task<TResult>) != null)
                    return task.IsFaulted;
                return (obj as ICovariantResultSource<TResult>).GetStatus(_token) == CovariantResultSourceStatus.Faulted;
            }
        }

        public bool IsCanceled
        {
            get
            {
                object obj = _obj;
                if (obj == null)
                    return false;
                Task<TResult> task;
                if ((task = obj as Task<TResult>) != null)
                    return task.IsCanceled;
                return (obj as ICovariantResultSource<TResult>).GetStatus(_token) == CovariantResultSourceStatus.Canceled;
            }
        }

        public TResult Result
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                object obj = _obj;
                if (obj == null)
                    return _result;
                Task<TResult> task;
                if ((task = obj as Task<TResult>) != null)
                    return task.GetAwaiter().GetResult();
                return (obj as ICovariantResultSource<TResult>).GetResult(_token);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ICovariantResultAwaiter<TResult> GetAwaiter()
        {
            return new CovariantResultAwaiter<TResult>(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ConfiguredCovariantResultAwaiter<TResult> ConfigureAwait(bool continueOnCapturedContext)
        {
            return new ConfiguredCovariantResultAwaiter<TResult>(new AsyncCovariantResult<TResult>(_obj, _result, _token, continueOnCapturedContext));
        }

        public override string ToString()
        {
            if (IsCompletedSuccessfully)
            {
                TResult result = Result;
                if ((object)result != null)
                    return result.ToString();
            }
            return string.Empty;
        }

        private sealed class AsyncCovariantResultSourceAsTask : TaskCompletionSource<TResult>
        {
            private static readonly Action<object> s_completionAction = (state =>
            {
                AsyncCovariantResultSourceAsTask taskSourceAsTask;
                ICovariantResultSource<TResult> source;
                if ((taskSourceAsTask = state as AsyncCovariantResultSourceAsTask) == null || (source = taskSourceAsTask._source) == null)
                {
                    throw new ArgumentOutOfRangeException("state");
                }
                else
                {
                    taskSourceAsTask._source = null;
                    CovariantResultSourceStatus status = source.GetStatus(taskSourceAsTask._token);
                    try
                    {
                        taskSourceAsTask.TrySetResult(source.GetResult(taskSourceAsTask._token));
                    }
                    catch (Exception ex)
                    {
                        if (status == CovariantResultSourceStatus.Canceled)
                            taskSourceAsTask.TrySetCanceled();
                        else
                            taskSourceAsTask.TrySetException(ex);
                    }
                }
            });
            private ICovariantResultSource<TResult> _source;
            private readonly short _token;

            public AsyncCovariantResultSourceAsTask(ICovariantResultSource<TResult> source, short token)
            {
                _source = source;
                _token = token;
                source.OnCompleted(s_completionAction, (object)this, token, CovariantResultSourceOnCompletedFlags.None);
            }
        }
    }
}
