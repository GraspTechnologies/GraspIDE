using Dna;

namespace Grasp
{
    /// <summary>
    /// A shorthand access class to get DI services
    /// </summary>
    public static class DI
    {
        /// <summary>
        /// A shortcut to access the <see cref="MainWindowProperties"/>
        /// </summary>
        public static MainWindowProperties MainWindowPropertiesDataModel => Framework.Service<MainWindowProperties>();

        /// <summary>
        /// A shortcut to access the <see cref="Icons"/>
        /// </summary>
        public static Icons IconsDataModel => Framework.Service<Icons>();
    }
}