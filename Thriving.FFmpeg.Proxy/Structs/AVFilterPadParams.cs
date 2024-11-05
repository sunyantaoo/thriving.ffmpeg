namespace Thriving.FFmpeg.Proxy
{

    /// <summary>
    /// Parameters of a filter's input or output pad
    /// </summary>
    public struct AVFilterPadParams
    {
        /**
         * An av_malloc()'ed string containing the pad label.
         *
         * May be av_free()'d and set to NULL by the caller, in which case this pad
         * will be treated as unlabeled for linking.
         * May also be replaced by another av_malloc()'ed string.
         */
        IntPtr label; // char*
    }

}