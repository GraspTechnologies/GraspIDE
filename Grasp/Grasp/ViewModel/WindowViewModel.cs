using System.Windows;
using System.Windows.Input;

namespace Grasp
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members
        private Window mWindow;

        private int mOuterMarginSize = 10;
        #endregion

        #region Public Properties
        public int ResizeBorder { get; set; } = 0;

        public int SeparatorHeight { get; set; } = 1;

        public int TitlebarHeight { get; set; } = 30;

        public int TopbarHeight { get; set; } = 40;

        public int ToolbarHeight { get; set; } = 40;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        public GridLength SeparatorHeightGridLength { get { return new GridLength(SeparatorHeight); } }

        public GridLength TitlebarHeightGridLength { get { return new GridLength(TitlebarHeight + ResizeBorder); } }

        public GridLength TopbarHeightGridLength { get { return new GridLength(TopbarHeight); } }

        public GridLength ToolbarHeightGridLength { get { return new GridLength(ToolbarHeight); } }
        #endregion

        #region Commands
        public ICommand MinimizeCommand { get; set; }

        public ICommand RestoreCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }
        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
            };
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            RestoreCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            var resizer = new WindowResizer(mWindow);
        }
        #endregion

        #region Private Helpers
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);

            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }
        #endregion
    }
}
