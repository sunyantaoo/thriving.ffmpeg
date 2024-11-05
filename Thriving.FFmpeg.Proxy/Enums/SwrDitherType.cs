namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// 噪声处理
    /// </summary>
    public enum SwrDitherType
    {
        SWR_DITHER_NONE = 0,
        SWR_DITHER_RECTANGULAR,
        SWR_DITHER_TRIANGULAR,
        SWR_DITHER_TRIANGULAR_HIGHPASS,

        SWR_DITHER_NS = 64,         ///< not part of API/ABI
        SWR_DITHER_NS_LIPSHITZ,
        SWR_DITHER_NS_F_WEIGHTED,
        SWR_DITHER_NS_MODIFIED_E_WEIGHTED,
        SWR_DITHER_NS_IMPROVED_E_WEIGHTED,
        SWR_DITHER_NS_SHIBATA,
        SWR_DITHER_NS_LOW_SHIBATA,
        SWR_DITHER_NS_HIGH_SHIBATA,
        SWR_DITHER_NB,              ///< not part of API/ABI
    };
}