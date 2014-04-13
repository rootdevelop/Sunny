using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Sunny.Core.ViewModels;
using Cirrious.MvvmCross.Binding.Touch.Views;
using MonoTouch.AVFoundation;
using Sunny.Core.Business;

namespace Sunny.iOS.Views
{
    public partial class MissionView : MvxViewController
    {
        AVPlayer _player;
        AVPlayerLayer _playerLayer;
        AVAsset _asset;
        AVPlayerItem _playerItem;

        public MissionView() : base("MissionView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            
            if (((MissionViewModel)ViewModel).Mission.LiveStream)
            {
                chatView.Hidden = false;
                messageField.Hidden = false;
                sendButton.Hidden = false;
                
                firstTitle.Hidden = true;
                secondTitle.Hidden = true;
                imageView.Hidden = true;
                
                var streamingUri = ((MissionViewModel)ViewModel).LiveStreamViewModel.LiveStreamUrl;
                
                _asset = AVAsset.FromUrl(NSUrl.FromString(streamingUri));
                _playerItem = new AVPlayerItem(_asset);
                
                _player = new AVPlayer(_playerItem);

                _playerLayer = AVPlayerLayer.FromPlayer(_player);
                _playerLayer.Frame = new RectangleF(21, 88, 602, 311);
                View.Layer.AddSublayer(_playerLayer);
                _player.Play();
                
                ((MissionViewModel)ViewModel).LiveStreamViewModel.UserName = "AstroBoy";
                
                chatView.Text = "";
                
                var previousText = string.Empty;
                
                SunnySocket.MessageReceivedAsyncCallback = (string name, string message) =>
                InvokeOnMainThread(() =>
                {
                    if (message != previousText)
                    {
                        chatView.Text = name + " - " + message + "\n" + chatView.Text;
                        chatView.Font = UIFont.FromName("HelveticaNeue-Bold", 15);
                        chatView.TextColor = UIColor.FromRGBA(0.027f, 0.102f, 0.389f, 1.000f);
                        previousText = message;
                    }
                });
                
                messageField.ShouldReturn += (x) =>
                {
                    ((MissionViewModel)ViewModel).LiveStreamViewModel.SendMessageCommand.Execute(null); 
                    return true;
                };
                    
                var set = this.CreateBindingSet<MissionView, MissionViewModel>();
                set.Bind(title).To(vm => vm.Mission.Name);
                set.Bind(messageField).To(vm => vm.LiveStreamViewModel.Message);
                set.Bind(backButton).To("GoBackCommand"); 
                set.Bind(sendButton).To("LiveStreamViewModel.SendMessageCommand"); 
                set.Apply();
                
                messageField.BecomeFirstResponder();
            }
            else
            {
                chatView.Hidden = true;
                messageField.Hidden = true;
                sendButton.Hidden = true;
                
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
            
                var newsButton = new UIButton(UIButtonType.System);
                newsButton.Frame = new RectangleF(21, 485, 360, 60);
                newsButton.BackgroundColor = UIColor.Clear;
                newsButton.Layer.BorderColor = UIColor.FromRGBA(0.631f, 0.816f, 0.922f, 1.000f).CGColor;
                newsButton.Layer.CornerRadius = 4;
                newsButton.Layer.BorderWidth = 1;
                View.AddSubview(newsButton);

       
                var notifyButton = new UIButton(UIButtonType.System);
                notifyButton.Frame = new RectangleF(21, 605, 360, 60);
                notifyButton.BackgroundColor = UIColor.Clear;
                notifyButton.Layer.BorderColor = UIColor.FromRGBA(0.631f, 0.816f, 0.922f, 1.000f).CGColor;
                notifyButton.Layer.CornerRadius = 4;
                notifyButton.Layer.BorderWidth = 1;
                View.AddSubview(notifyButton);

                notifyButton.TouchUpInside += (sender, e) =>
                {
                    notifyButton.Enabled = false;
                    new UIAlertView("Thank you", "You'll receive a notification when we go fly fly (or boom boom)", null, "Ok").Show();
                };
            
                var imageViewLoader = new MvxImageViewLoader(() => this.imageView);
                        
                var set = this.CreateBindingSet<MissionView, MissionViewModel>();
                set.Bind(imageViewLoader).To(vm => vm.Mission.ImageUri);
                set.Bind(title).To(vm => vm.Mission.Name);
                set.Bind(newsButton).To("ShowMissionNewsOverviewCommand");
                set.Bind(notifyButton).To("InitPushCommand"); 
                set.Bind(backButton).To("GoBackCommand"); 
                set.Apply();
            
                var html = ((MissionViewModel)ViewModel).Mission.Text;
                webview.LoadHtmlString(html, null);     
            
                webview.ShouldStartLoad += shouldStartLoad; 
            }
                   
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

        public override void ViewWillDisappear(bool animated)
        {
            if (_player != null)
                _player.Pause();
           
            base.ViewWillDisappear(animated);
        }
    }
}

