// <copyright file="Program.cs" company="Visual Software Systems Ltd.">Copyright (c) 2023 - 2024 All rights reserved</copyright>
namespace UnoAnimationCompleteIssue;

/// <summary>
/// The entry point for the wasm browser head.
/// </summary>
public class Program
{
    private static App _app;

    /// <summary>
    /// The main function entry point.
    /// </summary>
    /// <param name="args">Any arguiments</param>
    /// <returns>The return code</returns>
    public static int Main(string[] args)
    {
        Microsoft.UI.Xaml.Application.Start(_ => _app = new App());

        return 0;
    }
}
