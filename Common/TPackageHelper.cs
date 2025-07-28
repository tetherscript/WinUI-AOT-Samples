using System.Runtime.InteropServices;
using System.Text;

namespace Common;

public static class TPackageHelper
{
    private const int APPMODEL_ERROR_NO_PACKAGE = 15700;

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern int GetCurrentPackageFullName(
        ref int packageFullNameLength,
        StringBuilder? packageFullName);

    /// <summary>
    /// True if the current process is running inside an MSIX package.
    /// </summary>
    public static bool IsRunningPackaged()
    {
        int length = 0;
        int hr = GetCurrentPackageFullName(ref length, null);
        return hr != APPMODEL_ERROR_NO_PACKAGE;
    }
}
