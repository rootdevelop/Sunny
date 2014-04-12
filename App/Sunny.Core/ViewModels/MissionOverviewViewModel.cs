using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Sunny.Core.ViewModels
{
    public class MissionOverviewViewModel : BaseViewModel
    {
        public MissionOverviewViewModel()
        {
            GetMissions();
        }

        async void GetMissions()
        {
            Missions = (await Business.Mission.GetMissions()).OrderByDescending(x => x.Date).ToList();
        }

        private IList<Domain.Mission> _missions;

        public IList<Domain.Mission> Missions
        {
            get
            {
                return _missions;
            }
            set
            {
                _missions = value;
                RaisePropertyChanged(() => Missions);
            }
        }

        public ICommand ShowMissionCommand
        {
            get
            { 
                return new MvxCommand<Domain.Mission>(mission => ShowViewModel<MissionViewModel>(new { id = mission.Id}));
            }
        }
    }
}
