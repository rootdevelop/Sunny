using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.ViewModels;
using Sunny.Core.Language;

namespace Sunny.Core.ViewModels
{
    /// <summary>
    ///    Defines the BaseViewModel type.
    /// </summary>
    public abstract class BaseViewModel : MvxViewModel
    {
        public IMvxLanguageBinder TextSource
        {
            get { return new MvxLanguageBinder(CustomTextProvider.GeneralNamespace, GetType().Name); }
        }

        public IMvxLanguageBinder SharedTextSource
        {
            get { return new MvxLanguageBinder(CustomTextProvider.GeneralNamespace, CustomTextProvider.SharedNamespace); }
        }
    }
}
