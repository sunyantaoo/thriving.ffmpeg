namespace Thriving.FFmpeg.Proxy
{
    public enum AVIODataMarkerType
    {
        /**
         * Header data; this needs to be present for the stream to be decodeable.
         */
        AVIO_DATA_MARKER_HEADER,
        /**
         * A point in the output bytestream where a decoder can start decoding
         * (i.e. a keyframe). A demuxer/decoder given the data flagged with
         * AVIO_DATA_MARKER_HEADER, followed by any AVIO_DATA_MARKER_SYNC_POINT,
         * should give decodeable results.
         */
        AVIO_DATA_MARKER_SYNC_POINT,
        /**
         * A point in the output bytestream where a demuxer can start parsing
         * (for non self synchronizing bytestream formats). That is, any
         * non-keyframe packet start point.
         */
        AVIO_DATA_MARKER_BOUNDARY_POINT,
        /**
         * This is any, unlabelled data. It can either be a muxer not marking
         * any positions at all, it can be an actual boundary/sync point
         * that the muxer chooses not to mark, or a later part of a packet/fragment
         * that is cut into multiple write callbacks due to limited IO buffer size.
         */
        AVIO_DATA_MARKER_UNKNOWN,
        /**
         * Trailer data, which doesn't contain actual content, but only for
         * finalizing the output file.
         */
        AVIO_DATA_MARKER_TRAILER,
        /**
         * A point in the output bytestream where the underlying AVIOContext might
         * flush the buffer depending on latency or buffering requirements. Typically
         * means the end of a packet.
         */
        AVIO_DATA_MARKER_FLUSH_POINT,
    };
}