namespace Thriving.FFmpeg.Proxy
{
    public enum AVError
    {
        PERM = -1,
        NOENT = -2,
        SRCH = -3,
        INTR = -4,
        IO = -5,
        NXIO = -6,
        TooBig = -7,
        NOEXEC = -8,
        BADF = -9,
        CHILD = -10,
        AGAIN = -11,
        NOMEM = -12,
        ACCES = -13,
        FAULT = -14,
        BUSY = -16,
        EXIST = -17,
        XDEV = -18,
        NODEV = -19,
        NOTDIR = -20,
        ISDIR = -21,
        NFILE = -23,
        MFILE = -24,
        NOTTY = -25,
        FBIG = -27,
        NOSPC = -28,
        SPIPE = -29,
        ROFS = -30,
        MLINK = -31,
        PIPE = -32,
        DOM = -33,
        DEADLK = -36,
        NAMETOOLONG = -38,
        NOLCK = -39,
        NOSYS = -40,
        NOTEMPTY = -41,

        /// <summary>
        ///  Bitstream filter not found
        /// </summary>
        BSF_NOT_FOUND = -(0xF8 | ('B' << 8) | ('S' << 16) | ('F' << 24)),
        /// <summary>
        /// Internal bug, also see AVERROR_BUG2
        /// </summary>
        BUG = -(('B') | ('U' << 8) | ('G' << 16) | ('!' << 24)),
        /// <summary>
        ///  Buffer too small
        /// </summary>
        BUFFER_TOO_SMALL = -(('B') | ('U' << 8) | ('F' << 16) | ('S' << 24)),
        /// <summary>
        /// Decoder not found
        /// </summary>
        DECODER_NOT_FOUND = -((0xF8) | ('D' << 8) | ('E' << 16) | ('C' << 24)),
        /// <summary>
        /// Demuxer not found
        /// </summary>
        DEMUXER_NOT_FOUND = -((0xF8) | ('D' << 8) | ('E' << 16) | ('M' << 24)),
        /// <summary>
        ///  Encoder not found
        /// </summary>
        ENCODER_NOT_FOUND = -((0xF8) | ('E' << 8) | ('N' << 16) | ('C' << 24)),
        /// <summary>
        /// End of file
        /// </summary>
        EOF = -(('E') | ('O' << 8) | ('F' << 16) | (' ' << 24)),
        /// <summary>
        /// Immediate exit was requested; the called function should not be restarted
        /// </summary>
        EXIT = -(('E') | ('X' << 8) | ('I' << 16) | ('T' << 24)),
        /// <summary>
        /// Generic error in an external library
        /// </summary>
        EXTERNAL = -(('E') | ('X' << 8) | ('T' << 16) | (' ' << 24)),
        /// <summary>
        /// Filter not found
        /// </summary>
        FILTER_NOT_FOUND = -((0xF8) | ('F' << 8) | ('I' << 16) | ('L' << 24)),
        /// <summary>
        /// Invalid data found when processing input
        /// </summary>
        INVALIDDATA = -(('I') | ('N' << 8) | ('D' << 16) | ('A' << 24)),
        /// <summary>
        /// Muxer not found
        /// </summary>
        MUXER_NOT_FOUND = -((0xF8) | ('M' << 8) | ('U' << 16) | ('X' << 24)),
        /// <summary>
        /// Option not found
        /// </summary>
        OPTION_NOT_FOUND = -((0xF8) | ('O' << 8) | ('P' << 16) | ('T' << 24)),
        /// <summary>
        /// Not yet implemented in FFmpeg, patches welcome
        /// </summary>
        PATCHWELCOME = -(('P') | ('A' << 8) | ('W' << 16) | ('E' << 24)),
        /// <summary>
        /// Protocol not found
        /// </summary>
        PROTOCOL_NOT_FOUND = -((0xF8) | ('P' << 8) | ('R' << 16) | ('O' << 24)),

        /// <summary>
        /// Stream not found
        /// </summary>
        STREAM_NOT_FOUND = -((0xF8) | ('S' << 8) | ('T' << 16) | ('R' << 24)),


        BUG2 = -(('B') | ('U' << 8) | ('G' << 16) | (' ' << 24)),
        /// <summary>
        /// Unknown error, typically from an external library
        /// </summary>
        UNKNOWN = -(('U') | ('N' << 8) | ('K' << 16) | ('N' << 24)),
        /// <summary>
        /// Requested feature is flagged experimental. Set strict_std_compliance if you really want to use it.
        /// </summary>
        EXPERIMENTAL = (-0x2bb2afa8),
        /// <summary>
        /// Input changed between calls. Reconfiguration is required. (can be OR-ed with AVERROR_OUTPUT_CHANGED)
        /// </summary>
        INPUT_CHANGED = (-0x636e6701),
        /// <summary>
        /// Output changed between calls. Reconfiguration is required. (can be OR-ed with AVERROR_INPUT_CHANGED)
        /// </summary>
        OUTPUT_CHANGED = (-0x636e6702),

        HTTP_BAD_REQUEST = -((0xF8) | ('4' << 8) | ('0' << 16) | ('0' << 24)),
        HTTP_UNAUTHORIZED = -((0xF8) | ('4' << 8) | ('0' << 16) | ('1' << 24)),
        HTTP_FORBIDDEN = -((0xF8) | ('4' << 8) | ('0' << 16) | ('3' << 24)),
        HTTP_NOT_FOUND = -((0xF8) | ('4' << 8) | ('0' << 16) | ('4' << 24)),
        HTTP_TOO_MANY_REQUESTS = -((0xF8) | ('4' << 8) | ('2' << 16) | ('9' << 24)),
        HTTP_OTHER_4XX = -((0xF8) | ('4' << 8) | ('X' << 16) | ('X' << 24)),
        HTTP_SERVER_ERROR = -((0xF8) | ('5' << 8) | ('X' << 16) | ('X' << 24)),
    }
}