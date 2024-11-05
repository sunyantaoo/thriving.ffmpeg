using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// Filter definition
    /// </summary>
    public class AVFilter : ProxyObject
    {
        internal AVFilter(IntPtr handle):base(handle) { }


        public static IList<AVFilter> GetAll()
        {
            var result = new List<AVFilter>();
            IntPtr state = IntPtr.Zero;
            IntPtr data;
            while ((data = Core.av_filter_iterate(ref state)) != IntPtr.Zero)
            {
                result.Add(new AVFilter(data));
            }
            return result;
        }

        public static AVFilter GetByName(string name)
        {
            var ptr = Core.avfilter_get_by_name(name);
            return new AVFilter(ptr);
        }


        public string Name
        {
            get
            {
                var name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.name)).ToInt32());
                return Marshal.PtrToStringAnsi(name);
            }
        }

        public string Description
        {
            get
            {
                var description = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.description)).ToInt32());
                return Marshal.PtrToStringAnsi(description);
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterContext">AVFilterContext*</param>
        /// <returns></returns>
        public delegate int PreInit(IntPtr AVFilterContext);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterContext">AVFilterContext*</param>
        /// <returns></returns>
        public delegate int Init(IntPtr AVFilterContext);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterContext">AVFilterContext*</param>
        /// <returns></returns>
        public delegate int UnInit(IntPtr AVFilterContext);


        public delegate int ProcessCommand(IntPtr AVFilterContext, string cmd, string arg, string res, int res_len, int flags);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterContext">AVFilterContext*</param>
        /// <returns></returns>
        public delegate int Activate(IntPtr AVFilterContext);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFilterContext">AVFilterContext*</param>
        /// <returns></returns>
        public delegate int QueryFunc(IntPtr AVFilterContext);

        [StructLayout(LayoutKind.Explicit, Size = 104)]
        internal struct Internal
        {
            /**
            * Filter name. Must be non-NULL and unique among filters.
            */
            [FieldOffset(0)] internal IntPtr name;

            /**
             * A description of the filter. May be NULL.
             *
             * You should use the NULL_IF_CONFIG_SMALL() macro to define it.
             */
            [FieldOffset(8)] internal IntPtr description;

            /**
             * List of static inputs.
             *
             * NULL if there are no (static) inputs. Instances of filters with
             * AVFILTER_FLAG_DYNAMIC_INPUTS set may have more inputs than present in
             * this list.
             */
            [FieldOffset(16)] internal IntPtr inputs; // AVFilterPad*

            /**
             * List of static outputs.
             *
             * NULL if there are no (static) outputs. Instances of filters with
             * AVFILTER_FLAG_DYNAMIC_OUTPUTS set may have more outputs than present in
             * this list.
             */
            [FieldOffset(24)] internal IntPtr outputs;// AVFilterPad*

            /**
             * A class for the private data, used to declare filter private AVOptions.
             * This field is NULL for filters that do not declare any options.
             *
             * If this field is non-NULL, the first member of the filter private data
             * must be a pointer to AVClass, which will be set by libavfilter generic
             * code to this class.
             */
            [FieldOffset(32)] internal IntPtr priv_class;// AVClass* 

            /**
             * A combination of AVFILTER_FLAG_*
             */
            [FieldOffset(40)] internal AVFilterFlags flags;

            /*****************************************************************
             * All fields below this line are not part of the public API. They
             * may not be used outside of libavfilter and can be changed and
             * removed at will.
             * New public fields should be added right above.
             *****************************************************************
             */

            /**
             * The number of entries in the list of inputs.
             */
            [FieldOffset(44)] internal byte nb_inputs;

            /**
             * The number of entries in the list of outputs.
             */
            [FieldOffset(45)] internal byte nb_outputs;

            /**
             * This field determines the state of the formats union.
             * It is an enum FilterFormatsState value.
             */
            [FieldOffset(46)] internal byte formats_state;

            /**
             * Filter pre-initialization function
             *
             * This callback will be called immediately after the filter context is
             * allocated, to allow allocating and initing sub-objects.
             *
             * If this callback is not NULL, the uninit callback will be called on
             * allocation failure.
             *
             * @return 0 on success,
             *         AVERROR code on failure (but the code will be
             *           dropped and treated as ENOMEM by the calling code)
             */
            [FieldOffset(48)] internal PreInit preinit;

            /**
             * Filter initialization function.
             *
             * This callback will be called only once during the filter lifetime, after
             * all the options have been set, but before links between filters are
             * established and format negotiation is done.
             *
             * Basic filter initialization should be done here. Filters with dynamic
             * inputs and/or outputs should create those inputs/outputs here based on
             * provided options. No more changes to this filter's inputs/outputs can be
             * done after this callback.
             *
             * This callback must not assume that the filter links exist or frame
             * parameters are known.
             *
             * @ref AVFilter.uninit "uninit" is guaranteed to be called even if
             * initialization fails, so this callback does not have to clean up on
             * failure.
             *
             * @return 0 on success, a negative AVERROR on failure
             */
            [FieldOffset(56)] internal Init init;

            /**
             * Filter uninitialization function.
             *
             * Called only once right before the filter is freed. Should deallocate any
             * memory held by the filter, release any buffer references, etc. It does
             * not need to deallocate the AVFilterContext.priv memory itself.
             *
             * This callback may be called even if @ref AVFilter.init "init" was not
             * called or failed, so it must be prepared to handle such a situation.
             */
            [FieldOffset(64)] internal UnInit uninit;

            /**
             * The state of the following union is determined by formats_state.
             * See the documentation of enum FilterFormatsState in internal.h.
             */
            [FieldOffset(72)] internal IntPtr formats;


            [FieldOffset(80)] internal int priv_size;      ///< size of private data to allocate for the filter

            [FieldOffset(84)] internal int flags_internal; ///< Additional flags for avfilter internal use only.

            /**
             * Make the filter instance process a command.
             *
             * @param cmd    the command to process, for handling simplicity all commands must be alphanumeric only
             * @param arg    the argument for the command
             * @param res    a buffer with size res_size where the filter(s) can return a response. This must not change when the command is not supported.
             * @param flags  if AVFILTER_CMD_FLAG_FAST is set and the command would be
             *               time consuming then a filter should treat it like an unsupported command
             *
             * @returns >=0 on success otherwise an error code.
             *          AVERROR(ENOSYS) on unsupported commands
             */
            [FieldOffset(88)] internal ProcessCommand process_command;

            /**
             * Filter activation function.
             *
             * Called when any processing is needed from the filter, instead of any
             * filter_frame and request_frame on pads.
             *
             * The function must examine inlinks and outlinks and perform a single
             * step of processing. If there is nothing to do, the function must do
             * nothing and not return an error. If more steps are or may be
             * possible, it must use ff_filter_set_ready() to schedule another
             * activation.
             */
            [FieldOffset(96)] internal Activate activate;


        }

    }

}