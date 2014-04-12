using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Sunny.Core.ViewModels;

namespace Sunny.iOS.Views
{
    [Register("MainView")]
    public sealed class MainView : MvxTabBarViewController
    {
        public MainView()
        {
            // need this additional call to ViewDidLoad because UIkit creates the view before the C# hierarchy has been constructed
            ViewDidLoad();
        }

        protected MainViewModel MainViewModel
        { get { return base.ViewModel as MainViewModel; } }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (ViewModel == null)
                return;

            var viewControllers = new UIViewController[]
            {
               // CreateTabFor("HomeView", "HomeView", MainViewModel.HomeViewView),

            };
            ViewControllers = viewControllers;
            CustomizableViewControllers = new UIViewController[] { };
            SelectedViewController = ViewControllers[0];

        }

        private int _createdSoFarCount = 0;

        private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            SetTitleAndTabBarItem(screen, title, imageName);
            controller.PushViewController(screen, false);
            return controller;
        }

        private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
        {
            screen.Title = title;
            screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle("Images/Tabs/" + imageName + ".png"),
                _createdSoFarCount);
            _createdSoFarCount++;
        }

        public void ShowinTab(IMvxTouchView view)
        {
            var currentNav = SelectedViewController as UINavigationController;
            currentNav.PushViewController(view as UIViewController, true);
        }
    }
}

