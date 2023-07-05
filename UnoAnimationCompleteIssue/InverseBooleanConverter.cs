// <copyright file="InverseBooleanConverter.cs" company="Visual Software Systems Ltd.">Copyright (c) 2023 All rights reserved</copyright>

namespace Vssl.VisualFramework.Shared.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Data;

    /// <summary>
    /// Reverses a boolean value
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Converts boolean to Visibility
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <param name="targetType">The target type of the conversion</param>
        /// <param name="parameter">Any optional parameter</param>
        /// <param name="language">The language</param>
        /// <returns>The converted value</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && (value is bool || value is bool?))
            {
                return !(bool)value;
            }

            return false;
        }

        /// <summary>
        /// Converts Visibility to boolean
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <param name="targetType">The target type of the conversion</param>
        /// <param name="parameter">Any optional parameter</param>
        /// <param name="language">The language</param>
        /// <returns>The converted value</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null && (value is bool || value is bool?))
            {
                return !(bool)value;
            }

            return false;
        }
    }
}
