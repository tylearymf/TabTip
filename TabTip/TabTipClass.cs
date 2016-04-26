using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

/// <summary>
/// 
/// </summary>
public class TabTipClass
{
    private const Int32 WM_SYSCOMMAND = 274;
    private const UInt32 SC_CLOSE = 61536;
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int RegisterWindowMessage(string lpString);

    /// <summary>
    /// 显示屏幕键盘
    /// </summary>
    public static int ShowTabTip()
    {
        try
        {
            //string file = @"%HomeDrive%\Program Files\\Common Files\\microsoft shared\\ink\\TabTip.exe";
            string file = @"C:\\Program Files\\Common Files\\microsoft shared\\ink\\TabTip.exe";
            if (!System.IO.File.Exists(file))
                return 0;
            Process pro = Process.Start(file);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    /// <summary>
    /// 隐藏屏幕键盘
    /// </summary>
    public static int HideTabTip()
    {
        IntPtr TouchhWnd = new IntPtr(0);
        TouchhWnd = FindWindow("IPTip_Main_Window", null);
        if (TouchhWnd == IntPtr.Zero)
            return 0;
        PostMessage(TouchhWnd, WM_SYSCOMMAND, SC_CLOSE, 0);
        return 1;
    }
}
