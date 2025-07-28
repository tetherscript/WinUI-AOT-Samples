using Common;
using Microsoft.UI.Xaml;
using System;
using System.IO;


namespace AOTCombinedTests;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        
        if (!TPackageHelper.IsRunningPackaged())
        {
            // Load the icon from file
            string ExeName = TAppInfo.GetExeNameViaCommandLine();
            string ExePath = Path.Combine(AppContext.BaseDirectory, ExeName);
            string? InstallationPath = Path.GetDirectoryName(ExePath);
            if (InstallationPath is not null)
            {
                string AssetsAppIconPath = Path.Combine(InstallationPath, @"Assets\app1.ico");
                AppWindow.SetIcon(AssetsAppIconPath);
                IntPtr hIcon = TNativeMethods.LoadImage(IntPtr.Zero, AssetsAppIconPath, TNativeMethods.IMAGE_ICON, 256, 256, TNativeMethods.LR_LOADFROMFILE);
                if (hIcon != IntPtr.Zero)
                {
                    nint MainWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(this);
                    // Set the small and large icons for the taskbar and title bar
                    TNativeMethods.SendMessage(MainWindowHandle, TNativeMethods.WM_SETICON, new IntPtr(0), hIcon); // Small icon
                    TNativeMethods.SendMessage(MainWindowHandle, TNativeMethods.WM_SETICON, new IntPtr(1), hIcon); // Large icon
                }
            }
            Title = "AOTCombinedTests: Running as Unpackaged" + Environment.NewLine + "Click me";
        }
        else
        {
            Title = "AOTCombinedTests: Running as Packaged" + Environment.NewLine + "Click me";
        }
     
    }

}


