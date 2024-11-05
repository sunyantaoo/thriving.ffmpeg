using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVOptionRange : ProxyObject
    {


        [StructLayout(LayoutKind.Explicit, Size = 48)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr str; // char*
            /**
             * Value range.
             * For string ranges this represents the min/max length.
             * For dimensions this represents the min/max pixel count or width/height in multi-component case.
             */
            [FieldOffset(8)] internal double value_min;
            [FieldOffset(16)] internal double value_max;
            /**
             * Value's component range.
             * For string this represents the unicode range for chars, 0-127 limits to ASCII.
             */
            [FieldOffset(24)] internal double component_min;
            [FieldOffset(32)] internal double component_max;
            /**
             * Range flag.
             * If set to 1 the struct encodes a range, if set to 0 a single value.
             */
            [FieldOffset(40)] internal int is_range;
        }
    }

}