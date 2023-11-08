using An.World.Animation;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System;

namespace An.World
{
    /// <summary>
    /// A base page for all pages to get page functionalty
    /// </summary>
    public class BasePage : Page
    {
        #region Public Properties

        /// <summary>
        /// Animation that play page on load 
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Animation that fires on closing page
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time that any animation takes to compleate.
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        #endregion Public Properties


        #region Constructor
        /// <summary>
        /// Default constructor 
        /// </summary>
        public BasePage()
        {
            //If we are animating in , to hide to begine with
            if (this.PageLoadAnimation == PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            //Listen out for a page loading
            this.Loaded += BasePage_Loaded;
        }

        #endregion Constructor


        #region Animation Load/Unload
        /// <summary>
        /// Once page is loaded perform a required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnymateIn();

        }

        /// <summary>
        /// Anymates in the page
        /// </summary>
        /// <returns></returns>
        public async Task AnymateIn()
        {
            //Makes sure that we have something to do.
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    //Start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            //Makes sure that we have something to do.
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    //Start the animation
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;
            }
        }


        #endregion Animation Load/Unload



    }
}
