namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// 编解码状态
    /// </summary>
    public enum CodecState
    {
        Success = 0,
        /// <summary>
        /// 
        /// </summary>
        Again = -11,
        /// <summary>
        /// failed to add packet/frame to internal queue, or similar
        /// </summary>
        NoMemory = -12,
        /// <summary>
        /// codec not opened, it is a decoder, or requires flush
        /// </summary>
        Invalid = -22,
        /// <summary>
        /// the encoder/decoder has been flushed, and no new frames/packets can be sent to it
        /// </summary>
        EOF = -(('E') | ('O' << 8) | ('F' << 16) | (' ' << 24))
    }
}