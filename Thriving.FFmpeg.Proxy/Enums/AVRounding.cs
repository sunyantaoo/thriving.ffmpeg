namespace Thriving.FFmpeg.Proxy
{
    public  enum AVRounding
    {
        AV_ROUND_ZERO = 0, ///< Round toward zero.
        AV_ROUND_INF = 1, ///< Round away from zero.
        AV_ROUND_DOWN = 2, ///< Round toward -infinity.
        AV_ROUND_UP = 3, ///< Round toward +infinity.
        AV_ROUND_NEAR_INF = 5, ///< Round to nearest and halfway cases away from zero.
        AV_ROUND_PASS_MINMAX = 8192,
    };
}