using System;
using System.Runtime.InteropServices;

namespace AOTSampleUnpackaged;

public static class TNativeMethods
{
    //https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-setprocessdefaultlayout

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetProcessDefaultLayout(uint dwDefaultLayout);

    // Layout flags:
    public const uint LAYOUT_RTL = 0x00000001;
    public const uint LAYOUT_BITMAPORIENTATIONPRESERVED = 0x00000008;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr LoadImage(IntPtr hInstance, string lpIconName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public const int WM_SETICON = 0x0080;
    public const uint IMAGE_ICON = 1;
    public const uint LR_LOADFROMFILE = 0x00000010;

}
