using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Sunny.Core.ViewModels;

namespace Sunny.iOS.Views
{
    public partial class AboutView : MvxViewController
    {
        public AboutView() : base("AboutView", null)
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
            
            var set = this.CreateBindingSet<AboutView, AboutViewModel>();
            set.Bind(backButton).To("GoBackCommand"); 
            set.Apply();
        }
    }
}

