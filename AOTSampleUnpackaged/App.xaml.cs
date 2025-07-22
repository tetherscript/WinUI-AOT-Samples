using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace AOTSampleUnpackaged
{
    public partial class App : Application
    {
        public Window MainWin;

        public App()
        {
            this.InitializeComponent();
            // WinUI‑level exceptions
            UnhandledException += OnAppUnhandledException;
            // .NET domain‑level exceptions
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            // Unobserved Task exceptions
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
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

        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Debug.WriteLine($"[Task UnobservedException] {e.Exception.Message}");
            e.SetObserved();
        }

        public const uint LAYOUT_RTL = 0x00000001;

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
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

            // Get or register the main instance
            string ExePath = System.IO.Path.Combine(AppContext.BaseDirectory, TAppInfo.GetExeNameViaCommandLine());
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(ExePath);
            var mainInstance = Microsoft.Windows.AppLifecycle.AppInstance.FindOrRegisterForKey(versionInfo.ProductName);
            // If the main instance isn't this current instance
            if (!mainInstance.IsCurrent)
            {
                // Redirect activation to that instance
                var appArgs = Microsoft.Windows.AppLifecycle.AppInstance.GetCurrent().GetActivatedEventArgs();
                await mainInstance.RedirectActivationToAsync(appArgs);
                // And exit our instance and stop
                await Task.Delay(2000);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                return;
            }

            MainWin = new MainWindow();
            MainWin.Activate();
        }

    }
}
