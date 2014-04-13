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
        private string _userName;
        private string _liveStreamUrl;

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
    }
}
