
namespace Sunny.Core.Mappers
{
    /// <summary>
    /// Mapper bindings.
    /// This class contains the DI registers which makes the object mapping magic work.
    /// 
    ///     Registers the bindings!!!
    ///              /
    ///             /
    ///          ___
    ///  D>=G==='   '.
    ///        |======|
    ///        |======|
    ///    )--/]IIIIII]
    ///       |_______|
    ///       C O O O D
    ///      C O  O  O D
    ///     C  O  O  O  D
    ///     C__O__O__O__D
    ///    [_____________]
    ///    
    /// </summary>
    public static class MapperBindings
    {
        public static void RegisterBindings()
        {
            //ObjectMapperRegistrar.RegisterBinding<IObjectMapper<Domain.CLASS, Observable.CLASS>>(() => new CLASSMapper());
        }
    }
}
