namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// 遵从方式
    /// </summary>
    public enum AVCompliance
    {
        /// <summary>
        /// Strictly conform to an older more strict version of the spec or reference software
        /// </summary>
        FF_COMPLIANCE_VERY_STRICT = 2,
        /// <summary>
        /// Strictly conform to all the things in the spec no matter what consequences
        /// </summary>
        FF_COMPLIANCE_STRICT = 1,

        FF_COMPLIANCE_NORMAL = 0,
        /// <summary>
        /// Allow unofficial extensions
        /// </summary>
        FF_COMPLIANCE_UNOFFICIAL = -1,
        /// <summary>
        /// Allow nonstandardized experimental things
        /// </summary>
        FF_COMPLIANCE_EXPERIMENTAL = -2,
    }
}