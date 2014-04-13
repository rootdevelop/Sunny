using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Sunny.Core.ViewModels
{
    public class LiveStreamViewModel : BaseViewModel
    {
        private string _userName = String.Empty;
        private string _liveStreamUrl = String.Empty;

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

        public ICommand NewsDetailsCommand
        {
            get
            {
                return new MvxCommand<string>(message => {  });
            }
        }

        public LiveStreamViewModel()
        {
            LiveStreamUrl = "http://media.infozen.cshls.lldns.net/infozen/media/media.m3u8";
        }
    }
}
