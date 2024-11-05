namespace Thriving.FFmpeg.Proxy
{
    public enum AVFilterCommandFlags
    {
        /// <summary>
        /// Stop once a filter understood the command (for target=all for example), fast filters are favored automatically
        /// </summary>
        AVFILTER_CMD_FLAG_ONE = 1,
        /// <summary>
        /// Only execute command when its fast (like a video out that supports contrast adjustment in hw)
        /// </summary>
        AVFILTER_CMD_FLAG_FAST = 2,
    }

}