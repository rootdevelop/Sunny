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
			
            
            var imageBorder = new UIButton(UIButtonType.System);
            imageBorder.Frame = new RectangleF(imageView.Frame.X - 1, imageView.Frame.Y - 1, imageView.Frame.Width + 2, imageView.Frame.Height + 2);
            imageBorder.BackgroundColor = UIColor.Clear;
            imageBorder.Layer.BorderColor = UIColor.FromRGBA(0.631f, 0.816f, 0.922f, 1.000f).CGColor;
            imageBorder.Layer.CornerRadius = 4;
            imageBorder.Layer.BorderWidth = 1;
            View.AddSubview(imageBorder);
            
            var webview = new UIWebView();
            webview.Frame = new RectangleF(450, 87, 554, 681);
            
            var webviewBorder = new UIButton(UIButtonType.System);
            webviewBorder.Frame = new RectangleF(webview.Frame.X - 1, webview.Frame.Y - 1, webview.Frame.Width + 2, webview.Frame.Height + 2);
            webviewBorder.BackgroundColor = UIColor.Clear;
            webviewBorder.Layer.BorderColor = UIColor.FromRGBA(0.631f, 0.816f, 0.922f, 1.000f).CGColor;
            webviewBorder.Layer.CornerRadius = 4;
            webviewBorder.Layer.BorderWidth = 1;
            View.AddSubview(webviewBorder);
            
            View.AddSubview(webview);
            
            var imageButton = new UIButton(UIButtonType.System);
            imageButton.Frame = new RectangleF(21, 485, 360, 60);
            imageButton.BackgroundColor = UIColor.Clear;
            imageButton.Layer.BorderColor = UIColor.FromRGBA(0.631f, 0.816f, 0.922f, 1.000f).CGColor;
            imageButton.Layer.CornerRadius = 4;
            imageButton.Layer.BorderWidth = 1;
            View.AddSubview(imageButton);

       
            var videoButton = new UIButton(UIButtonType.System);
            videoButton.Frame = new RectangleF(21, 605, 360, 60);
            videoButton.BackgroundColor = UIColor.Clear;
            videoButton.Layer.BorderColor = UIColor.FromRGBA(0.631f, 0.816f, 0.922f, 1.000f).CGColor;
            videoButton.Layer.CornerRadius = 4;
            videoButton.Layer.BorderWidth = 1;
            View.AddSubview(videoButton);

          
            
            // Perform any additional setup after loading the view, typically from a nib.
            var imageViewLoader = new MvxImageViewLoader(() => this.imageView);
                        
            var set = this.CreateBindingSet<MissionView, MissionViewModel>();
            set.Bind(imageViewLoader).To(vm => vm.Mission.ImageUri);
            set.Bind(title).To(vm => vm.Mission.Name);
            set.Bind(backButton).To("GoBackCommand"); 
            set.Apply();
            
            var html = ((MissionViewModel)ViewModel).Mission.Text;
            webview.LoadHtmlString(html, null);     
            
            webview.ShouldStartLoad += shouldStartLoad;
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

