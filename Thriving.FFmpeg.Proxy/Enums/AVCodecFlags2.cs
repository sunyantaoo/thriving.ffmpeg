namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVCodecFlags2 
    {
        /**
 * Allow non spec compliant speedup tricks.
 */
        AV_CODEC_FLAG2_FAST = (1 << 0),
        /**
         * Skip bitstream encoding.
         */
        AV_CODEC_FLAG2_NO_OUTPUT = (1 << 2),
        /**
         * Place global headers at every keyframe instead of in extradata.
         */
        AV_CODEC_FLAG2_LOCAL_HEADER = (1 << 3),

        /**
         * Input bitstream might be truncated at a packet boundaries
         * instead of only at frame boundaries.
         */
        AV_CODEC_FLAG2_CHUNKS = (1 << 15),
        /**
         * Discard cropping information from SPS.
         */
        AV_CODEC_FLAG2_IGNORE_CROP = (1 << 16),

        /**
         * Show all frames before the first keyframe
         */
        AV_CODEC_FLAG2_SHOW_ALL = (1 << 22),
        /**
         * Export motion vectors through frame side data
         */
        AV_CODEC_FLAG2_EXPORT_MVS = (1 << 28),
        /**
         * Do not skip samples and export skip information as frame side data
         */
        AV_CODEC_FLAG2_SKIP_MANUAL = (1 << 29),
        /**
         * Do not reset ASS ReadOrder field on flush (subtitles decoding)
         */
        AV_CODEC_FLAG2_RO_FLUSH_NOOP = (1 << 30),
        /**
         * Generate/parse ICC profiles on encode/decode, as appropriate for the type of
         * file. No effect on codecs which cannot contain embedded ICC profiles, or
         * when compiled without support for lcms2.
         */
        AV_CODEC_FLAG2_ICC_PROFILES = (1 << 31),
    }
}