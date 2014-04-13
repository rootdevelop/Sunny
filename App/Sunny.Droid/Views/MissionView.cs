using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Sunny.Droid.Views
{
    [Activity(Label = "")]
	public class MissionView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.MissionView);
        }
    }
}