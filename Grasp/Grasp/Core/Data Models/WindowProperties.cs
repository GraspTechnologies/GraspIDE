namespace Grasp
{
    /// <summary>
    /// DataModel that contains MainWindow properties
    /// </summary>
    public class WindowProperties
    {
        /// <summary>
        /// Application title
        /// </summary>
        public string App_Title { get; set; } = "Grasp IDE 2019";

        /// <summary>
        /// The opacity of the dimmed overlay when the window is not on focus
        /// </summary>
        public double Out_Of_Focus_Dimmed_Overlay_Opacity { get; set; } = 0.5;

        /// <summary>
        /// The opacity of the MainWindow's dropshadow
        /// </summary>
        public double Window_Dropshadow_Opacity { get; set; } = 0.3;

        /// <summary>
        /// Outer margin size of MainWindow
        /// </summary>
        public int Outer_Margin_Size { get; set; } = 10;

        /// <summary>
        /// Minimum width of MainWindow
        /// </summary>
        public int Window_Minimum_Width { get; set; } = 1280;

        /// <summary>
        /// Minimum height of MainWindow
        /// </summary>
        public int Window_Minimum_Height { get; set; } = 768;

        /// <summary>
        /// The height of the Titlebar
        /// </summary>
        public int Titlebar_Height { get; set; } = 30;

        /// <summary>
        /// The height of the Topbar
        /// </summary>
        public int Topbar_Height { get; set; } = 30;

        /// <summary>
        /// The height of the Separator
        /// </summary>
        public int Separator_Height { get; set; } = 1;

        /// <summary>
        /// The height of the Toolbar
        /// </summary>
        public int Toolbar_Height { get; set; } = 40;
    }
}
