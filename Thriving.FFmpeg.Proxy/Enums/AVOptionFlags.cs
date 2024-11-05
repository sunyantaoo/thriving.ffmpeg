namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVOptionFlags
    {
        /// <summary>
        /// A generic parameter which can be set by the user for muxing or encoding
        /// </summary>
        AV_OPT_FLAG_ENCODING_PARAM = 1 << 0,
        /// <summary>
        /// A generic parameter which can be set by the user for demuxing or decoding
        /// </summary>
        AV_OPT_FLAG_DECODING_PARAM = 1 << 1,
        AV_OPT_FLAG_AUDIO_PARAM = 1 << 3,
        AV_OPT_FLAG_VIDEO_PARAM = 1 << 4,
        AV_OPT_FLAG_SUBTITLE_PARAM = 1 << 5,
        /// <summary>
        /// The option is intended for exporting values to the caller
        /// </summary>
        AV_OPT_FLAG_EXPORT = 1 << 6,
        /// <summary>
        /// The option may not be set through the AVOptions API, only read.
        /// This flag only makes sense when AV_OPT_FLAG_EXPORT is also set.
        /// </summary>
        AV_OPT_FLAG_READONLY = 1 << 7,
        /// <summary>
        /// A generic parameter which can be set by the user for bit stream filtering
        /// </summary>
        AV_OPT_FLAG_BSF_PARAM = 1 << 8,

        /// <summary>
        ///  A generic parameter which can be set by the user at runtime
        /// </summary>
        AV_OPT_FLAG_RUNTIME_PARAM = 1 << 15,
        /// <summary>
        /// A generic parameter which can be set by the user for filtering
        /// </summary>
        AV_OPT_FLAG_FILTERING_PARAM = 1 << 16,
        /// <summary>
        /// Set if option is deprecated, users should refer to AVOption.help text for  more information
        /// </summary>
        AV_OPT_FLAG_DEPRECATED = 1 << 17,
        /// <summary>
        /// Set if option constants can also reside in child objects
        /// </summary>
        AV_OPT_FLAG_CHILD_CONSTS = 1 << 18,
    }
}