namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVFormatContextFlags
    {
        /// <summary>
        /// signal that no header is present (streams are added dynamically)
        /// </summary>
        AVFMTCTX_NOHEADER = 0x0001,
        /// <summary>
        /// signal that the stream is definitely not seekable, and attempts to call the seek function will fail. 
        /// For some network protocols (e.g. HLS), this can change dynamically at runtime
        /// </summary>
        AVFMTCTX_UNSEEKABLE = 0x0002
    }
}