using System;
using System.Drawing;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Sunny.Core.ViewModels;
using System.Collections.Generic;
using Sunny.Core.Domain;
using SatelliteMenu;

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

        }

        void AddMissions()
        {
            IList<Core.Domain.Mission> missions;
            
            ((EarthViewModel)ViewModel).PropertyChanged += (sender, e) =>
            {
                missions = ((EarthViewModel)ViewModel).Missions;
                
                foreach (var mission in missions)
                {                    
                    var missionView = new UIButton(UIButtonType.System);
                    missionView.SetTitle(mission.Name, UIControlState.Normal);
                    missionView.Frame = new RectangleF(100, 100, 300, 40);
                    missionView.BackgroundColor = UIColor.Clear;
                    missionView.Layer.BorderColor = UIColor.Blue.CGColor;
                    missionView.Layer.CornerRadius = 4;
                    missionView.Layer.BorderWidth = 1;
                    
                    missionView.TouchUpInside += (s, ee) =>
                    {
                        ((EarthViewModel)ViewModel).ShowMissionCommand.Execute(mission);
                    };
                    
                    View.AddSubview(missionView);
                }
            };
        }

        void AddSateliteMenu()
        {
            var image = UIImage.FromBundle("menu.png");
            var yPos = View.Frame.Height - image.Size.Height - 10;
            var frame = new RectangleF(10, yPos, 30, 30);

            var items = new []
            { 
                new SatelliteMenuButtonItem(UIImage.FromBundle("menu.png"), 1, "Search"),
                new SatelliteMenuButtonItem(UIImage.FromBundle("menu.png"), 2, "Update"),
                new SatelliteMenuButtonItem(UIImage.FromBundle("menu.png"), 3, "Share"),
                new SatelliteMenuButtonItem(UIImage.FromBundle("menu.png"), 4, "Post"),
                new SatelliteMenuButtonItem(UIImage.FromBundle("menu.png"), 5, "Reload"),
                new SatelliteMenuButtonItem(UIImage.FromBundle("menu.png"), 6, "Settingd")
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

