﻿namespace Grasp
{
    /// <summary>
    /// DataModel that contains MainWindow properties
    /// </summary>
    public class MainWindowProperties
    {
        /// <summary>
        /// Application title
        /// </summary>
        public string App_Title { get; set; } = "Grasp IDE 2019";

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
