using Dna;
using Microsoft.Extensions.DependencyInjection;

namespace Grasp
{
    /// <summary>
    /// Extension methods for the <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// Injects the services needed for the application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddGraspClasses(this FrameworkConstruction construction)
        {
            // Bind to a single instance of WindowPropertiesDataModel
            construction.Services.AddSingleton<WindowProperties>();

            // Bind to a single instance of IconsDataModel
            construction.Services.AddSingleton<Icons>();

            // Bind to a single instance of PathGeometryDataDataModel
            construction.Services.AddSingleton<PathGeometryData>();

            // Return the construction for chaining
            return construction;
        }
    }
}