using System.Drawing;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.UIKit;

namespace Sunny.iOS.Views
{
    public partial class HomeViewView : MvxViewController
    {
        public HomeViewView() : base("HomeViewView", null)
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
            
            var label = new UILabel();
            label.Frame = new RectangleF(20, 200, 280, 40);
            View.AddSubview(label);
            
            //var set = this.CreateBindingSet<HomeViewView, HomeViewViewModel>();
            //set.Bind(label).To(vm => vm.Hello); 
            //set.Apply();
        }
    }
}

