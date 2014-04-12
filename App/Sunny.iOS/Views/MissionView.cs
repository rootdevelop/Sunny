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
    public partial class MissionView : MvxViewController
    {
        public MissionView() : base("MissionView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            // Perform any additional setup after loading the view, typically from a nib.
            var imageViewLoader = new MvxImageViewLoader(() => this.imageView);
                        
            var set = this.CreateBindingSet<MissionView, MissionViewModel>();
            set.Bind(imageViewLoader).To(vm => vm.Mission.ImageUri);
            set.Bind(backButton).To("GoBackCommand"); 
            set.Apply();
            
            var html = ((MissionViewModel)ViewModel).Mission.Text;
            content.LoadHtmlString(html, null);     
            
            content.ShouldStartLoad += shouldStartLoad;
        }

        private bool shouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
        {
            if (navigationType == UIWebViewNavigationType.LinkClicked)
            {
                UIApplication.SharedApplication.OpenUrl(request.Url);
                return false;
            }
            
            return true;
        }
    }
}

