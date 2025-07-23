// <copyright file="MainViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2033 All rights reserved</copyright>

namespace UnoAnimationCompleteIssue
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using Microsoft.UI.Xaml.Media.Animation;
    using Vssl.VisualFramework.Common;

    /// <summary>
    /// The view model for the application
    /// </summary>
    [Bindable(true)]
    public class MainViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class
        /// </summary>
        public MainViewModel()
        {
            this.Expansion = 15.0;
            this.DriftX = -30;
            this.DriftX = -50;
            this.Diameter = 12;
            this.AltAnimationPath = "M 340,684 L 340,50";
        }

        /// <summary>
        /// Gets a value indicating whether the XML based animation has started
        /// </summary>
        public bool XMLAnimationStarted { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the code based animation has started
        /// </summary>
        public bool CodeAnimationStarted { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the code based animation has been terminated.
        /// </summary>
        public bool LastCodeAnimationTerminated { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the animation should be triggered.
        /// </summary>
        public bool AnimationRequested { get; private set; }

        /// <summary>
        /// Gets or sets the expansion diameter of the shape
        /// </summary>
        public double Expansion { get; set; }

        /// <summary>
        /// Gets or sets the diameter of the shape
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Gets or sets the X offset of the shape drift
        /// </summary>
        public double DriftX { get; set; }

        /// <summary>
        /// Gets or sets the Y offset of the shape drift
        /// </summary>
        public double DriftY { get; set; }

        /// <summary>
        /// Gets the animation status
        /// </summary>
        public string? Status { get; private set; }

        /// <summary>
        /// Gets the alternative animation path data
        /// </summary>
        public string AltAnimationPath
        {
            get;
            private set;
        }

        /// <summary>
        /// Start the animation
        /// </summary>
        public void Animate()
        {
            this.XMLAnimationStarted = true;
            this.OnPropertyChanged(nameof(this.XMLAnimationStarted));
            this.Status = "Started";
            this.OnPropertyChanged(nameof(this.Status));
            this.AnimationRequested = true;
            this.OnPropertyChanged(nameof(this.AnimationRequested));
        }

        /// <summary>
        /// Start the animation
        /// </summary>
        public void Animating()
        {
            this.LastCodeAnimationTerminated = false;
            this.OnPropertyChanged(nameof(this.LastCodeAnimationTerminated));
            this.CodeAnimationStarted = true;
            this.OnPropertyChanged(nameof(this.CodeAnimationStarted));
            this.Status = "Started";
            this.OnPropertyChanged(nameof(this.Status));
        }

        /// <summary>
        /// The UI notifies that the animation has completed
        /// </summary>
        public void XMLAnimationCompleted()
        {
            if (this.XMLAnimationStarted)
            {
                this.XMLAnimationStarted = false;
                this.OnPropertyChanged(nameof(this.XMLAnimationStarted));
                this.Status = "Completed";
                this.OnPropertyChanged(nameof(this.Status));
                if (this.AnimationRequested)
                {
                    this.AnimationRequested = false;
                    this.OnPropertyChanged(nameof(this.AnimationRequested));
                }
            }
        }

        /// <summary>
        /// The UI notifies that the animation has completed
        /// </summary>
        public void CodeAnimationCompleted()
        {
            if (this.CodeAnimationStarted)
            {
                this.CodeAnimationStarted = false;
                this.OnPropertyChanged(nameof(this.CodeAnimationStarted));
                this.Status = "Completed";
                this.OnPropertyChanged(nameof(this.Status));
            }
        }

        /// <summary>
        /// The UI notifies that the code animation has been aborted.
        /// </summary>
        public void CodeAnimationAborted()
        {
            this.LastCodeAnimationTerminated = true;
            this.OnPropertyChanged(nameof(this.LastCodeAnimationTerminated));
            this.CodeAnimationCompleted();
        }

        /// <summary>
        /// Called when the page is resized.
        /// </summary>
        /// <param name="canvasWidth">The actual width of the canvas</param>
        /// <param name="canvasHeight">The actual height of the canvas</param>
        public void OnSizeChanged(double canvasWidth, double canvasHeight)
        {
            var startX = 65.0;
            var startY = 80.0;

            StringBuilder dataPathString = new StringBuilder("M ").Append(new Coordinates(startX, startY));
            dataPathString.Append(" L ").Append(new Coordinates(startX + (canvasWidth * 0.1), startY + (canvasHeight * 0.1)));
            dataPathString.Append(" L ").Append(new Coordinates(startX + (canvasWidth * 0.2), startY + (canvasHeight * 0.15)));
            dataPathString.Append(" L ").Append(new Coordinates(startX + (canvasWidth * 0.4), startY + (canvasHeight * 0.175)));
            dataPathString.Append(" L ").Append(new Coordinates(startX + (canvasWidth * 0.8), startY + (canvasHeight * 0.2)));
            this.AltAnimationPath = dataPathString.ToString();
            this.OnPropertyChanged("AltAnimationPath");
        }
    }
}
