using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Sunny.Core.Domain;
using Cirrious.MvvmCross.ViewModels;

namespace Sunny.Core.ViewModels
{
    public class AnnouncementOverviewViewModel : BaseViewModel
    {
        public AnnouncementOverviewViewModel()
        {
        }

        public void Init(int id)
        {
            GetAnnouncementForMissionId(id);
        }

        async void GetAnnouncementForMissionId(int id)
        {
            Announcements = (await Business.Announcement.GetAnnouncementForMissionId(id)).ToList();
        }

        private IList<Domain.Announcement> _announcements;

        public IList<Domain.Announcement> Announcements
        {
            get
            {
                return _announcements;
            }
            set
            {
                _announcements = value;
                RaisePropertyChanged(() => Announcements);
            }
        }

        //public ICommand AnnouncementDetailsCommand
        //{
        //    get
        //    {
        //        return new MvxCommand<Domain.Announcement>(announcement => ShowViewModel<AnnouncementDetailViewModel>(new { id = announcement.Id }));
        //    }
        //}
    }
}