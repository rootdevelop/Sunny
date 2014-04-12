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
    [Register("MissionView")]
    partial class MissionView
    {
        [Outlet]
        MonoTouch.UIKit.UIButton backButton { get; set; }

        [Outlet]
        MonoTouch.UIKit.UIPageControl pageControlHead { get; set; }

        [Outlet]
        MonoTouch.UIKit.UIScrollView scrollViewHead { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (backButton != null)
            {
                backButton.Dispose();
                backButton = null;
            }

            if (pageControlHead != null)
            {
                pageControlHead.Dispose();
                pageControlHead = null;
            }

            if (scrollViewHead != null)
            {
                scrollViewHead.Dispose();
                scrollViewHead = null;
            }
        }
    }
}
