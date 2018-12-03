using System.Windows;
using System.Windows.Input;

namespace Grasp
{
    /// <summary>
    /// The ViewModel for the AppWindow
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// The Window this ViewModel controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The window resizer helper that keeps the window size correct in various states
        /// </summary>
        private WindowResizer mWindowResizer;

        /// <summary>
        /// Outer margin size of MainWindow
        /// </summary>
        private int mOuterMarginSize = DI.WindowPropertiesDataModel.Outer_Margin_Size;

        /// <summary>
        /// The RestoreButton's mode according to the window's state
        /// </summary>
        private string mRestoreButtonMode;

        /// <summary>
        /// Fixes the DropdownMenu horizontal offset problem when the window is maximized, and the DropdownMenu has a DropShadow effect
        /// </summary>
        private string mDropdownMenuBorderMargin;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;
        #endregion

        #region Public Properties
        /// <summary>
        /// Application title
        /// </summary>
        public string AppTitle { get; set; } = DI.WindowPropertiesDataModel.App_Title;

        /// <summary>
        /// The color of the dimmed overlay when the window is not on focus
        /// </summary>
        public string OutOfFocusDimmedOverlayColor { get; set; } = DI.WindowPropertiesDataModel.Out_Of_Focus_Dimmed_Overlay_Color;

        /// <summary>
        /// The opacity of the dimmed overlay when the window is not on focus
        /// </summary>
        public double OutOfFocusDimmedOverlayOpacity { get; set; } = DI.WindowPropertiesDataModel.Out_Of_Focus_Dimmed_Overlay_Opacity;

        /// <summary>
        /// Minimum width of MainWindow
        /// </summary>
        public int WindowMinimumWidth { get; set; } = DI.WindowPropertiesDataModel.Window_Minimum_Width;

        /// <summary>
        /// Minimum height of MainWindow
        /// </summary>
        public int WindowMinimumHeight { get; set; } = DI.WindowPropertiesDataModel.Window_Minimum_Height;

        /// <summary>
        /// True if we should have a dimmed overlay on the window
        /// such as when a popup is visible or the window is not focused
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }

        /// <summary>
        /// The Window is borderless when it is maximized or when it is docked
        /// </summary>
        public bool Borderless => mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked;

        /// <summary>
        /// The height of the Titlebar
        /// </summary>
        public int TitlebarHeight { get; set; } = DI.WindowPropertiesDataModel.Titlebar_Height;

        /// <summary>
        /// The height of the Topbar
        /// </summary>
        public int TopbarHeight { get; set; } = DI.WindowPropertiesDataModel.Topbar_Height;

        /// <summary>
        /// The height of the Separator
        /// </summary>
        public int SeparatorHeight { get; set; } = DI.WindowPropertiesDataModel.Separator_Height;

        /// <summary>
        /// The height of the Toolbar
        /// </summary>
        public int ToolbarHeight { get; set; } = DI.WindowPropertiesDataModel.Toolbar_Height;

        /// <summary>
        /// The margin around the window which allows for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            set => mOuterMarginSize = value;
        }

        /// <summary>
        /// The RestoreButton's mode according to the window's state
        /// </summary>
        public string RestoreButtonMode
        {
            get => mWindow.WindowState == WindowState.Maximized
                ? mRestoreButtonMode = DI.IconsDataModel.WindowButton_Restore_Icon
                : mRestoreButtonMode = DI.IconsDataModel.WindowButton_RestoreFullscreen_Icon;
            set => mRestoreButtonMode = value;
        }

        /// <summary>
        /// Fixes the DropdownMenu horizontal offset problem when the window is maximized, and the DropdownMenu has a DropShadow effect
        /// </summary>
        public string DropdownMenuBorderMargin
        {
            get => mWindow.WindowState == WindowState.Maximized ? mDropdownMenuBorderMargin = "0 5 5 5" : mDropdownMenuBorderMargin = "5 5 5 5";
            set => mDropdownMenuBorderMargin = value;
        }

        public Thickness ResizeBorderThickness => new Thickness(OuterMarginSize);

        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        public GridLength SeparatorHeightGridLength => new GridLength(SeparatorHeight);

        public GridLength TitlebarHeightGridLength => new GridLength(TitlebarHeight);

        public GridLength TopbarHeightGridLength => new GridLength(TopbarHeight);

        public GridLength ToolbarHeightGridLength => new GridLength(ToolbarHeight);
        #endregion

        #region Commands
        public ICommand MinimizeCommand { get; set; }

        public ICommand RestoreCommand { get; set; }

        public ICommand CloseCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window being resized
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties which are affected by a resize
                WindowResized();
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            RestoreCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());

            // Fix window resize issue
            mWindowResizer = new WindowResizer(mWindow);

            // Listen out for dock changes
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// If the window resizes to a specific position (docked or maximized)
        /// this will update all required property change events to set the values
        /// </summary>
        private void WindowResized()
        {
            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(RestoreButtonMode));
            OnPropertyChanged(nameof(DropdownMenuBorderMargin));
        }
        #endregion
    }
}
