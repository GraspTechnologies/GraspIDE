namespace Grasp
{
    /// <summary>
    /// DataModel that contains icon paths
    /// </summary>
    public class Icons
    {
        /// <summary>
        /// Application main icon/logo
        /// </summary>
        public string App_Icon { get; set; } = "pack://application:,,,/Resources/Images/Logo/logo.png";

        /// <summary>
        /// WindowButton Icon for minimizin the window
        /// </summary>
        public string WindowButton_Minimize_Icon { get; set; } = "pack://application:,,,/Resources/Images/Buttons/Window Buttons/WindowButton-minimize.png";

        /// <summary>
        /// WindowButton Icon for restoring the window
        /// </summary>
        public string WindowButton_Restore_Icon { get; set; } = "pack://application:,,,/Resources/Images/Buttons/Window Buttons/WindowButton-restore.png";

        /// <summary>
        /// WindowButton Icon for restoring the window (when fullscreen)
        /// </summary>
        public string WindowButton_RestoreFullscreen_Icon { get; set; } = "pack://application:,,,/Resources/Images/Buttons/Window Buttons/WindowButton-restore_fullscreen.png";

        /// <summary>
        /// WindowButton Icon for closing the window
        /// </summary>
        public string WindowButton_Close_Icon { get; set; } = "pack://application:,,,/Resources/Images/Buttons/Window Buttons/WindowButton-close.png";
    }
}
