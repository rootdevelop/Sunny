namespace Sunny.Core.Services
{
    /// <summary>
    /// Service bindings.
    /// This class contains the DI registers which makes the SqlLite service magic work.
    /// </summary>
    public static class ServiceBindings
    {
        public static void RegisterBindings()
        {
            //Mvx.RegisterSingleton<ILocalObjectStorageService<Domain.CLASS>>(() => new LocalObjectStorageService<Domain.CLASS>());
        }
    }
}
