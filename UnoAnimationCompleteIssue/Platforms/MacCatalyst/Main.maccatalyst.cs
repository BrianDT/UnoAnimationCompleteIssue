// <copyright file=Main.maccatalyst.cs" company="Visual Software Systems Ltd.">Copyright (c) 2023 - 2024 All rights reserved</copyright>
namespace UnoAnimationCompleteIssue.MacCatalyst;
using UIKit;

/// <summary>
/// The entry point for the Mac Catalyst head.
/// </summary>
public class EntryPoint
{
    /// <summary>
    /// This is the main entry point of the application.
    /// </summary>
    /// <param name="args">Any arguiments</param>
    public static void Main(string[] args)
    {
        // if you want to use a different Application Delegate class from "AppDelegate"
        // you can specify it here.
        UIApplication.Main(args, null, typeof(App));
    }
}
