using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// a list of filter specifications
    /// </summary>
    public class AVFilterChain : ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        struct Internal
        {
            [FieldOffset(0)] internal IntPtr filters; //  AVFilterParams**
            [FieldOffset(8)] internal long nb_filters;
        }
    }

}