using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Sunny.Core.ViewModels;

namespace Sunny.iOS.Views
{
    public partial class MissionView : MvxViewController
    {
        public MissionView() : base("MissionView", null)
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
            
            
            var set = this.CreateBindingSet<MissionView, MissionViewModel>();
            set.Bind(backButton).To("GoBackCommand"); 
            set.Apply();
        }

        private void HandlePageControlHeadValueChanged(object sender, EventArgs e)
        {
            this.scrollViewHead.SetContentOffset(new PointF(this.pageControlHead.CurrentPage * this.scrollViewHead.Frame.Width, 0), true);
        }
    }
}

