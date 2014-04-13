using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Sunny.Core.ViewModels;
using Android.Webkit;
using Android.Net;
using Android.Content;

namespace Sunny.Droid.Views
{
    [Activity(Label = "")]
	public class MissionView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.MissionView);

			var html = (ViewModel as MissionViewModel).Mission.Text;

			var content = FindViewById<WebView>(Resource.Id.webView);
			content.LoadData(html, "text/html", "utf-8");
			//            content.SetBackgroundColor(new Color(0x00000000));
			//            content.SetLayerType(LayerType.Software, null);
			content.SetWebViewClient(new LisztWebViewClient());
        }

		public class LisztWebViewClient : WebViewClient
		{
			public override bool ShouldOverrideUrlLoading(WebView view, string url)
			{
				if (url != null && (url.StartsWith("http://") || url.StartsWith("https://")))
				{
					view.Context.StartActivity(
						new Intent(Intent.ActionView, Uri.Parse(url)));
					return true;
				}
				return false;
			}
		}
    }
}