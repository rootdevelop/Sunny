using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Sunny.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace Sunny.iOS.Views
{
    public partial class NewsOverviewView : MvxViewController
    {
        public NewsOverviewView() : base("NewsOverviewView", null)
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
        
            var source = new MvxSimpleTableViewSource(tableView, NewsTableViewCell.Key, NewsTableViewCell.Key);
            tableView.Source = source;           
            
            var set = this.CreateBindingSet<NewsOverviewView, NewsOverviewViewModel>();
            set.Bind(source).To(vm => vm.News); 
            set.Bind(backButton).To("GoBackCommand"); 
            set.Apply();
        }
    }
}

