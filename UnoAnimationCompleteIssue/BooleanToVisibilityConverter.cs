// <copyright file="BooleanToVisibilityConverter.cs" company="Visual Software Systems Ltd.">Copyright (c) 2012 All rights reserved</copyright>

namespace Vssl.VisualFramework.Shared.Converters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Data;

    /// <summary>
    /// Value converter that translates true to <see cref="Visibility.Visible"/> and false to
    /// <see cref="Visibility.Collapsed"/>.
    /// </summary>
    public sealed class BooleanToVisibilityConverter : IValueConverter
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
            string mode = null;
            if (parameter != null)
            {
                mode = parameter as string;
            }

            if (mode == "reverse")
            {
                return (value is bool && (bool)value) ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
            }
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
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}
