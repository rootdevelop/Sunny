using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace Sunny.WindowsStore.Common
{
    public class SettingsFlyout
    {
        private readonly int _width;
        private Popup _popup;

        public SettingsFlyout(int width = 350)
        {
            _width = width;
        }

        /// <summary>
        /// Display a user control inside a screen popup window
        /// </summary>
        /// <param name="control"></param>
        public void ShowFlyout(UserControl control)
        {
            _popup = new Popup();
            _popup.Closed += OnPopupClosed;
            Window.Current.Activated += OnWindowActivated;
            _popup.IsLightDismissEnabled = true;
            _popup.Width = _width;
            _popup.Height = Window.Current.Bounds.Height;

            control.Width = _width;
            control.Height = Window.Current.Bounds.Height;

            _popup.Child = control;
            _popup.SetValue(Canvas.LeftProperty, Window.Current.Bounds.Width - _width);
            _popup.SetValue(Canvas.TopProperty, 0);
            _popup.IsOpen = true;
        }

        /// <summary>
        /// Close the popup when the app is deactivated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                _popup.IsOpen = false;
            }
        }

        /// <summary>
        /// Cleanup event handler when the popup closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPopupClosed(object sender, object e)
        {
            Window.Current.Activated -= OnWindowActivated;
        }
    }
}
