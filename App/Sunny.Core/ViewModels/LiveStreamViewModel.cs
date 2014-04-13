using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Sunny.Core.Business;

namespace Sunny.Core.ViewModels
{
    public class LiveStreamViewModel : BaseViewModel
    {
        public static Action<string, string> MessageReceivedAsyncCallback { get; set; }
        private string _userName = String.Empty;
        private string _liveStreamUrl = String.Empty;

        public LiveStreamViewModel()
        {
            LiveStreamUrl = "http://media.infozen.cshls.lldns.net/infozen/media/media.m3u8";
            InitSocket();
        }

        private async void InitSocket()
        {
            SunnySocket.MessageReceivedAsyncCallback = MessageReceivedAsyncCallback;

            await SunnySocket.Init();
        }

        public string LiveStreamUrl
        {
            get { return _liveStreamUrl; }
            set
            {
                _liveStreamUrl = value;
                RaisePropertyChanged(() => LiveStreamUrl);
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public ICommand SendMessageCommand
        {
            get
            {
                return new MvxCommand<string>(message => { SunnySocket.SendMessage(UserName, message); });
            }
        }
    }
}
