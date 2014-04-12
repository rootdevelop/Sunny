using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sunny.Core.Utils
{
    public static class Retry
    {
        public static async Task DoAsync(Action action, TimeSpan retryInterval, int retryCount = 3)
        {
            await DoAsync<object>(() =>
            {
                action();
                return null;
            }, retryInterval, retryCount);
        }

        public static async Task<T> DoAsync<T>(Func<Task<T>> action, TimeSpan retryInterval, int retryCount = 3)
        {
            return await await Task.Factory.StartNew(async () =>
            {
                var exceptions = new List<Exception>();

                for (int retry = 0; retry < retryCount; retry++)
                {
                    try
                    {
                        return await action();
                    }
                    catch (Exception ex) // Todo only catch for certain exception instead of blanket...
                    {
                        exceptions.Add(ex);
                    }

                     await TaskEx.Delay(retryInterval);
                }

                throw new AggregateException(exceptions);
            });
        }
        
    }
}
