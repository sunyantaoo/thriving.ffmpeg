﻿namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// Resampling Filter Types
    /// </summary>
    public enum SwrFilterType
    {
        /// <summary>
        /// Cubic
        /// </summary>
        SWR_FILTER_TYPE_CUBIC,
        /// <summary>
        /// Blackman Nuttall windowed sinc
        /// </summary>
        SWR_FILTER_TYPE_BLACKMAN_NUTTALL,
        /// <summary>
        /// Kaiser windowed sinc
        /// </summary>
        SWR_FILTER_TYPE_KAISER, 
    };
}