using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Sunny.Core.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            AboutProjectText = "This app was created as part of the Space Apps Challenge 2014 organized by NASA. In a period of 2 days we worked trough the night to develop the Sunny App that allows you to follow space missions, subscribe to them and watch livestreams while chatting with other viewers.";

            AboutTechStuffText = "The app was created for iPad, Windows 8 & Android with Xamarin & MvvmCross. All of the code in this app is open-source!";
        }

        public string AboutProjectText { get; set; }
        public string AboutTechStuffText { get; set; }
    }
}