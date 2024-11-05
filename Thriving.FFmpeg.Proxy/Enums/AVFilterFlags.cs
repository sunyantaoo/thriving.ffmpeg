namespace Thriving.FFmpeg.Proxy
{
    public enum AVFilterFlags
    {
        /**
 * The number of the filter inputs is not determined just by AVFilter.inputs.
 * The filter might add additional inputs during initialization depending on the
 * options supplied to it.
 */
        AVFILTER_FLAG_DYNAMIC_INPUTS = (1 << 0),
        /**
         * The number of the filter outputs is not determined just by AVFilter.outputs.
         * The filter might add additional outputs during initialization depending on
         * the options supplied to it.
         */
        AVFILTER_FLAG_DYNAMIC_OUTPUTS = (1 << 1),
        /**
         * The filter supports multithreading by splitting frames into multiple parts
         * and processing them concurrently.
         */
        AVFILTER_FLAG_SLICE_THREADS = (1 << 2),
        /**
         * The filter is a "metadata" filter - it does not modify the frame data in any
         * way. It may only affect the metadata (i.e. those fields copied by
         * av_frame_copy_props()).
         *
         * More precisely, this means:
         * - video: the data of any frame output by the filter must be exactly equal to
         *   some frame that is received on one of its inputs. Furthermore, all frames
         *   produced on a given output must correspond to frames received on the same
         *   input and their order must be unchanged. Note that the filter may still
         *   drop or duplicate the frames.
         * - audio: the data produced by the filter on any of its outputs (viewed e.g.
         *   as an array of interleaved samples) must be exactly equal to the data
         *   received by the filter on one of its inputs.
         */
        AVFILTER_FLAG_METADATA_ONLY = (1 << 3),

        /**
         * The filter can create hardware frames using AVFilterContext.hw_device_ctx.
         */
        AVFILTER_FLAG_HWDEVICE = (1 << 4),
        /**
         * Some filters support a generic "enable" expression option that can be used
         * to enable or disable a filter in the timeline. Filters supporting this
         * option have this flag set. When the enable expression is false, the default
         * no-op filter_frame() function is called in place of the filter_frame()
         * callback defined on each input pad, thus the frame is passed unchanged to
         * the next filters.
         */
        AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC = (1 << 16),
        /**
         * Same as AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC, except that the filter will
         * have its filter_frame() callback(s) called as usual even when the enable
         * expression is false. The filter will disable filtering within the
         * filter_frame() callback(s) itself, for example executing code depending on
         * the AVFilterContext->is_disabled value.
         */
        AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL = (1 << 17),
        /**
         * Handy mask to test whether the filter supports or no the timeline feature
         * (internally or generically).
         */
        AVFILTER_FLAG_SUPPORT_TIMELINE = (AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC | AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL)
    }

}