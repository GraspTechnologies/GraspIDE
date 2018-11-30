namespace Grasp
{
    /// <summary>
    /// DataModel that contains MainWindow properties
    /// </summary>
    public class MainWindowProperties
    {
        public string App_Title { get; set; } = "Grasp IDE 2019";

        public int Window_Minimum_Width { get; set; } = 1280;

        public int Window_Minimum_Height { get; set; } = 768;

        public int Resize_Border { get; set; } = 0;

        public int Separator_Height { get; set; } = 1;

        public int Titlebar_Height { get; set; } = 30;

        public int Topbar_Height { get; set; } = 30;

        public int Toolbar_Height { get; set; } = 40;
    }
}
