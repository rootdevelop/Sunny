using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunny.Core.Net;

namespace Sunny.Core.Business
{
    public static class SunnySocket
    {
        public static Action<string, string> MessageReceivedAsyncCallback { get; set; }
        private static SocketHub _socketHub;

        static SunnySocket()
        {

        }

        /// <summary>
        /// Executes the award success action on a different thread, and waits for the result.
        /// </summary>
        private static void InvokeMessageReceivedAsyncCallback(string name, string message)
        {
            var handler = MessageReceivedAsyncCallback;
            if (handler != null) handler(name, message);
        }

        public static async Task Init() 
        {
            _socketHub = new SocketHub();
            _socketHub.MesssageReceivedAsyncCallback = (s, s1) =>
            {
                InvokeMessageReceivedAsyncCallback(s, s1);
            };

            await _socketHub.Init();
        }

        public static async void SendMessage(string name, string message)
        {
            if (_socketHub.IsInitialized())
            {
                await _socketHub.SendMessage(name, message);
            }
        }
    }
}
