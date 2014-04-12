using System.Collections;
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
                return new MvxCommand<Domain.Mission>(mission => ShowViewModel<MissionViewModel>(new { id = mission.Id}));
            }
        }
    }
}