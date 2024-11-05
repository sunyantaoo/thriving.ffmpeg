using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVFilterFormatsConfig : ProxyObject
    {
        [StructLayout(LayoutKind.Explicit, Size = 40)]
        internal struct Internal
        {

            /**
             * List of supported formats (pixel or sample).
             */
            [FieldOffset(0)] internal IntPtr formats;// AVFilterFormats*

            /**
             * Lists of supported sample rates, only for audio.
             */
            [FieldOffset(8)] internal IntPtr samplerates;//    AVFilterFormats*

            /**
             * Lists of supported channel layouts, only for audio.
             */
            [FieldOffset(16)] internal IntPtr channel_layouts; //    AVFilterChannelLayouts*

            /**
             * Lists of supported YUV color metadata, only for YUV video.
             */
            [FieldOffset(24)] internal IntPtr color_spaces;  ///< AVColorSpace    AVFilterFormats*
            [FieldOffset(32)] internal IntPtr color_ranges;  ///< AVColorRange          AVFilterFormats*

        }


    }

}