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
	[Register ("EarthView")]
	partial class EarthView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton aboutButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton liveStreamsButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton newsButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (aboutButton != null) {
				aboutButton.Dispose ();
				aboutButton = null;
			}

			if (liveStreamsButton != null) {
				liveStreamsButton.Dispose ();
				liveStreamsButton = null;
			}

			if (newsButton != null) {
				newsButton.Dispose ();
				newsButton = null;
			}
		}
	}
}
