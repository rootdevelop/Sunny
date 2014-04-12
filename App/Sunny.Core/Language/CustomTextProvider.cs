using System;
using System.Reflection;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;

namespace Sunny.Core.Language
{
    public class CustomTextProvider
    {
        internal static Assembly ProjectAssembly = null;
        internal static string RootFolderForResources = String.Empty;
        internal static string GeneralNamespace = String.Empty;
        internal static string SharedNamespace = String.Empty;

        public static void InitializeAndCreateBuilder(Assembly projectAssembly, string rootFolderForResources, string generalNamespace, string sharedNamespace)
        {
            ProjectAssembly = projectAssembly;
            RootFolderForResources = rootFolderForResources;
            GeneralNamespace = generalNamespace;
            SharedNamespace = sharedNamespace;

            var builder = new CustomTextProviderBuilder();

            Cirrious.CrossCore.Mvx.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            Cirrious.CrossCore.Mvx.RegisterSingleton(builder.TextProvider);
        }
    }
}
