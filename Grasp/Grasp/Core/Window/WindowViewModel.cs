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

        private int mOuterMarginSize = 10;

        private string mRestoreButtonMode;

        private string mDropdownMenuBorderMargin;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;
        #endregion

        #region Public Properties
        public int WindowMinimumWidth { get; set; } = 1280;

        public int WindowMinimumHeight { get; set; } = 768;

        /// <summary>
        /// The Window is borderless when it is maximized or when it is docked
        /// </summary>
        public bool Borderless => mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked;

        public int ResizeBorder { get; set; } = 0;

        public int SeparatorHeight { get; set; } = 1;

        public int TitlebarHeight { get; set; } = 30;

        public int TopbarHeight { get; set; } = 30;

        public int ToolbarHeight { get; set; } = 40;

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
                ? mRestoreButtonMode = DI.ViewModelIconPaths.WindowButton_Restore_Icon
                : mRestoreButtonMode = DI.ViewModelIconPaths.WindowButton_RestoreFullscreen_Icon;
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

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        public GridLength SeparatorHeightGridLength => new GridLength(SeparatorHeight);

        public GridLength TitlebarHeightGridLength => new GridLength(TitlebarHeight + ResizeBorder);

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
