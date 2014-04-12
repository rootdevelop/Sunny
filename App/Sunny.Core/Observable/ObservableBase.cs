using System.Collections.Generic;
using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.ViewModels;
using Sunny.Core.Language;
using System.Runtime.CompilerServices;

namespace Sunny.Core.Observable
{
    public class ObservableBase : MvxNotifyPropertyChanged
    {
        public IMvxLanguageBinder TextSource
        {
            get { return new MvxLanguageBinder(CustomTextProvider.GeneralNamespace, GetType().Name); }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            RaisePropertyChanged(name);
            return true;
        }
    }
}
