// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Sunny.iOS.Views
{
	[Register ("MissionView")]
	partial class MissionView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton backButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIWebView content { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (backButton != null) {
				backButton.Dispose ();
				backButton = null;
			}

			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (content != null) {
				content.Dispose ();
				content = null;
			}
		}
	}
}
