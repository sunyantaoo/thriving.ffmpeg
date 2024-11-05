namespace Thriving.FFmpeg.Proxy
{
    [Flags]
    public enum AVDecodeErrorFlags
    {
        FF_DECODE_ERROR_INVALID_BITSTREAM = 1,
        FF_DECODE_ERROR_MISSING_REFERENCE = 2,
        FF_DECODE_ERROR_CONCEALMENT_ACTIVE = 4,
        FF_DECODE_ERROR_DECODE_SLICES = 8
    }
}