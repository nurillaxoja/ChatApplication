using An.World.Pages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace An.World
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConvertor : BaseValueConvertor<ApplicationPageValueConvertor>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /// Find the appropriate page.
            switch((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                default: 
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
