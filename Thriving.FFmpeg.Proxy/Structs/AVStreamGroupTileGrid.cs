using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVStreamGroupTileGrid:ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 56)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;

            /**
             * Amount of tiles in the grid.
             *
             * Must be > 0.
             */
            [FieldOffset(8)] internal uint nb_tiles;

            /**
             * Width of the canvas.
             *
             * Must be > 0.
             */
            [FieldOffset(12)] internal int coded_width;
            /**
             * Width of the canvas.
             *
             * Must be > 0.
             */
            [FieldOffset(16)] internal int coded_height;

            /**
             * An @ref nb_tiles sized array of offsets in pixels from the topleft edge
             * of the canvas, indicating where each stream should be placed.
             * It must be allocated with the av_malloc() family of functions.
             *
             * - demuxing: set by libavformat, must not be modified by the caller.
             * - muxing: set by the caller before avformat_write_header().
             *
             * Freed by libavformat in avformat_free_context().
             */

            /// uint idx;int horizontal; int vertical
            [FieldOffset(24)]
            internal IntPtr offsets;

            /**
             * The pixel value per channel in RGBA format used if no pixel of any tile
             * is located at a particular pixel location.
             *
             * @see av_image_fill_color().
             * @see av_parse_color().
             */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            [FieldOffset(32)] internal byte[] background;

            /**
             * Offset in pixels from the left edge of the canvas where the actual image
             * meant for presentation starts.
             *
             * This field must be >= 0 and < @ref coded_width.
             */
            [FieldOffset(36)] internal int horizontal_offset;
            /**
             * Offset in pixels from the top edge of the canvas where the actual image
             * meant for presentation starts.
             *
             * This field must be >= 0 and < @ref coded_height.
             */
            [FieldOffset(40)] internal int vertical_offset;

            /**
             * Width of the final image for presentation.
             *
             * Must be > 0 and <= (@ref coded_width - @ref horizontal_offset).
             * When it's not equal to (@ref coded_width - @ref horizontal_offset), the
             * result of (@ref coded_width - width - @ref horizontal_offset) is the
             * amount amount of pixels to be cropped from the right edge of the
             * final image before presentation.
             */
            [FieldOffset(44)] internal int width;
            /**
             * Height of the final image for presentation.
             *
             * Must be > 0 and <= (@ref coded_height - @ref vertical_offset).
             * When it's not equal to (@ref coded_height - @ref vertical_offset), the
             * result of (@ref coded_height - height - @ref vertical_offset) is the
             * amount amount of pixels to be cropped from the bottom edge of the
             * final image before presentation.
             */
            [FieldOffset(48)] internal int height;
        }

    }
}