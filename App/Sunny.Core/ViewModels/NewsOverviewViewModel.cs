using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Sunny.Core.Domain;
using Cirrious.MvvmCross.ViewModels;

namespace Sunny.Core.ViewModels
{
    public class NewsOverviewViewModel : BaseViewModel
    {
        public void Init(int id)
        {
            GetNewsForMissionId(id);
        }

        public NewsOverviewViewModel(int id = 0)
        {
            GetNewsForMissionId(id);
        }

        async void GetNewsForMissionId(int id)
        {
            News = (await Business.News.GetNewsForMissionId(id)).ToList();
        }

        private IList<Domain.News> _news;

        public IList<Domain.News> News
        {
            get
            {
                return _news;
            }
            set
            {
                _news = value;
                RaisePropertyChanged(() => News);
            }
        }
        //public ICommand NewsDetailsCommand
        //{
        //    get
        //    {
        //        return new MvxCommand<Domain.News>(news => ShowViewModel<NewsDetailViewModel>(new { id = news.Id }));
        //    }
        //}
    }
}