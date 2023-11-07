using Fasetto.Word;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace An.World
{
    /// <summary>
    /// view model for custon flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel 
    {

        #region Private Member
        /// <summary>
        /// The window controls view model
        /// </summary>
        private Window mWindow;


        /// <summary>
        /// Margin around window for drop shadows 
        /// </summary>
        private int mOuterMarginSize = 10; 

        /// <summary>
        /// Radius of edges around window
        /// </summary>
        private int mWindowRadius = 10;


        #endregion Private Member

        #region Public Properties

        /// <summary>
        /// The smallet width can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The smallet height can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;


        //TODO: 05 Creating login form 15:00 fixing bug on reiesize for top of window. 
        /// <summary>
        /// The size of resize border at resize window
        /// </summary>
        public int ResizeBorder{ get; set; } = 6;

        /// <summary>
        /// The size of the resize border around the window, Taking into account the outer margin. 
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize);  } }


        //TODO: what will be if change value type 
        /// <summary>
        /// The padding of inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);


        /// <summary>
        /// Margin around window for drop shadows 
        /// </summary>
        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; }
            set { mOuterMarginSize = value; }
        }


        /// <summary>
        /// Margin around window for drop shadows 
        /// </summary>
        public Thickness OuterMarginThickness { get { return new Thickness(OuterMarginSize); } }



        /// <summary>
        ///  Radius of edges around window
        /// </summary>
        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
            set { mWindowRadius = value; }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar. | Caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;
                           
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to minimize window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to Close window
        /// </summary>
        public ICommand CloseCommand { get; set; }


        /// <summary>
        /// The command to show the system menu of window
        /// </summary>
        public ICommand MenuCommand { get; set; }




        #endregion Public Commands

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel( Window window)
        {
            mWindow = window;

            //listen out for windows resizeing 
            mWindow.StateChanged += (sender, e) =>
            {
                //Fire of all properties that are effected by a resize effect. 
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Commands

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(()=> mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            //Fix window resize issue
            var resizer = new WindowResizer(mWindow);

        }
        #endregion Constructor


        #region Private helpers

        /// <summary>
        /// Gets current position on the screen. 
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);
            return new Point (position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion Private helpers

    }
    
}
