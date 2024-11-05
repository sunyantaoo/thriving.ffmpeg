using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIAMFParamDefinition:ProxyObject
    {

        [StructLayout(LayoutKind.Explicit, Size = 36)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;

            /**
             * Offset in bytes from the start of this struct, at which the subblocks
             * array is located.
             */
            [FieldOffset(4)] internal long subblocks_offset;
            /**
             * Size in bytes of each element in the subblocks array.
             */
            [FieldOffset(8)] internal long subblock_size;
            /**
             * Number of subblocks in the array.
             */
            [FieldOffset(12)] internal uint nb_subblocks;

            /**
             * Parameters type. Determines the type of the subblock elements.
             */
            [FieldOffset(16)] internal AVIAMFParamDefinitionType type;

            /**
             * Identifier for the paremeter substream.
             */
            [FieldOffset(20)] internal uint parameter_id;
            /**
             * Sample rate for the paremeter substream. It must not be 0.
             */
            [FieldOffset(24)] internal uint parameter_rate;

            /**
             * The accumulated duration of all blocks in this parameter definition,
             * in units of 1 / @ref parameter_rate.
             *
             * May be 0, in which case all duration values should be specified in
             * another parameter definition referencing the same parameter_id.
             */
            [FieldOffset(28)] internal uint duration;
            /**
             * The duration of every subblock in the case where all subblocks, with
             * the optional exception of the last subblock, have equal durations.
             *
             * Must be 0 if subblocks have different durations.
             */
            [FieldOffset(32)] internal uint constant_subblock_duration;
        }
    }
}