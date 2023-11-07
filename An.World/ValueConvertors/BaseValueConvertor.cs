using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace An.World
{
    /// <summary>
    /// A base value convertor that allows directly XAML usage
    /// </summary>
    /// <typeparam name="T"The type of the value convertor></typeparam>
    public abstract class BaseValueConvertor<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {

        #region Private Members

        /// <summary>
        /// A single static instance of this value Convertor
        /// </summary>
        private static T mConvertor = null;

        #endregion Private Members


        #region Markup Extentions method

        /// <summary>
        /// Provides static instace of value if null returns new value
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConvertor ?? (mConvertor = new T());
        }

        #endregion Markup Extentions method

        #region Value convertor Methods
        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// A method to convert back to it's source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        #endregion Value convertor Methods

    }
}
