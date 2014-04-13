using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Sunny.Core.Business;
using Cirrious.MvvmCross.ViewModels;
using Mission = Sunny.Core.Domain.Mission;

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
            await SunnySocket.Init();
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

        public ICommand ShowNewsOverviewViewCommand
        {
            get
            {
                var blaat = 0;
                return new MvxCommand(() => ShowViewModel<NewsOverviewViewModel>(new { result = blaat }));
            }
        }
    }
}