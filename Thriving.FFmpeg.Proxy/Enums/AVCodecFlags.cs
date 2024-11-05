namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVCodecFlags
    {

        /**
         * Allow decoders to produce frames with data planes that are not aligned
         * to CPU requirements (e.g. due to cropping).
         */
        AV_CODEC_FLAG_UNALIGNED = (1 << 0),
        /**
         * Use fixed qscale.
         */
        AV_CODEC_FLAG_QSCALE = (1 << 1),
        /**
         * 4 MV per MB allowed / advanced prediction for H.263.
         */
        AV_CODEC_FLAG_4MV = (1 << 2),
        /**
         * Output even those frames that might be corrupted.
         */
        AV_CODEC_FLAG_OUTPUT_CORRUPT = (1 << 3),
        /**
         * Use qpel MC.
         */
        AV_CODEC_FLAG_QPEL = (1 << 4),

        /**
         * Don't output frames whose parameters differ from first
         * decoded frame in stream.
         *
         * @deprecated callers should implement this functionality in their own code
         */
        AV_CODEC_FLAG_DROPCHANGED = (1 << 5),

        /**
         * Request the encoder to output reconstructed frames, i.e.\ frames that would
         * be produced by decoding the encoded bistream. These frames may be retrieved
         * by calling avcodec_receive_frame() immediately after a successful call to
         * avcodec_receive_packet().
         *
         * Should only be used with encoders flagged with the
         * @ref AV_CODEC_CAP_ENCODER_RECON_FRAME capability.
         *
         * @note
         * Each reconstructed frame returned by the encoder corresponds to the last
         * encoded packet, i.e. the frames are returned in coded order rather than
         * presentation order.
         *
         * @note
         * Frame parameters (like pixel format or dimensions) do not have to match the
         * AVCodecContext values. Make sure to use the values from the returned frame.
         */
        AV_CODEC_FLAG_RECON_FRAME = (1 << 6),
        /**
         * @par decoding
         * Request the decoder to propagate each packet's AVPacket.opaque and
         * AVPacket.opaque_ref to its corresponding output AVFrame.
         *
         * @par encoding:
         * Request the encoder to propagate each frame's AVFrame.opaque and
         * AVFrame.opaque_ref values to its corresponding output AVPacket.
         *
         * @par
         * May only be set on encoders that have the
         * @ref AV_CODEC_CAP_ENCODER_REORDERED_OPAQUE capability flag.
         *
         * @note
         * While in typical cases one input frame produces exactly one output packet
         * (perhaps after a delay), in general the mapping of frames to packets is
         * M-to-N, so
         * - Any number of input frames may be associated with any given output packet.
         *   This includes zero - e.g. some encoders may output packets that carry only
         *   metadata about the whole stream.
         * - A given input frame may be associated with any number of output packets.
         *   Again this includes zero - e.g. some encoders may drop frames under certain
         *   conditions.
         * .
         * This implies that when using this flag, the caller must NOT assume that
         * - a given input frame's opaques will necessarily appear on some output packet;
         * - every output packet will have some non-NULL opaque value.
         * .
         * When an output packet contains multiple frames, the opaque values will be
         * taken from the first of those.
         *
         * @note
         * The converse holds for decoders, with frames and packets switched.
         */
        AV_CODEC_FLAG_COPY_OPAQUE = (1 << 7),
        /**
         * Signal to the encoder that the values of AVFrame.duration are valid and
         * should be used (typically for transferring them to output packets).
         *
         * If this flag is not set, frame durations are ignored.
         */
        AV_CODEC_FLAG_FRAME_DURATION = (1 << 8),
        /**
         * Use internal 2pass ratecontrol in first pass mode.
         */
        AV_CODEC_FLAG_PASS1 = (1 << 9),
        /**
         * Use internal 2pass ratecontrol in second pass mode.
         */
        AV_CODEC_FLAG_PASS2 = (1 << 10),
        /**
         * loop filter.
         */
        AV_CODEC_FLAG_LOOP_FILTER = (1 << 11),
        /**
         * Only decode/encode grayscale.
         */
        AV_CODEC_FLAG_GRAY = (1 << 13),
        /**
         * error[?] variables will be set during encoding.
         */
        AV_CODEC_FLAG_PSNR = (1 << 15),
        /**
         * Use interlaced DCT.
         */
        AV_CODEC_FLAG_INTERLACED_DCT = (1 << 18),
        /**
         * Force low delay.
         */
        AV_CODEC_FLAG_LOW_DELAY = (1 << 19),
        /**
         * Place global headers in extradata instead of every keyframe.
         */
        AV_CODEC_FLAG_GLOBAL_HEADER = (1 << 22),
        /**
         * Use only bitexact stuff (except (I)DCT).
         */
        AV_CODEC_FLAG_BITEXACT = (1 << 23),
        /* Fx : Flag for H.263+ extra options */
        /**
         * H.263 advanced intra coding / MPEG-4 AC prediction
         */
        AV_CODEC_FLAG_AC_PRED = (1 << 24),
        /**
         * interlaced motion estimation
         */
        AV_CODEC_FLAG_INTERLACED_ME = (1 << 29),
        AV_CODEC_FLAG_CLOSED_GOP = (1 << 31),
    }
}