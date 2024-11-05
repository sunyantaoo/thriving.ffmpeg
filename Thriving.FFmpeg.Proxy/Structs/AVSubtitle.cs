using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVSubtitle : ProxyObject
    {
        internal AVSubtitle(IntPtr handle):base(handle) { }

        ~AVSubtitle()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.avsubtitle_free(_handle);
            }
        }


        [StructLayout(LayoutKind.Explicit, Size = 32)]
        internal struct Internal
        {
            [FieldOffset(0)] internal short format; /* 0 = graphics */
            [FieldOffset(4)] internal int start_display_time; /* relative to packet pts, in ms */
            [FieldOffset(8)] internal int end_display_time; /* relative to packet pts, in ms */
            [FieldOffset(12)] internal uint num_rects;
            [FieldOffset(16)] internal IntPtr rects;
            [FieldOffset(24)] internal long pts;    ///< Same as packet pts, in AV_TIME_BASE
        }
    }
}