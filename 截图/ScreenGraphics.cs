using System;
using System.Drawing;

namespace KJBL
{
    public class ScreenGraphics
    {
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr CreateDC(
        string lpszDriver,   //   驱动名称  
        string lpszDevice,   //   设备名称  
        string lpszOutput,   //   无用，可以设定位"NULL"  
        IntPtr lpInitData   //   任意的打印机数据  
        );
        public static Graphics GetScreen()
        {
            //获取屏幕的DC  
            IntPtr dc1 = CreateDC("DISPLAY", null, null, (IntPtr)null);
            //根据DC句柄创建Graphics对象
            Graphics g1 = Graphics.FromHdc(dc1);
            return g1;
        }
       
    }
}
