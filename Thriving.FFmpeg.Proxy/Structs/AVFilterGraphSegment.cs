using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// A parsed representation of a filtergraph segment
    /// </summary>
    public class AVFilterGraphSegment : ProxyObject
    {
        ~AVFilterGraphSegment() 
        {
            Core.avfilter_graph_segment_free(ref _handle);
        }

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        struct Internal
        {
            /**
             * The filtergraph this segment is associated with.
             * Set by avfilter_graph_segment_parse().
             */
            [FieldOffset(0)] internal IntPtr graph; //    AVFilterGraph*

            /**
             * A list of filter chain contained in this segment.
             * Set in avfilter_graph_segment_parse().
             */
            [FieldOffset(8)] internal IntPtr chains; // AVFilterChain**
            [FieldOffset(16)] internal long nb_chains;

            /**
             * A string containing a colon-separated list of key=value options applied
             * to all scale filters in this segment.
             *
             * May be set by avfilter_graph_segment_parse().
             * The caller may free this string with av_free() and replace it with a
             * different av_malloc()'ed string.
             */
            [FieldOffset(24)] internal IntPtr scale_sws_opts; // char*
        }
    }

}