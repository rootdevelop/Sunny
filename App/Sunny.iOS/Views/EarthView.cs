using System;
using System.Drawing;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Sunny.Core.ViewModels;
using System.Collections.Generic;
using Sunny.Core.Domain;
using SatelliteMenu;
using Cirrious.MvvmCross.Binding.BindingContext;
using MonoTouch.MediaPlayer;
using MonoTouch.Foundation;

namespace Sunny.iOS.Views
{
    public partial class EarthView : MvxViewController
    {
        public EarthView() : base("EarthView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
            
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            // Perform any additional setup after loading the view, typically from a nib.
            
            AddSateliteMenu();
            AddMissions();
            
            liveStreamsButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var videoPlayer = new MPMoviePlayerViewController();
                videoPlayer.MoviePlayer.ContentUrl = NSUrl.FromString("http://media.infozen.cshls.lldns.net/infozen/media/media.m3u8");
                PresentMoviePlayerViewController(videoPlayer);
            };
            
            var set = this.CreateBindingSet<EarthView, EarthViewModel>();
            set.Bind(aboutButton).To("ShowAboutViewCommand"); 
            set.Bind(newsButton).To("ShowNewsViewCommand"); 
            set.Apply();

        }

        void AddMissions()
        {
            IList<Core.Domain.Mission> missions;
            
            ((EarthViewModel)ViewModel).PropertyChanged += (sender, e) =>
            {
                missions = ((EarthViewModel)ViewModel).Missions;
                
                if (missions != null)
                {
                    foreach (var mission in missions)
                    {                    
                        var missionView = new UIButton(UIButtonType.System);
                        missionView.SetTitle(mission.Name, UIControlState.Normal);
                        missionView.Frame = new RectangleF(mission.X, mission.Y, 100, 40);
                        missionView.BackgroundColor = UIColor.Clear;
                        missionView.SetTitleColor(UIColor.FromRGBA(0.537f, 0.816f, 0.992f, 1.000f), UIControlState.Normal);
                        missionView.Layer.BorderColor = UIColor.FromRGBA(0.008f, 0.137f, 0.620f, 1.000f).CGColor;
                        missionView.Layer.CornerRadius = 4;
                        missionView.Layer.BorderWidth = 1;
                    
                        missionView.TouchUpInside += (s, ee) =>
                        {
                            ((EarthViewModel)ViewModel).ShowMissionCommand.Execute(mission);
                        };
                    
                        View.AddSubview(missionView);
                    }
                }
            };
        }

        void AddSateliteMenu()
        {
            var image = UIImage.FromBundle("sun.png");
            var yPos = View.Frame.Height - 100 - 10;
            var frame = new RectangleF(10, yPos, 100, 100);

            var items = new []
            { 
                new SatelliteMenuButtonItem(UIImage.FromBundle("moon.png"), 1, "About"),
                new SatelliteMenuButtonItem(UIImage.FromBundle("earth.png"), 2, "About"),
                new SatelliteMenuButtonItem(UIImage.FromBundle("mars.png"), 3, "About"),
            };

            var button = new SatelliteMenuButton(View, image, items, frame);

            button.MenuItemClick += (_, args) =>
            {
                Console.WriteLine("{0} was clicked!", args.MenuItem.Name);
            };

            View.AddSubview(button);
        }
    }
}

