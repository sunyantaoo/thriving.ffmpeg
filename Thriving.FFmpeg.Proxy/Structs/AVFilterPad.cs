using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVFilterPad : ProxyObject
    {
        internal AVFilterPad(IntPtr handle) : base(handle) { }


        public string GetName(int pad_idx)
        {
            var ptr = Core.avfilter_pad_get_name(_handle, pad_idx);
            return Marshal.PtrToStringAnsi(ptr);
        }


        public AVMediaType GetMediaType(int pad_idx)
        {
            return Core.avfilter_pad_get_type(_handle, pad_idx);
        }
    }
}
