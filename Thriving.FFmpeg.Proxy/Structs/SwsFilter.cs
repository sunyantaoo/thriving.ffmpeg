using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class SwsFilter : ProxyObject
    {
        internal SwsFilter(IntPtr handle):base(handle) { }

        public SwsVector LumH
        {
            get
            {
                var lumH = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.lumH)).ToInt32());
                return new SwsVector(lumH);
            }
        }

        public SwsVector LumV
        {
            get
            {
                var lumV = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.lumV)).ToInt32());
                return new SwsVector(lumV);
            }
        }

        public SwsVector ChrH
        {
            get
            {
                var chrH = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.chrH)).ToInt32());
                return new SwsVector(chrH);
            }
        }

        public SwsVector ChrV
        {
            get
            {
                var chrV = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.chrV)).ToInt32());
                return new SwsVector(chrV);
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        struct Internal
        {
            [FieldOffset(0)] internal IntPtr lumH;
            [FieldOffset(8)] internal IntPtr lumV;
            [FieldOffset(16)] internal IntPtr chrH;
            [FieldOffset(24)] internal IntPtr chrV;
        }
    }
}