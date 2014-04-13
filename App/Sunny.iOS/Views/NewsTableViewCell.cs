using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Sunny.Core.Domain;

namespace Sunny.iOS
{
    public partial class NewsTableViewCell : MvxTableViewCell
    {
        public static readonly UINib Nib = UINib.FromName("NewsTableViewCell", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("NewsTableViewCell");

        public NewsTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<NewsTableViewCell, News>();
                set.Bind(title).To(x => x.Title);
                set.Bind(text).To(x => x.Text);
                set.Apply();
            });
        }

        public static NewsTableViewCell Create()
        {
            return (NewsTableViewCell)Nib.Instantiate(null, null)[0];
        }
    }
}

