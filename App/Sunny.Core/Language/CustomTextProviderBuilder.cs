using System.Collections.Generic;
using System.Linq;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;

namespace Sunny.Core.Language
{
    public class CustomTextProviderBuilder : MvxTextProviderBuilder
    {
        public CustomTextProviderBuilder()
            : base(CustomTextProvider.GeneralNamespace, CustomTextProvider.RootFolderForResources)
        {
        }

        protected override IDictionary<string, string> ResourceFiles
        {
            get
            {
                var dictionary = CustomTextProvider.ProjectAssembly
                    .CreatableTypes()
                    .Where(t => t.Name.EndsWith("ViewModel"))
                    .ToDictionary(t => t.Name, t => t.Name);

                dictionary[CustomTextProvider.SharedNamespace] = CustomTextProvider.SharedNamespace;
                return dictionary;
            }
        }
    }
}
