using Dna;

namespace Grasp
{
    /// <summary>
    /// A shorthand access class to get DI services
    /// </summary>
    public static class DI
    {
        /// <summary>
        /// A shortcut to access the <see cref="WindowProperties"/>
        /// </summary>
        public static WindowProperties WindowPropertiesDataModel => Framework.Service<WindowProperties>();

        /// <summary>
        /// A shortcut to access the <see cref="Icons"/>
        /// </summary>
        public static Icons IconsDataModel => Framework.Service<Icons>();

        /// <summary>
        /// A shortcut to access the <see cref="PathGeometryData"/>
        /// </summary>
        public static PathGeometryData PathGeometryDataDataModel => Framework.Service<PathGeometryData>();
    }
}