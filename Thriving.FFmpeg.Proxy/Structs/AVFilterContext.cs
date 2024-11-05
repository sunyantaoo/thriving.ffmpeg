using System;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// An instance of a filter
    /// </summary>
    public class AVFilterContext : ProxyObject
    {
        internal AVFilterContext(IntPtr handle):base(handle) { }

        ~AVFilterContext()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.avfilter_free(_handle);
            }
        }

        public void Initialize(string args)
        {
            var res = Core.avfilter_init_str(_handle, args);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }

        public void Initialize(AVDictionary dict)
        {

            var res = Core.avfilter_init_dict(_handle, ref dict._handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }

        public string PorcessCommand(string cmd, string args, int flags)
        {
            var ptr = Marshal.AllocHGlobal(128);
            Core.avfilter_process_command(_handle, cmd, args, ptr, 128, flags);
            var result = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);
            return result;
        }


        [StructLayout(LayoutKind.Explicit, Size = 152)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;        ///< needed for av_log() and filters common options

            [FieldOffset(8)] internal IntPtr filter;         ///< the AVFilter of which this is an instance

            [FieldOffset(16)] internal IntPtr name;                     ///< name of this filter instance

            [FieldOffset(24)] internal IntPtr input_pads;      ///< array of input pads
            [FieldOffset(32)] internal IntPtr inputs;          ///< array of pointers to input links
            [FieldOffset(40)] internal uint nb_inputs;          ///< number of input pads

            [FieldOffset(48)] internal IntPtr output_pads;     ///< array of output pads
            [FieldOffset(56)] internal IntPtr outputs;         ///< array of pointers to output links
            [FieldOffset(64)] internal uint nb_outputs;         ///< number of output pads

            [FieldOffset(72)] internal IntPtr priv;                     ///< private data for use by the filter

            [FieldOffset(80)] internal IntPtr graph;    ///< filtergraph this filter belongs to

            /**
             * Type of multithreading being allowed/used. A combination of
             * AVFILTER_THREAD_* flags.
             *
             * May be set by the caller before initializing the filter to forbid some
             * or all kinds of multithreading for this filter. The default is allowing
             * everything.
             *
             * When the filter is initialized, this field is combined using bit AND with
             * AVFilterGraph.thread_type to get the final mask used for determining
             * allowed threading types. I.e. a threading type needs to be set in both
             * to be allowed.
             *
             * After the filter is initialized, libavfilter sets this field to the
             * threading type that is actually used (0 for no multithreading).
             */
            [FieldOffset(88)] internal int thread_type;

            /**
             * Max number of threads allowed in this filter instance.
             * If <= 0, its value is ignored.
             * Overrides global number of threads set per filter graph.
             */
            [FieldOffset(92)] internal int nb_threads;

            [FieldOffset(96)] internal IntPtr command_queue;

            [FieldOffset(104)] internal IntPtr enable_str;               ///< enable expression string
            [FieldOffset(112)] internal IntPtr enable;                   ///< parsed expression (AVExpr*)
            [FieldOffset(120)] internal IntPtr var_values;             ///< variable values for the enable expression
            [FieldOffset(128)] internal int is_disabled;                ///< the enabled state from the last expression evaluation

            /**
             * For filters which will create hardware frames, sets the device the
             * filter should create them in.  All other filters will ignore this field:
             * in particular, a filter which consumes or processes hardware frames will
             * instead use the hw_frames_ctx field in AVFilterLink to carry the
             * hardware context information.
             *
             * May be set by the caller on filters flagged with AVFILTER_FLAG_HWDEVICE
             * before initializing the filter with avfilter_init_str() or
             * avfilter_init_dict().
             */
            [FieldOffset(136)] internal IntPtr hw_device_ctx;

            /**
             * Ready status of the filter.
             * A non-0 value means that the filter needs activating;
             * a higher value suggests a more urgent activation.
             */
            [FieldOffset(144)] internal uint ready;

            /**
             * Sets the number of extra hardware frames which the filter will
             * allocate on its output links for use in following filters or by
             * the caller.
             *
             * Some hardware filters require all frames that they will use for
             * output to be defined in advance before filtering starts.  For such
             * filters, any hardware frame pools used for output must therefore be
             * of fixed size.  The extra frames set here are on top of any number
             * that the filter needs internally in order to operate normally.
             *
             * This field must be set before the graph containing this filter is
             * configured.
             */
            [FieldOffset(148)] internal int extra_hw_frames;
        }
    }
}