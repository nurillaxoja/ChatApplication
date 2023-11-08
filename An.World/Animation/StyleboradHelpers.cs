using System.Windows;
using System;
using System.Windows.Media.Animation;

namespace An.World
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StyleboradHelpers
    {
        /// <summary>
        /// Adds slide from right in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storty to add the animation</param>
        /// <param name="seconds">Time the animation will take</param>
        /// <param name="offset">The distance to the right start from</param>
        /// <param name="decalirationRatio">Rate of declaraton</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds , double offset, float decalirationRatio = 0.9f)
        {
            //Create the margin animate from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decalirationRatio,
            };

            //Set the target property name 
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            //Add this to the story board
            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// Adds slide to left in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storty to add the animation</param>
        /// <param name="seconds">Time the animation will take</param>
        /// <param name="offset">The distance to the right start from</param>
        /// <param name="decalirationRatio">Rate of declaraton</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decalirationRatio = 0.9f)
        {
            //Create the margin animate from right
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decalirationRatio,
            };

            //Set the target property name 
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            //Add this to the story board
            storyboard.Children.Add(animation);
        }







        /// <summary>
        /// Adds fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storty to add the animation</param>
        /// <param name="seconds">Time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            //Create the margin animate from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            //Set the target property name 
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            //Add this to the story board
            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// Adds fade Out animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storty to add the animation</param>
        /// <param name="seconds">Time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            //Create the margin animate from right
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

            //Set the target property name 
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            //Add this to the story board
            storyboard.Children.Add(animation);
        }


    }
}
