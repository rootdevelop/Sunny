using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Sunny.Core.ViewModels;
using System.Runtime.InteropServices;
using System.Collections;
using Mono.Security.X509;
using System.Collections.Generic;
using Sunny.Core.Domain;
using System.Windows;

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
    }
}

