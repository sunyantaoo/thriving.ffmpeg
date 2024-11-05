namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// Resampling Engines
    /// </summary>
    public enum SwrEngine
    {
        /// <summary>
        /// SW Resampler
        /// </summary>
        SWR_ENGINE_SWR,
        /// <summary>
        /// oX Resampler
        /// </summary>
        SWR_ENGINE_SOXR,
        SWR_ENGINE_NB,              ///< not part of API/ABI
    }
}