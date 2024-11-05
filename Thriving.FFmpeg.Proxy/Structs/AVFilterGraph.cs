using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVFilterGraph : ProxyObject
    {
        public AVFilterGraph()
        {
            _handle = Core.avfilter_graph_alloc();
        }

        ~AVFilterGraph()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.avfilter_graph_free(ref _handle);
            }
        }

        public AVFilterContext CreateAVFilter(AVFilter filter,string name)
        {
            var ptr = Core.avfilter_graph_alloc_filter(_handle, filter._handle, name);
            return new AVFilterContext(ptr);
        }

        public AVFilterContext GetFilterByName(string name)
        {
            var ptr = Core.avfilter_graph_get_filter(_handle, name);
            return new AVFilterContext(ptr);
        }

        public AVFilterContext CreateAVFilter(AVFilter filter, string name, string args)
        {
            var handle = IntPtr.Zero;
            var res = Core.avfilter_graph_create_filter(ref handle, filter._handle, name, args, IntPtr.Zero, _handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return new AVFilterContext(handle);
        }

        public string Dump(string options)
        {
            var ptr = Core.avfilter_graph_dump(_handle, options);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="cmd"></param>
        /// <param name="args"></param>
        /// <param name="flags"></param>
        /// <param name="ts"> time at which the command should be sent to the filter</param>
        public void QueueCommand(string target, string cmd, string args, int flags, double ts)
        {
            var res = Core.avfilter_graph_queue_command(_handle, target, cmd, args, flags, ts);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }


        public string SendCommand(string target, string cmd, string args, int flags)
        {
            var ptr = Marshal.AllocHGlobal(128);
            Core.avfilter_graph_send_command(_handle, target, cmd, args, ptr, 128, flags);
            var result = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);
            return result;
        }


        public AVClass Class
        {
            get
            {
                var ptr = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.av_class)).ToInt32());
                return new AVClass(ptr);
            }
        }

        public int NbFilters
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_filters)).ToInt32());
        }

        public AVFilterContext[] Filters
        {
            get
            {
                var nb_filters = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_filters)).ToInt32());
                var filters = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.filters)).ToInt32());
                var result = new AVFilterContext[nb_filters];
                for (int i = 0; i < nb_filters; i++)
                {
                    var ptr = Marshal.ReadIntPtr(filters, i * Marshal.SizeOf<IntPtr>());
                    result[i] = new AVFilterContext(ptr);
                }
                return result;
            }
        }

        public int NbThreads
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_threads)).ToInt32());
        }

        public int ThreadType
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.thread_type)).ToInt32());
        }


        [StructLayout(LayoutKind.Explicit, Size = 64)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr av_class;//AVClass* 
            [FieldOffset(8)] internal IntPtr filters;//  AVFilterContext**
            [FieldOffset(16)] internal uint nb_filters;

            [FieldOffset(24)] internal IntPtr scale_sws_opts; ///< sws options to use for the auto-inserted scale filters     char*

            /**
             * Type of multithreading allowed for filters in this graph. A combination
             * of AVFILTER_THREAD_* flags.
             *
             * May be set by the caller at any point, the setting will apply to all
             * filters initialized after that. The default is allowing everything.
             *
             * When a filter in this graph is initialized, this field is combined using
             * bit AND with AVFilterContext.thread_type to get the final mask used for
             * determining allowed threading types. I.e. a threading type needs to be
             * set in both to be allowed.
             */
            [FieldOffset(32)] internal int thread_type;

            /**
             * Maximum number of threads used by filters in this graph. May be set by
             * the caller before adding any filters to the filtergraph. Zero (the
             * default) means that the number of threads is determined automatically.
             */
            [FieldOffset(36)] internal int nb_threads;

            /**
             * Opaque user data. May be set by the caller to an arbitrary value, e.g. to
             * be used from callbacks like @ref AVFilterGraph.execute.
             * Libavfilter will not touch this field in any way.
             */
            [FieldOffset(40)] internal IntPtr opaque;

            /**
             * This callback may be set by the caller immediately after allocating the
             * graph and before adding any filters to it, to provide a custom
             * multithreading implementation.
             *
             * If set, filters with slice threading capability will call this callback
             * to execute multiple jobs in parallel.
             *
             * If this field is left unset, libavfilter will use its internal
             * implementation, which may or may not be multithreaded depending on the
             * platform and build options.
             */
            [FieldOffset(48)] internal IntPtr execute;  //    avfilter_execute_func* 

            [FieldOffset(56)] internal IntPtr aresample_swr_opts; ///< swr options to use for the auto-inserted aresample filters, Access ONLY through AVOptions     char*
        }
    }

}