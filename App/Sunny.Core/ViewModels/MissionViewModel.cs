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
        private NewsOverviewViewModel _newsOverviewViewModel;
        private AnnouncementOverviewViewModel _announcementOverviewViewModel;

        public NewsOverviewViewModel NewsOverviewViewModel
        {
            get { return _newsOverviewViewModel; }
            set
            {
                _newsOverviewViewModel = value;
                RaisePropertyChanged(() => NewsOverviewViewModel);
            }
        }

        public AnnouncementOverviewViewModel AnnouncementOverviewViewModel
        {
            get { return _announcementOverviewViewModel; }
            set
            {
                _announcementOverviewViewModel = value;
                RaisePropertyChanged(() => AnnouncementOverviewViewModel);
            }
        }

        public void Init(int id)
        {
            GetMission(id);
            NewsOverviewViewModel = new NewsOverviewViewModel(id);
            AnnouncementOverviewViewModel = new AnnouncementOverviewViewModel(id);
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

