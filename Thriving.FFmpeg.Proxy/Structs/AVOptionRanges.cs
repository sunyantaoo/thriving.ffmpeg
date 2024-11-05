using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVOptionRanges:ProxyObject
    {



        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct Internal
        {
            /**
             * Array of option ranges.
             *
             * Most of option types use just one component.
             * Following describes multi-component option types:
             *
             * AV_OPT_TYPE_IMAGE_SIZE:
             * component index 0: range of pixel count (width * height).
             * component index 1: range of width.
             * component index 2: range of height.
             *
             * @note To obtain multi-component version of this structure, user must
             *       provide AV_OPT_MULTI_COMPONENT_RANGE to av_opt_query_ranges or
             *       av_opt_query_ranges_default function.
             *
             * Multi-component range can be read as in following example:
             *
             * @code
             * int range_index, component_index;
             * AVOptionRanges *ranges;
             * AVOptionRange *range[3]; //may require more than 3 in the future.
             * av_opt_query_ranges(&ranges, obj, key, AV_OPT_MULTI_COMPONENT_RANGE);
             * for (range_index = 0; range_index < ranges->nb_ranges; range_index++) {
             *     for (component_index = 0; component_index < ranges->nb_components; component_index++)
             *         range[component_index] = ranges->range[ranges->nb_ranges * component_index + range_index];
             *     //do something with range here.
             * }
             * av_opt_freep_ranges(&ranges);
             * @endcode
             */
            [FieldOffset(0)] internal IntPtr range;// AVOptionRange**
            /**
             * Number of ranges per component.
             */
            [FieldOffset(8)] internal int nb_ranges;
            /**
             * Number of componentes.
             */
            [FieldOffset(12)] internal int nb_components;
        }
    }

}