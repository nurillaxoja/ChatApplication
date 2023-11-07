using System.Windows;
using System.Windows.Controls;

namespace An.World
{

    /// <summary>
    /// MonitorPasswordProperty for <see cref="PasswordBox"/> 
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty , bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get a caller
            var passwordBox = sender as PasswordBox;

            //To make sure it is password box
            if (passwordBox == null) 
                return;

            //Remove pervious events 
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            //If caller set MOnitor password to true...
            if((bool)e.NewValue) 
            {
                //Set default value
                HasTextProperty.SetValue(passwordBox);


                //Starts listening out for password changes
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }

        }
        /// <summary>
        /// Fired when the password box value changes
        /// </summary>
        /// <param name="sender">  </param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Sets the Has text value
            HasTextProperty.SetValue((PasswordBox)sender);


        }
    }


    /// <summary>
    /// HasTextAttached Property for <see cref="PasswordBox"/> 
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {

        /// <summary>
        /// Sets the HasText propert based on if the caller <see cref="PasswordBox"/> has any text
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }

    }
}
