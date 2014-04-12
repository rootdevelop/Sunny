using System.Globalization;
using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.UIKit;
using Sunny.Core;
using Sunny.iOS.Views;

namespace Sunny.iOS
{
    public class Setup : MvxTouchSetup
    {
        private MvxApplicationDelegate _applicationDelegate;
        private UIWindow _window;

        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
            _applicationDelegate = applicationDelegate;
            _window = window;
        }

        protected override System.Collections.Generic.List<System.Reflection.Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = base.ValueConverterAssemblies;
                toReturn.Add(typeof(MvxLanguageConverter).Assembly);
                return toReturn;
            }
        }

        protected override IMvxApplication CreateApp()
        {
            var culture = CultureInfo.CurrentCulture;
            return new App(culture.Name);
        }

        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            return new NavigationPresenter(_applicationDelegate, _window);
        }
    }

    public class NavigationPresenter : MvxTouchViewPresenter
    {
        public NavigationPresenter(UIApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override UINavigationController CreateNavigationController(UIViewController viewController)
        {
            var navBar = base.CreateNavigationController(viewController);
            navBar.NavigationBarHidden = true;
            return navBar;
        }

        private MainView _mainView;

        /// <summary>
        /// The views below will be shown within the active tab on navigation. Other views will be shown as new windows.
        /// </summary>
        /// <param name="view"></param>
        public override void Show(Cirrious.MvvmCross.Touch.Views.IMvxTouchView view)
        {
            if (view is MainView)
            {
                _mainView = view as MainView;
            }

//          if (view is SubView) {
//              if (_mainView != null) {
//                  _mainView.ShowinTab (view);
//              }
//              return;
//          }


            base.Show(view);
        }
    }
}