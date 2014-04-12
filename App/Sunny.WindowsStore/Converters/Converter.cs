using Cirrious.CrossCore.WindowsStore.Converters;
using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.Plugins.Visibility;
using Sunny.Core.Converters;

namespace Sunny.WindowsStore.Converters
{
    public class NativeLanguageConverter : MvxNativeValueConverter<MvxLanguageConverter>
    {
    }

    public class NativeVisibilityConverter : MvxNativeValueConverter<MvxVisibilityValueConverter>
    {
    }

    public class NativeInvertedVisibilityConverter : MvxNativeValueConverter<MvxInvertedVisibilityValueConverter>
    {
    }

    public class NativeInverseBooleanConverter : MvxNativeValueConverter<InverseBooleanConverter>
    {
    }
}
