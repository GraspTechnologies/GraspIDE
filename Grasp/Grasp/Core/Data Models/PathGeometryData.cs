namespace Grasp
{
    /// <summary>
    /// DataModel that contains geometry data for paths
    /// </summary>
    public class PathGeometryData
    {
        /// <summary>
        /// Dropdown arrow 
        /// </summary>
        public string Dropdown_Triangle { get; set; } = "M0 0L4 3.5 0 7z";

        /// <summary>
        /// Line up scrollbar button triangle
        /// </summary>
        public string LineUp_ScrollbarButton_Triangle { get; set; } = "M 0 32 L 64 32 L 32 0 Z";

        /// <summary>
        /// Line down scrollbar button triangle
        /// </summary>
        public string LineDown_ScrollbarButton_Triangle { get; set; } = "M 0 32 L 64 32 L 32 64 Z";

        /// <summary>
        /// Line left scrollbar button triangle
        /// </summary>
        public string LineLeft_ScrollbarButton_Triangle { get; set; } = "M 64 64 L 64 0 L 32 32 Z";

        /// <summary>
        /// Line right scrollbar button triangle
        /// </summary>
        public string LineRight_ScrollbarButton_Triangle { get; set; } = "M 0 0 L 0 64 L 32 32 Z";
    }
}
