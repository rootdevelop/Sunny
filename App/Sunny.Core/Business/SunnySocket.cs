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

        public static async Task Init() 
        {
            _socketHub = new SocketHub();
            _socketHub.MesssageReceivedAsyncCallback = MessageReceivedAsyncCallback;

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
