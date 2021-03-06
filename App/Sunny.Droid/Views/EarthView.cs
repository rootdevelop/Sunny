using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using PushSharp.Client;
using Sunny.Core.ViewModels;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Android.Widget;
using Sunny.Droid.Utils;
using Android.Support.V4.Widget;
using Android.Support.V4.App;
using Android.Content.Res;
using Android.Views;
using System.Threading.Tasks;
using System;

namespace Sunny.Droid.Views
{
	[Activity(Theme = "@style/Theme.AppCompat.Light.DarkActionBar", LaunchMode = LaunchMode.SingleTop, ScreenOrientation = ScreenOrientation.Portrait)]
	public class EarthView : MvxActionBarActivity
		{
			DrawerLayout drawerLayout;
			ActionBarDrawerToggle drawerToggle;
			ListView drawerList;
			static string[] sections;

			protected EarthViewModel EarthViewModel
			{ get { return base.ViewModel as EarthViewModel; } }

			protected NewsOverviewViewModel NewsOverviewViewModel = new NewsOverviewViewModel();
			protected AboutViewModel AboutViewModel= new AboutViewModel();

			protected override void OnCreate(Bundle bundle)
			{
				base.OnCreate(bundle);
				SetContentView(Resource.Layout.Main);          

			sections = new[] { "Missions", "News", "About"};

				drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
				drawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow, (int)GravityFlags.Start);
				drawerList = FindViewById<ListView>(Resource.Id.flyout);
				drawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.drawer_list_item, sections);

				drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, Resource.Drawable.ic_drawer, Resource.String.drawer_open, Resource.String.drawer_close);
				drawerLayout.SetDrawerListener(drawerToggle);

				drawerList.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => ListItemClicked(e.Position);
				ListItemClicked(0);

				ActionBar.SetDisplayHomeAsUpEnabled(true);
				ActionBar.SetHomeButtonEnabled(true);

				RegisterWithGCM();
			}

			private async void Sync()
			{
				await Task.Delay(new TimeSpan(0, 0, 5));
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

			void ListItemClicked(int position)
			{
				SupportFragmentManager.PopBackStack(null, (int)PopBackStackFlags.Inclusive);

				//Log.Debug(Tag, "Item {0} has been selected.", position);

				MvxFragment fragment = null;
				switch (position)
				{
					case 0:
					fragment = new EarthViewFragment();
					fragment.ViewModel = EarthViewModel;
					break;
					case 1:
					fragment = new NewsFragment();
					fragment.ViewModel = NewsOverviewViewModel;
					break;
					case 2:
					fragment = new AboutFragment();
					fragment.ViewModel = AboutViewModel;
					break;
				}

				// Insert the fragment by replacing any existing fragment
				SupportFragmentManager.BeginTransaction()
					.Replace(Resource.Id.content_frame, fragment)
					.Commit();

				// Highlight the selected item, update the title, and close the drawer
				drawerList.SetItemChecked(position, true);
				ActionBar.Title = sections[position];
				drawerLayout.CloseDrawer(drawerList);
			}

			protected override void OnPostCreate(Bundle savedInstanceState)
			{
				base.OnPostCreate(savedInstanceState);
				drawerToggle.SyncState();
			}

			public override void OnConfigurationChanged(Configuration newConfig)
			{
				base.OnConfigurationChanged(newConfig);
				drawerToggle.OnConfigurationChanged(newConfig);
			}
			// Pass the event to ActionBarDrawerToggle, if it returns
			// true, then it has handled the app icon touch event
			public override bool OnOptionsItemSelected(IMenuItem item)
			{
				if (drawerToggle.OnOptionsItemSelected(item))
					return true;

				return base.OnOptionsItemSelected(item);
			}

			public override bool OnPrepareOptionsMenu(IMenu menu)
			{
				var drawerOpen = drawerLayout.IsDrawerOpen(drawerList);
				//when open don't show anything
				for (int i = 0; i < menu.Size(); i++)
					menu.GetItem(i).SetVisible(!drawerOpen);

				return base.OnPrepareOptionsMenu(menu);
			}

			public override void OnBackPressed()
			{
				base.OnBackPressed();
			}
		}
}