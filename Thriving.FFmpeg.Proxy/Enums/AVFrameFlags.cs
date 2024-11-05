namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVFrameFlags
    {
        /// <summary>
        /// The frame data may be corrupted, e.g. due to decoding errors.
        /// </summary>
        AV_FRAME_FLAG_CORRUPT = (1 << 0),
        /// <summary>
        ///  A flag to mark frames that are keyframes.
        /// </summary>
        AV_FRAME_FLAG_KEY = (1 << 1),
        /// <summary>
        /// A flag to mark the frames which need to be decoded, but shouldn't be output
        /// </summary>
        AV_FRAME_FLAG_DISCARD = (1 << 2),
        /// <summary>
        /// A flag to mark frames whose content is interlaced
        /// </summary>
        AV_FRAME_FLAG_INTERLACED = (1 << 3),
        /// <summary>
        /// A flag to mark frames where the top field is displayed first if the content is interlaced
        /// </summary>
        AV_FRAME_FLAG_TOP_FIELD_FIRST = (1 << 4)
    }
}