﻿namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVCodecProperties
    {
        /**
          * Codec uses only intra compression.
          * Video and audio codecs only.
          */
        AV_CODEC_PROP_INTRA_ONLY = (1 << 0),
        /**
         * Codec supports lossy compression. Audio and video codecs only.
         * @note a codec may support both lossy and lossless
         * compression modes
         */
        AV_CODEC_PROP_LOSSY = (1 << 1),
        /**
         * Codec supports lossless compression. Audio and video codecs only.
         */
        AV_CODEC_PROP_LOSSLESS = (1 << 2),
        /**
         * Codec supports frame reordering. That is, the coded order (the order in which
         * the encoded packets are output by the encoders / stored / input to the
         * decoders) may be different from the presentation order of the corresponding
         * frames.
         *
         * For codecs that do not have this property set, PTS and DTS should always be
         * equal.
         */
        AV_CODEC_PROP_REORDER = (1 << 3),

        /**
         * Video codec supports separate coding of fields in interlaced frames.
         */
        AV_CODEC_PROP_FIELDS = (1 << 4),

        /**
         * Subtitle codec is bitmap based
         * Decoded AVSubtitle data can be read from the AVSubtitleRect->pict field.
         */
        AV_CODEC_PROP_BITMAP_SUB = (1 << 16),
        /**
         * Subtitle codec is text based.
         * Decoded AVSubtitle data can be read from the AVSubtitleRect->ass field.
         */
        AV_CODEC_PROP_TEXT_SUB = (1 << 17)
    }
}