using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVSubtitleRect : ProxyObject
    {
        internal AVSubtitleRect(IntPtr handle) : base(handle) { }

        [StructLayout(LayoutKind.Explicit, Size = 96)]
        internal struct Internal
        {
            [FieldOffset(0)] internal int x;         ///< top left corner  of pict, undefined when pict is not set
            [FieldOffset(4)] internal int y;         ///< top left corner  of pict, undefined when pict is not set
            [FieldOffset(8)] internal int w;         ///< width            of pict, undefined when pict is not set
            [FieldOffset(12)] internal int h;         ///< height           of pict, undefined when pict is not set
            [FieldOffset(16)] internal int nb_colors; ///< number of colors in pict, undefined when pict is not set

            /**
             * data+linesize for the bitmap of this subtitle.
             * Can be set for text/ass as well once they are rendered.
             */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            [FieldOffset(24)] internal IntPtr[] data;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            [FieldOffset(56)] internal int[] linesize;

            [FieldOffset(72)] internal int flags;
            [FieldOffset(76)] internal AVSubtitleType type;

            [FieldOffset(80)] internal IntPtr text;                     ///< 0 terminated plain UTF-8 text

            /**
             * 0 terminated ASS/SSA compatible event line.
             * The presentation of this is unaffected by the other values in this
             * struct.
             */
            [FieldOffset(88)] internal IntPtr ass;
        }
    }
}