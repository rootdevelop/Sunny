using System;
using Sunny.Core.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace Sunny.Core.ViewModels
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
    }
}

