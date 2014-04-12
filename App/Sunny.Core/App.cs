using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using Sunny.Core.Language;
using Sunny.Core.Mappers;
using Sunny.Core.Services;

namespace Sunny.Core
{
    public class App : MvxApplication
    {
        private readonly string _culture;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="culture">  The culture. </param>
        public App(string culture)
        {
            _culture = culture;
        }

        /// <summary>
        /// Initializes this object.
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CustomServiceBindings.RegisterBindings();
            MapperBindings.RegisterBindings();
            ServiceBindings.RegisterBindings();

            CustomTextProvider.InitializeAndCreateBuilder(GetType().Assembly, "AppResources/Text", "Sunny", "Shared");
            Business.Language.SetLocalLanguage(_culture);

            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}