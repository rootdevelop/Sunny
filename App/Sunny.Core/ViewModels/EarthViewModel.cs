using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Sunny.Core.Domain;
using Cirrious.MvvmCross.ViewModels;

namespace Sunny.Core.ViewModels
{
    public class EarthViewModel : BaseViewModel
    {
        public EarthViewModel()
        {
            GetMissions();
        }

        async void GetMissions()
        {
            Missions = (await Business.Mission.GetMissions()).Where(x => x.MainPage).ToList();
        }

        private IList<Mission> _missions;

        public IList<Mission> Missions
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

        public ICommand ShowAboutViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<AboutViewModel>());
            }
        }

        public ICommand ShowMissionCommand
        {
            get
            {
                return new MvxCommand<Mission>(mission => ShowViewModel<MissionViewModel>(new { id = mission.Id }));
            }
        }

        public ICommand ShowNewsViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<NewsOverviewViewModel>());
            }
        }

        public ICommand ShowStreamViewCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LiveStreamViewModel>());
            }
        }
    }
}