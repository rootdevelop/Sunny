using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Cirrious.CrossCore;
using Sunny.Core.Business;

namespace Sunny.WindowsStore.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MissionView : BaseView
    {
        public MissionView()
        {
            this.InitializeComponent();
            SunnySocket.MessageReceivedAsyncCallback = MessageReceivedAsyncCallback;
        }

        private void MessageReceivedAsyncCallback(string s, string s1)
        {
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ChatListBox.Items.Add(s + ": " + s1);

                ScrollToBottom();
            });
        }

        private void ScrollToBottom()
        {
            var selectedIndex = ChatListBox.Items.Count - 1;
            if (selectedIndex < 0)
                return;

            ChatListBox.SelectedIndex = selectedIndex;
            ChatListBox.ScrollIntoView(ChatListBox.SelectedItem);

            ChatListBox.UpdateLayout();

        }
    }
}
