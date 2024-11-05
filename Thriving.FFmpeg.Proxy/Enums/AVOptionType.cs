namespace Thriving.FFmpeg.Proxy
{
    public  enum AVOptionType
    {
        AV_OPT_TYPE_FLAGS = 1,
        AV_OPT_TYPE_INT,
        AV_OPT_TYPE_INT64,
        AV_OPT_TYPE_DOUBLE,
        AV_OPT_TYPE_FLOAT,
        AV_OPT_TYPE_STRING,
        AV_OPT_TYPE_RATIONAL,
        AV_OPT_TYPE_BINARY,  ///< offset must point to a pointer immediately followed by an int for the length
        AV_OPT_TYPE_DICT,
        AV_OPT_TYPE_UINT64,
        AV_OPT_TYPE_CONST,
        AV_OPT_TYPE_IMAGE_SIZE, ///< offset must point to two consecutive integers
        AV_OPT_TYPE_PIXEL_FMT,
        AV_OPT_TYPE_SAMPLE_FMT,
        AV_OPT_TYPE_VIDEO_RATE, ///< offset must point to AVRational
        AV_OPT_TYPE_DURATION,
        AV_OPT_TYPE_COLOR,
        AV_OPT_TYPE_BOOL,
        AV_OPT_TYPE_CHLAYOUT,

        /**
         * May be combined with another regular option type to declare an array
         * option.
         *
         * For array options, @ref AVOption.offset should refer to a pointer
         * corresponding to the option type. The pointer should be immediately
         * followed by an unsigned int that will store the number of elements in the
         * array.
         */
        AV_OPT_TYPE_FLAG_ARRAY = 1 << 16,
    };
}