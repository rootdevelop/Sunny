using Android.Webkit;
using Android.Net;
using Android.Content;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;
using Sunny.Core.ViewModels;

namespace Sunny.Droid.Views
{
	[Activity(Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
	public class AboutView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.MissionView);

			ActionBar.SetDisplayHomeAsUpEnabled(true);
			ActionBar.Title = "About";

			var html = (ViewModel as MissionViewModel).Mission.Text;

			var content = FindViewById<WebView>(Resource.Id.webView);
			content.LoadData(html, "text/html", "utf-8");
			content.SetWebViewClient(new CustomWebViewClient());
		}

		public class CustomWebViewClient : WebViewClient
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

		public override bool OnNavigateUp ()
		{
			Finish();
			return base.OnNavigateUp ();
		}

		//		public override bool OnCreateOptionsMenu (IMenu menu)
		//		{
		//			MenuInflater inflater = GetMenuInflater();
		//			inflater.Inflate(Resource.Id.subscribeMenuItem, menu);
		//			return base.OnCreateOptionsMenu (menu);
		//		}
		//
		//		public override bool OnOptionsItemSelected (IMenuItem item)
		//		{
		//			switch (item.ItemId) {
		//			case Resource.Id.subscribeMenuItem:
		//				onSubscribe();
		//				return true;
		//			default:
		//				return base.OnOptionsItemSelected (item);
		//			}
		//		}
		//
		//		private void onSubscribe()
		//		{
		//			(ViewModel as MissionViewModel).InitPushCommand();
		//		}

	}
}