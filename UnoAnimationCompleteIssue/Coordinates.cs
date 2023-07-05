// <copyright file="Coordinates.cs" company="Visual Software Systems Ltd.">Copyright (c) 2014 All rights reserved</copyright>

namespace UnoAnimationCompleteIssue
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A portable co-ordinate class
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// The x co-ordinate
        /// </summary>
        private double x;

        /// <summary>
        /// The y co-ordinate
        /// </summary>
        private double y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class
        /// </summary>
        /// <param name="x">The x co-ordinate</param>
        /// <param name="y">The y co-ordinate</param>
        public Coordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets or sets the X co-ordinate
        /// </summary>
        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (value != this.x)
                {
                    this.x = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Y co-ordinate
        /// </summary>
        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (value != this.y)
                {
                    this.y = value;
                }
            }
        }

        /// <summary>
        /// Returns a representation of a co-ordinate that can be used in a path
        /// </summary>
        /// <returns>The co-ordinates as a string</returns>
        public override string ToString()
        {
            return this.x.ToString(CultureInfo.InvariantCulture) + "," + this.y.ToString(CultureInfo.InvariantCulture);
        }
    }
}
