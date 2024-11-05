using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVPixFmtDescriptor : ProxyObject
    {
        internal AVPixFmtDescriptor(IntPtr handle):base(handle) { }

        public static AVPixFmtDescriptor Get(AVPixelFormat pix_fmt)
        {
            var handle = Core.av_pix_fmt_desc_get(pix_fmt);
            return new AVPixFmtDescriptor(handle);
        }

        public AVPixelFormat GetPixelFormat()
        {
            return Core.av_pix_fmt_desc_get_id(_handle);
        }

        public static AVPixFmtDescriptor Next(AVPixFmtDescriptor? prev = null)
        {
            var handle = Core.av_pix_fmt_desc_next(prev == null ? IntPtr.Zero : prev._handle);
            return new AVPixFmtDescriptor(handle);
        }


        [StructLayout(LayoutKind.Explicit, Size = 112)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr name;//  char*
            [FieldOffset(8)] internal byte nb_components;  ///< The number of components each pixel has, (1-4)

            /**
             * Amount to shift the luma width right to find the chroma width.
             * For YV12 this is 1 for example.
             * chroma_width = AV_CEIL_RSHIFT(luma_width, log2_chroma_w)
             * The note above is needed to ensure rounding up.
             * This value only refers to the chroma components.
             */
            [FieldOffset(9)] internal byte log2_chroma_w;

            /**
             * Amount to shift the luma height right to find the chroma height.
             * For YV12 this is 1 for example.
             * chroma_height= AV_CEIL_RSHIFT(luma_height, log2_chroma_h)
             * The note above is needed to ensure rounding up.
             * This value only refers to the chroma components.
             */
            [FieldOffset(10)] internal byte log2_chroma_h;

            /**
             * Combination of AV_PIX_FMT_FLAG_... flags.
             */
            [FieldOffset(16)] internal AVPixelFormatFlags flags;

            /**
             * Parameters that describe how pixels are packed.
             * If the format has 1 or 2 components, then luma is 0.
             * If the format has 3 or 4 components:
             *   if the RGB flag is set then 0 is red, 1 is green and 2 is blue;
             *   otherwise 0 is luma, 1 is chroma-U and 2 is chroma-V.
             *
             * If present, the Alpha channel is always the last component.
             */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            [FieldOffset(24)] internal AVComponentDescriptor.Internal[] comp;

            /**
             * Alternative comma-separated names.
             */
            [FieldOffset(104)] internal IntPtr alias;//  char*
        }
    }
}