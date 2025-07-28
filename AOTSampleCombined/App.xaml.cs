using Common;
using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace AOTCombined;

public partial class App : Application
{
    public App()
    {
        this.InitializeComponent();
        // WinUI‑level exceptions
        UnhandledException += OnAppUnhandledException;
        // .NET domain‑level exceptions
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        // Unobserved Task exceptions
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
    }

    private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        Debug.WriteLine($"[WinUI TaskScheduler_UnobservedTaskException] {e.Exception.Message}");
    }

    private void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
    {
        Debug.WriteLine($"[WinUI UnhandledException] {e.ExceptionObject}");
    }

    private void OnAppUnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        Debug.WriteLine($"[WinUI UnhandledException] {e.Exception.Message}");
        e.Handled = true;
    }


    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        if (!TPackageHelper.IsRunningPackaged())
        {
            //HANDLE RTL
            var currentUICulture = CultureInfo.CurrentUICulture;
            bool isRTL = currentUICulture.TextInfo.IsRightToLeft;
            if (isRTL)
            {
                bool success = TNativeMethods.SetProcessDefaultLayout(TNativeMethods.LAYOUT_RTL);
                if (!success)
                {
                    int errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                    // Handle error as needed
                }
            }
            FlowDirection MyFlowDirection = (isRTL ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
        }

        m_window = new MainWindow();
        m_window.Activate();
    }

    private Window? m_window;
}
