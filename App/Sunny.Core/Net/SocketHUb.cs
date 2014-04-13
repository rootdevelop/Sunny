using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;

namespace Sunny.Core.Net
{
    public class SocketHub
    {
        public Action<string, string> MesssageReceivedAsyncCallback { get; set; }

        private HubConnection _connection = null;
        private IHubProxy _proxy = null;

        #region Constructor and invokes

        public SocketHub()
        {

        }

        /// <summary>
        /// Executes the award success action on a different thread, and waits for the result.
        /// </summary>
        private void InvokeMesssageReceivedAsyncCallback(string name, string message)
        {
            var handler = MesssageReceivedAsyncCallback;
            if (handler != null) handler(name, message);
        }

        #endregion

        public bool IsInitialized()
        {
            return _connection.State == ConnectionState.Connected;
        }

        public async Task<bool> Init()
        {
            if (_connection == null)
            {
                try
                {
                    _connection = new HubConnection("http://sunnyservices.cloudapp.net");
                    _connection.TransportConnectTimeout = new TimeSpan(0, 0, 0, 30);

                    _connection.Error += ex =>
                    {
                        Mvx.Resolve<IMvxTrace>().Trace(MvxTraceLevel.Error, "SocketHub._connection.Error += ex =>", ex.Message + " " + ex.StackTrace);
                    };

                    _proxy = _connection.CreateHubProxy("SunnyHub");

                    _proxy.On<string, string>("broadcastMessage", (s1, s2) =>
                    {
                        InvokeMesssageReceivedAsyncCallback(s1, s2);
                    });

                    // Start the connection
                    await _connection.Start();

                    return true;
                }
                catch (Exception ex)
                {
                    Mvx.Resolve<IMvxTrace>().Trace(MvxTraceLevel.Error, "SocketHub.Init", ex.Message + " " + ex.StackTrace);

                    _connection = null;
                    _proxy = null;

                    return false;
                }
            }

            return true;
        }

        public async Task<bool> SendMessage(string name, string message)
        {
            try
            {
                await _proxy.Invoke("Send", name, message);

                return true;
            }
            catch (Exception ex)
            {
                Mvx.Resolve<IMvxTrace>().Trace(MvxTraceLevel.Error, "SocketHub.SendMessage", ex.Message + " " + ex.StackTrace);

                return false;
            }
        }
    }
}
