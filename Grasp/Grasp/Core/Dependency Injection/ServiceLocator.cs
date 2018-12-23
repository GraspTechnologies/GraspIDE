namespace Grasp
{
    /// <summary>
    /// Locates services from the IoC for use in binding in XAML files
    /// </summary>
    public class ServiceLocator
    {
        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ServiceLocator Instance { get; private set; } = new ServiceLocator();

        /// <summary>
        /// The DataModel for the window properties
        /// </summary>
        public WindowProperties WindowProperties => DI.WindowPropertiesDataModel;

        /// <summary>
        /// The DataModel for the icons
        /// </summary>
        public Icons Icons => DI.IconsDataModel;

        /// <summary>
        /// The DataModel for the path geometry data
        /// </summary>
        public PathGeometryData PathGeometryData => DI.PathGeometryDataDataModel;
    }
}