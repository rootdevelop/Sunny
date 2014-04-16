using Android.Webkit;
using Android.Net;
using Android.Content;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;
using Sunny.Core.ViewModels;
using Android.OS;
using Android.App;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;

namespace Sunny.Droid.Views
{
	[Activity(Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
	public class AboutFragment : MvxFragment
	{
		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{        
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);

			var view = this.BindingInflate(Resource.Layout.AboutFragment, null);

			return view;
		}
	}
}