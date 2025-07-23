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
        App.InitializeLogging();

        var host = UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseAppleUIKit()
            .Build();

        host.Run();
    }
}
