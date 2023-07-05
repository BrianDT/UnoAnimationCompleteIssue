// <copyright file="IBindableBase.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013 All rights reserved</copyright>

namespace Vssl.VisualFramework.CommonInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The interface to the bindable base class
    /// </summary>
    public interface IBindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// A public interface to OnPropertyChanged
        /// </summary>
        /// <param name="propertyName">The property name</param>
        void NotifyPropertyChanged(string propertyName);
    }
}
