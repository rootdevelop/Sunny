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
    [Register("AboutView")]
    partial class AboutView
    {
        [Outlet]
        MonoTouch.UIKit.UIButton backButton { get; set; }

        [Outlet]
        MonoTouch.UIKit.UIButton forkmeButton { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (backButton != null)
            {
                backButton.Dispose();
                backButton = null;
            }

            if (forkmeButton != null)
            {
                forkmeButton.Dispose();
                forkmeButton = null;
            }
        }
    }
}
