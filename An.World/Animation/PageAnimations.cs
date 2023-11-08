using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace An.World
{

    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slides page from right
        /// </summary>
        /// <param name="page">Page to animate</param>
        /// <param name="seconds">The time that animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page , float seconds)
        {
            //Create the story board
            var sb = new Storyboard();
            //Add slide from right animaiton
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //Add fade in Animation
            sb.AddFadeIn(seconds  );

            //Starts animating
            sb.Begin(page);

            //Make page visible
            page.Visibility = Visibility.Visible;

            //wait for the finish
            await Task.Delay((int)(seconds*1000));
            
        }


        /// <summary>
        /// Slides page out to the left
        /// </summary>
        /// <param name="page">Page to animate</param>
        /// <param name="seconds">The time that animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            //Create the story board
            var sb = new Storyboard();
            //Add slide from right animaiton
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //Add fade in Animation
            sb.AddFadeOut(seconds);

            //Starts animating
            sb.Begin(page);

            //Make page visible
            page.Visibility = Visibility.Visible;

            //wait for the finish
            await Task.Delay((int)(seconds * 1000));

        }


    }
}
