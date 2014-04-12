using System;
using Sunny.Core.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace Sunny.Core
{
    public class MissionViewModel : BaseViewModel
    {
        public void Init(Domain.Mission mission)
        {
            Mission = mission;
        }

        public MissionViewModel()
        {
        }

        private Domain.Mission _mission;

        public Domain.Mission Mission
        {
            get
            {
                return _mission;
            }
            set
            {
                _mission = value;
                RaisePropertyChanged(() => Mission);
            }
        }

        private IList<Domain.Media> _mediaItems;

        public IList<Domain.Media> MediaItems
        {
            get
            {
                return _mediaItems;
            }
            set
            {
                _mediaItems = value;
                RaisePropertyChanged(() => MediaItems);
            }
        }
    }
}

