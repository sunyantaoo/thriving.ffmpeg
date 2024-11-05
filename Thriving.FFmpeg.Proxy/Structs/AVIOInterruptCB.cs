using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIOInterruptCB : ProxyObject
    {
        public delegate int interrupt_callback(IntPtr data);

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Internal
        {
            internal readonly interrupt_callback callback;
            internal readonly IntPtr opaque;
        }
    }
}