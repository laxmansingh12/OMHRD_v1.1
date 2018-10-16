using System;
using System.Diagnostics;
using System.Threading;

namespace Business.Common
{
    public class AsyncResult : IDisposable, IAsyncResult
    {
        AsyncCallback callback;

        object state;

        ManualResetEvent waitHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResult"/>
        /// with provided <paramref name="callback"/>, <paramref name="state"/>.
        /// </summary>
        /// <param name="callback">The callback delegate to be called when
        /// the asynchronous operation is completed.</param>
        /// <param name="state"></param>
        public AsyncResult(AsyncCallback callback, object state)
        {
            this.callback = callback;
            this.state = state;
            this.waitHandle = new ManualResetEvent(false);
        }

        /// <summary>
        /// Finilizes the asynchronous operation.
        /// </summary>
        public void Complete()
        {
            try
            {
                waitHandle.Set();
                if (null != callback)
                    callback(this);
            }
            catch
            { }
        }

        /// <summary>
        /// Releases the resources acquired by the
        /// <see cref="AsyncResult"/>.
        /// </summary>
        public void Dispose()
        {
            if (null != waitHandle)
            {
                waitHandle.Close();
                waitHandle = null;
                state = null;
                callback = null;
            }
        }

        /// <summary>
        /// Validates the <see cref="AsyncResult"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The object is invalid state.
        /// </exception>
        public void Validate()
        {
            if (null == waitHandle)
                throw new InvalidOperationException();
        }

        /// <summary>
        /// Gets a user-defined object that qualifies or contains information
        /// about the asynchronous operation.
        /// </summary>
        public object AsyncState
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// Gets the <see cref="ManualResetEvent"/> that is used to wait for
        /// an asynchronous operation to complete.
        /// </summary>
        public ManualResetEvent AsyncWaitHandle
        {
            get
            {
                return waitHandle;
            }
        }

        /// <summary>
        /// Gets the <see cref="WaitHandle"/> that is used to wait for the
        /// asynchronous operation to complete.
        /// </summary>
        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get
            {
                return this.AsyncWaitHandle;
            }
        }

        /// <summary>
        /// Gets an indication of whether the asynchronous operation completed
        /// synchronously.
        /// </summary>
        public bool CompletedSynchronously
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets an indication whether the asynchronous operation has completed.
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                return waitHandle.WaitOne(0, false);
            }
        }
    }
}
