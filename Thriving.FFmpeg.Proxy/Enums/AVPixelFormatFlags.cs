namespace Thriving.FFmpeg.Proxy
{
    public enum AVPixelFormatFlags : long
    {
        /**
        * Pixel format is big-endian.
        */
        AV_PIX_FMT_FLAG_BE = 1 << 0,
        /**
         * Pixel format has a palette in data[1], values are indexes in this palette.
         */
        AV_PIX_FMT_FLAG_PAL = 1 << 1,
        /**
         * All values of a component are bit-wise packed end to end.
         */
        AV_PIX_FMT_FLAG_BITSTREAM = 1 << 2,
        /**
         * Pixel format is an HW accelerated format.
         */
        AV_PIX_FMT_FLAG_HWACCEL = 1 << 3,
        /**
         * At least one pixel component is not in the first data plane.
         */
        AV_PIX_FMT_FLAG_PLANAR = 1 << 4,
        /**
         * The pixel format contains RGB-like data =as opposed to YUV/grayscale,.
         */
        AV_PIX_FMT_FLAG_RGB = 1 << 5,

        /**
         * The pixel format has an alpha channel. This is set on all formats that
         * support alpha in some way, including AV_PIX_FMT_PAL8. The alpha is always
         * straight, never pre-multiplied.
         *
         * If a codec or a filter does not support alpha, it should set all alpha to
         * opaque, or use the equivalent pixel formats without alpha component, e.g.
         * AV_PIX_FMT_RGB0 =or AV_PIX_FMT_RGB24 etc., instead of AV_PIX_FMT_RGBA.
         */
        AV_PIX_FMT_FLAG_ALPHA = 1 << 7,

        /**
         * The pixel format is following a Bayer pattern
         */
        AV_PIX_FMT_FLAG_BAYER = 1 << 8,

        /**
         * The pixel format contains IEEE-754 floating point values. Precision =double,
         * single, or half, should be determined by the pixel size =64, 32, or 16 bits,.
         */
        AV_PIX_FMT_FLAG_FLOAT = 1 << 9,

        /**
         * The pixel format contains XYZ-like data =as opposed to YUV/RGB/grayscale,.
         */
        AV_PIX_FMT_FLAG_XYZ = 1 << 10,
    }

}