using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// Parameters describing a filter to be created in a filtergraph
    /// </summary>
    public class AVFilterParams : ProxyObject
    {


        [StructLayout(LayoutKind.Explicit, Size = 64)]
        struct Internal
        {
            /**
             * The filter context.
             *
             * Created by avfilter_graph_segment_create_filters() based on
             * AVFilterParams.filter_name and instance_name.
             *
             * Callers may also create the filter context manually, then they should
             * av_free() filter_name and set it to NULL. Such AVFilterParams instances
             * are then skipped by avfilter_graph_segment_create_filters().
             */
            [FieldOffset(0)] internal IntPtr filter; //  AVFilterContext*

            /**
             * Name of the AVFilter to be used.
             *
             * An av_malloc()'ed string, set by avfilter_graph_segment_parse(). Will be
             * passed to avfilter_get_by_name() by
             * avfilter_graph_segment_create_filters().
             *
             * Callers may av_free() this string and replace it with another one or
             * NULL. If the caller creates the filter instance manually, this string
             * MUST be set to NULL.
             *
             * When both AVFilterParams.filter an AVFilterParams.filter_name are NULL,
             * this AVFilterParams instance is skipped by avfilter_graph_segment_*()
             * functions.
             */
            [FieldOffset(8)] internal IntPtr filter_name; // char*
            /**
             * Name to be used for this filter instance.
             *
             * An av_malloc()'ed string, may be set by avfilter_graph_segment_parse() or
             * left NULL. The caller may av_free() this string and replace with another
             * one or NULL.
             *
             * Will be used by avfilter_graph_segment_create_filters() - passed as the
             * third argument to avfilter_graph_alloc_filter(), then freed and set to
             * NULL.
             */
            [FieldOffset(16)] internal IntPtr instance_name; // char*

            /**
             * Options to be apllied to the filter.
             *
             * Filled by avfilter_graph_segment_parse(). Afterwards may be freely
             * modified by the caller.
             *
             * Will be applied to the filter by avfilter_graph_segment_apply_opts()
             * with an equivalent of av_opt_set_dict2(filter, &opts, AV_OPT_SEARCH_CHILDREN),
             * i.e. any unapplied options will be left in this dictionary.
             */
            [FieldOffset(24)] internal IntPtr opts; //AVDictionary*

            [FieldOffset(32)] internal IntPtr inputs; // AVFilterPadParams**
            [FieldOffset(40)] internal uint nb_inputs;

            [FieldOffset(48)] internal IntPtr outputs; // AVFilterPadParams**
            [FieldOffset(56)] internal uint nb_outputs;
        }
    }

}