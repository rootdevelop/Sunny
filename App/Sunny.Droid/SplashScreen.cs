using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;
using ByteSmith.WindowsAzure.Messaging;
using PushSharp.Client;

namespace Sunny.Droid
{
    [Activity(
        Label = "Sunny"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}