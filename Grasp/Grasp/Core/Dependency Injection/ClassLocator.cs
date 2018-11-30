namespace Grasp
{
    /// <summary>
    /// Locates classes from the IoC for use in binding in XAML files
    /// </summary>
    public class ClassLocator
    {
        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ClassLocator Instance { get; private set; } = new ClassLocator();

        /// <summary>
        /// The DataModel for the MainWindow properties
        /// </summary>
        public MainWindowProperties MainWindowProperties => DI.MainWindowPropertiesDataModel;

        /// <summary>
        /// The DataModel for the icons
        /// </summary>
        public Icons Icons => DI.IconsDataModel;
    }
}