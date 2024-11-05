using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public unsafe partial class Core
    {
        private const string _libswresample = "swresample-5.dll";

        [DllImport(_libswresample)] public static extern IntPtr swr_alloc();
        [DllImport(_libswresample)] public static extern void swr_free(ref IntPtr SwrContext);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SwrContext"></param>
        /// <param name="out_ch_layout">AVChannelLayout*</param>
        /// <param name="out_sample_fmt"></param>
        /// <param name="out_sample_rate"></param>
        /// <param name="in_ch_layout">AVChannelLayout*</param>
        /// <param name="in_sample_fmt"></param>
        /// <param name="in_sample_rate"></param>
        /// <param name="log_offset"></param>
        /// <param name="log_ctx"></param>
        /// <returns></returns>
        [DllImport(_libswresample)]
        public static extern int swr_alloc_set_opts2(IntPtr SwrContext,
        IntPtr out_ch_layout, AVSampleFormat out_sample_fmt, int out_sample_rate,
        IntPtr in_ch_layout, AVSampleFormat in_sample_fmt, int in_sample_rate,
            int log_offset, IntPtr log_ctx);

        [DllImport(_libswresample)] public static extern void swr_build_matrix2();
        [DllImport(_libswresample)] public static extern void swr_set_matrix();

        [DllImport(_libswresample)] public static extern void swr_close(IntPtr SwrContext);

        [DllImport(_libswresample)] public static extern int swr_config_frame(IntPtr SwrContext, IntPtr outputFrame, IntPtr inputFrame);
        [DllImport(_libswresample)] public static extern int swr_convert(IntPtr SwrContext, IntPtr out_data, int out_count, IntPtr in_data, int in_count);
        [DllImport(_libswresample)] public static extern int swr_convert_frame(IntPtr SwrContext, IntPtr outputFrame, IntPtr inputFrame);
        [DllImport(_libswresample)] public static extern int swr_drop_output(IntPtr SwrContext, int count);
        [DllImport(_libswresample)] public static extern void swr_ffversion();
        [DllImport(_libswresample)] public static extern long swr_get_delay(IntPtr SwrContext, long timebse);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SwrContext"></param>
        /// <param name="in_samples"> number of input samples</param>
        /// <returns></returns>
        [DllImport(_libswresample)] public static extern int swr_get_out_samples(IntPtr SwrContext, int in_samples);
        [DllImport(_libswresample)] public static extern int swr_init(IntPtr SwrContext);
        [DllImport(_libswresample)] public static extern int swr_inject_silence(IntPtr SwrContext, int count);
        [DllImport(_libswresample)] public static extern int swr_is_initialized(IntPtr SwrContext);
        [DllImport(_libswresample)] public static extern void swr_next_pts();
        [DllImport(_libswresample)] public static extern void swr_set_channel_mapping();
        [DllImport(_libswresample)] public static extern void swr_set_compensation();

        
        [DllImport(_libswresample)] public static extern IntPtr swr_get_class();
        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libswresample)] public static extern string swresample_configuration();
        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libswresample)] public static extern string swresample_license();
        [DllImport(_libswresample)] public static extern uint swresample_version();
    }
}