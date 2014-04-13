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
        private string _userName = String.Empty;
        private string _message = String.Empty;
        private string _liveStreamUrl = String.Empty;

        public LiveStreamViewModel()
        {
            LiveStreamUrl = "http://media.infozen.cshls.lldns.net/infozen/media/media.m3u8";
            InitSocket();
        }

        private async void InitSocket()
        {
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

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

        public ICommand SendMessageCommand
        {
            get
            {
                return new MvxCommand(() => { SunnySocket.SendMessage(UserName, Message); });
            }
        }
    }
}
