using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVComponentDescriptor : ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 20)]
        internal struct Internal
        {
            /**
             * Which of the 4 planes contains the component.
             */
            [FieldOffset(0)] int plane;

            /**
             * Number of elements between 2 horizontally consecutive pixels.
             * Elements are bits for bitstream formats, bytes otherwise.
             */
            [FieldOffset(4)] int step;

            /**
             * Number of elements before the component of the first pixel.
             * Elements are bits for bitstream formats, bytes otherwise.
             */
            [FieldOffset(8)] int offset;

            /**
             * Number of least significant bits that must be shifted away
             * to get the value.
             */
            [FieldOffset(12)] int shift;

            /**
             * Number of bits in the component.
             */
            [FieldOffset(16)] int depth;
        }
    }
}