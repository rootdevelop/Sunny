using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using PushSharp.Client;

namespace Sunny.Droid.Views
{
    [Activity(Label = "")]
    public class EarthView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.EarthView);
            
			RegisterWithGCM();

        }

        private void RegisterWithGCM()
        {
            // Check to ensure everything's setup right
            PushClient.CheckDevice(this);
            PushClient.CheckManifest(this);

            // Register for push notifications
            System.Diagnostics.Debug.WriteLine("Registering...");
            PushClient.Register(this, Core.Constants.SenderID);
        }
    }
}