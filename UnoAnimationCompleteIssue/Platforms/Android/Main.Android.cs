// <copyright file=Main.Android.cs" company="Visual Software Systems Ltd.">Copyright (c) 2023 - 2024 All rights reserved</copyright>
namespace UnoAnimationCompleteIssue.Droid;

using System;
using Android.Runtime;

/// <summary>
/// The entry point for the Android head.
/// </summary>
[global::Android.App.ApplicationAttribute(
    Label = "@string/ApplicationName",
    Icon = "@mipmap/icon",
    LargeHeap = true,
    HardwareAccelerated = true,
    Theme = "@style/Theme.App.Starting"
)]
public class Application : Microsoft.UI.Xaml.NativeApplication
{
    static Application()
    {
        App.InitializeLogging();
    }

    public Application(IntPtr javaReference, JniHandleOwnership transfer)
        : base(() => new App(), javaReference, transfer)
    {
    }
}

