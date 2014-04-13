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
		MonoTouch.UIKit.UITextView chatView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIWebView content { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel firstTitle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField messageField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel secondTitle { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton sendButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel title { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (backButton != null) {
				backButton.Dispose ();
				backButton = null;
			}

			if (content != null) {
				content.Dispose ();
				content = null;
			}

			if (firstTitle != null) {
				firstTitle.Dispose ();
				firstTitle = null;
			}

			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (secondTitle != null) {
				secondTitle.Dispose ();
				secondTitle = null;
			}

			if (title != null) {
				title.Dispose ();
				title = null;
			}

			if (chatView != null) {
				chatView.Dispose ();
				chatView = null;
			}

			if (messageField != null) {
				messageField.Dispose ();
				messageField = null;
			}

			if (sendButton != null) {
				sendButton.Dispose ();
				sendButton = null;
			}
		}
	}
}
