using System;
using Sunny.Core.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Sunny.Core.ViewModels
{
    public class MissionViewModel : BaseViewModel
    {
        public void Init(int id)
        {
            GetMission(id);
        }

        private async void GetMission(int id)
        {
            Mission = await Business.Mission.GetMission(id);
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

