using System;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Windows;

namespace An.World
{
    /// <summary>
    /// Base attached property to replace the vanilla WPF attached property
    /// </summary>
    /// <typeparam name="Parent">the parent class to be attached property </typeparam>
    /// <typeparam name="Property">Type of this attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public Events
        /// <summary>
        /// Fired when value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion Public Events


        #region Properties

        /// <summary>
        /// Singelton instance of parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion Properties


        #region Attached Property Definitions 

        /// <summary>
        /// Attached Property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(Property),
                typeof(BaseAttachedProperty<Parent, Property>),
                new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));
        /// <summary>
        /// Callback event when the value <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d"> The UI element that was changed</param>
        /// <param name="e"> The arguments for the event </param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            //Call parent function
            Instance.OnValueChanged(d, e);


            // Call event listeners
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attached proprty
        /// </summary>
        /// <param name="d">The element that get property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);


        /// <summary>
        /// Sets the attached property
        /// </summary>
        /// <param name="d">To get the property from</param>
        /// <param name="value">VaLue set to </param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion Attached Property Definitions 


        #region EventMethods
        
        /// <summary>
        /// The method will be pull when any property of this type is changed
        /// </summary>
        /// <param name="sender">UI elent that propty changed for</param>
        /// <param name="e">Arguemnt for this event</param>
        public virtual void OnValueChanged( DependencyObject sender ,DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion EventMethods
    }

}
