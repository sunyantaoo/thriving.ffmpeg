using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public unsafe class SwrContext : ProxyObject
    {
        public SwrContext()
        {
            _handle = Core.swr_alloc();
        }


        public SwrContext(AVChannelLayout out_ch_layout, AVSampleFormat out_sample_fmt, int out_sample_rate,
            AVChannelLayout in_ch_layout, AVSampleFormat in_sample_fmt, int in_sample_rate,
            int log_offset, IntPtr log_ctx)
        {
            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>());
            var ret = Core.swr_alloc_set_opts2(ptr, new IntPtr(&out_ch_layout), out_sample_fmt, out_sample_rate,new IntPtr( &in_ch_layout), in_sample_fmt, in_sample_rate, log_offset, log_ctx);
            if (ret >= 0)
            {
                _handle = Marshal.ReadIntPtr(ptr);
            }
            Marshal.FreeHGlobal(ptr);
        }

        ~SwrContext()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.swr_free(ref _handle);
            }
        }

        public int Init()
        {
            return Core.swr_init(_handle);
        }

        public bool IsInitialized()
        {
            var ret = Core.swr_is_initialized(_handle);
            return ret > 0;
        }

        public void Close()
        {
            Core.swr_close(_handle);
        }

        public int DropOutput(int count)
        {
            return Core.swr_drop_output(_handle, count);
        }

        public int InjectSilence(int count)
        {
            return Core.swr_inject_silence(_handle, count);
        }

        public long GetDelay(long timebase)
        {
            return Core.swr_get_delay(_handle, timebase);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="in_samples">number of input samples</param>
        /// <returns></returns>
        public int GetOutSamples(int in_samples)
        {
            return Core.swr_get_out_samples(_handle, in_samples);
        }

        public int Convert(IntPtr out_data, int out_count, IntPtr in_data, int in_count)
        {
            return Core.swr_convert(_handle, out_data, out_count, in_data, in_count);
        }



        public static AVClass Class
        {
            get
            {
                var av_class = Core.swr_get_class();
                return new AVClass(av_class);
            }
        }

        public static uint Version
        {
            get => Core.swresample_version();
        }

        public static string Configuration
        {
            get => Core.swresample_configuration();
        }

        public static string License
        {
            get => Core.swresample_license();
        }

    }
}