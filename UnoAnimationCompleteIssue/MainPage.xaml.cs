// <copyright file="MainPage.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2033 All rights reserved</copyright>

namespace UnoAnimationCompleteIssue
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Media.Animation;

    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Storyboard? storyboard;

        private double canvasHeight;

        private double canvasWidth;

        /// <summary>
        /// The current visual state
        /// </summary>
        private string? currentState;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
            this.VM.PropertyChanged += this.OnViewModelPropertyChanged;
            this.movingAnimation.Completed += this.OnXMLAnimationCompleted;
        }

        /// <summary>
        /// Gets the current view model
        /// </summary>
        public MainViewModel VM
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
        }

        /// <summary>
        /// Starts the animation
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void StartXAML_Click(object sender, RoutedEventArgs e)
        {
            this.VM.Animate();
        }

        /// <summary>
        /// Create a dynamic animation and start it.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void StartCode_Click(object sender, RoutedEventArgs e)
        {
            this.CreateDynamicAnimation(withRotation: false);
            this.VM.Animating();
        }

        /// <summary>
        /// Create a dynamic animation and start it.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void StartCodeWithRotation_Click(object sender, RoutedEventArgs e)
        {
            this.CreateDynamicAnimation(withRotation: true);
            this.VM.Animating();
        }

        private void StopCode_Click(object sender, RoutedEventArgs e)
        {
            if (this.storyboard != null)
            {
                this.storyboard.Completed -= this.OnCodeAnimationCompleted;
                this.storyboard.Stop();
                this.storyboard = null;
            }

            this.VM.CodeAnimationAborted();
        }

        /// <summary>
        /// Property changed event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AnimationRequested":
                    if (this.VM != null)
                    {
                        this.AnimationRequestedChanged();
                    }

                    break;
            }
        }

        /// <summary>
        /// The event handler for animation completion
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="args">The event args</param>
        private void OnXMLAnimationCompleted(object? sender, object args)
        {
            if (this.VM != null)
            {
                this.VM.XMLAnimationCompleted();
            }
        }

        /// <summary>
        /// The event handler for animation completion
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="args">The event args</param>
        private void OnCodeAnimationCompleted(object? sender, object? args)
        {
            if (this.storyboard != null)
            {
                this.storyboard.Completed -= this.OnCodeAnimationCompleted;
            }

            if (this.VM != null)
            {
                this.VM.CodeAnimationCompleted();
            }
        }

        /// <summary>
        ///  Event handler for animation request state change
        /// </summary>
        private void AnimationRequestedChanged()
        {
            if (this.VM != null)
            {
                string newState = this.VM.AnimationRequested ? "Impact" : "Pending";
                if (this.currentState != newState)
                {
                    this.currentState = newState;
                    bool stateChanged = VisualStateManager.GoToState(this, newState, false);
                }
            }
        }

        /// <summary>
        /// Event handler for page size changed/
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.canvasWidth = e.NewSize.Width;
            this.canvasHeight = e.NewSize.Height;
            this.VM.OnSizeChanged(this.canvasWidth, this.canvasHeight);
        }

        /// <summary>
        /// Creates a dynamic animation
        /// </summary>
        private void CreateDynamicAnimation(bool withRotation = true)
        {
            this.storyboard = new Storyboard();
            this.storyboard.Completed += this.OnCodeAnimationCompleted;
            var translateAnimationX = new DoubleAnimationUsingKeyFrames();
            translateAnimationX.KeyFrames.Add(new DiscreteDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero), Value = 0 });
            translateAnimationX.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)), Value = 0.1 * this.canvasWidth });
            translateAnimationX.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)), Value = 0.2 * this.canvasWidth });
            translateAnimationX.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), Value = 0.4 * this.canvasWidth });
            translateAnimationX.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(8)), Value = 0.8 * this.canvasWidth });
            this.storyboard.Children.Add(translateAnimationX);
            Storyboard.SetTarget(translateAnimationX, this.shapeTranslateTransform);
            Storyboard.SetTargetProperty(translateAnimationX, "X");

            var translateAnimationY = new DoubleAnimationUsingKeyFrames();
            translateAnimationY.KeyFrames.Add(new DiscreteDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero), Value = 0 });
            translateAnimationY.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)), Value = 0.1 * this.canvasHeight });
            translateAnimationY.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)), Value = 0.15 * this.canvasHeight });
            translateAnimationY.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), Value = 0.175 * this.canvasHeight });
            translateAnimationY.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(8)), Value = 0.2 * this.canvasHeight });
            this.storyboard.Children.Add(translateAnimationY);
            Storyboard.SetTarget(translateAnimationY, this.shapeTranslateTransform);
            Storyboard.SetTargetProperty(translateAnimationY, "Y");

            if (withRotation)
            {
                var translateAnimationA = new DoubleAnimationUsingKeyFrames();
                translateAnimationA.KeyFrames.Add(new DiscreteDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero), Value = 90 });
                translateAnimationA.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)), Value = 180 });
                translateAnimationA.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)), Value = 270 });
                translateAnimationA.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), Value = 360 });
                translateAnimationA.KeyFrames.Add(new DiscreteDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6.001)), Value = 0 });
                translateAnimationA.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(8)), Value = 90 });
////#if __IOS__
////                translateAnimationA.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(8.1)), Value = 0 });
////#endif
                this.storyboard.Children.Add(translateAnimationA);
                Storyboard.SetTarget(translateAnimationA, this.targetRotate);
                Storyboard.SetTargetProperty(translateAnimationA, "Angle");
////#if !__IOS__ && !ANDROID
                var translateAnimationCX = new DoubleAnimationUsingKeyFrames();
                translateAnimationCX.KeyFrames.Add(new DiscreteDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero), Value = 0 });
                translateAnimationCX.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)), Value = 0.1 * this.canvasWidth });
                translateAnimationCX.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)), Value = 0.2 * this.canvasWidth });
                translateAnimationCX.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), Value = 0.4 * this.canvasWidth });
                translateAnimationCX.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(8)), Value = 0.8 * this.canvasWidth });
                this.storyboard.Children.Add(translateAnimationCX);
                Storyboard.SetTarget(translateAnimationCX, this.targetRotate);
                Storyboard.SetTargetProperty(translateAnimationCX, "CenterX");

                var translateAnimationCY = new DoubleAnimationUsingKeyFrames();
                translateAnimationCY.KeyFrames.Add(new DiscreteDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero), Value = 0 });
                translateAnimationCY.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)), Value = 0.1 * this.canvasHeight });
                translateAnimationCY.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)), Value = 0.15 * this.canvasHeight });
                translateAnimationCY.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(6)), Value = 0.175 * this.canvasHeight });
                translateAnimationCY.KeyFrames.Add(new LinearDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(8)), Value = 0.2 * this.canvasHeight });
                this.storyboard.Children.Add(translateAnimationCY);
                Storyboard.SetTarget(translateAnimationCY, this.targetRotate);
                Storyboard.SetTargetProperty(translateAnimationCY, "CenterY");
////#endif
            }
            else
            {
                if (!this.VM.LastCodeAnimationTerminated)
                {
                    var translateAnimationA = new DoubleAnimationUsingKeyFrames();
                    translateAnimationA.KeyFrames.Add(new DiscreteDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.Zero), Value = 0 });
                    this.storyboard.Children.Add(translateAnimationA);
                    Storyboard.SetTarget(translateAnimationA, this.targetRotate);
                    Storyboard.SetTargetProperty(translateAnimationA, "Angle");
                }
            }

            this.storyboard.Begin();
        }
    }
}
