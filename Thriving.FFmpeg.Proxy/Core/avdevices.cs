using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public unsafe partial class Core
    {
        private const string _libavdevice = "avdevice-61.dll";


        [DllImport(_libavdevice)] public static extern void av_device_ffversion();

        /// <summary>
        /// Audio input devices iterator
        /// </summary>
        /// <param name="AVInputFormat"></param>
        /// <returns>AVInputFormat</returns>
        [DllImport(_libavdevice)] public static extern IntPtr av_input_audio_device_next(IntPtr AVInputFormat);
        /// <summary>
        /// Video input devices iterator
        /// </summary>
        /// <param name="AVInputFormat"></param>
        /// <returns>AVInputFormat</returns>
        [DllImport(_libavdevice)] public static extern IntPtr av_input_video_device_next(IntPtr AVInputFormat);
        /// <summary>
        /// Audio output devices iterator
        /// </summary>
        /// <param name="AVOutputFormat"></param>
        /// <returns>AVOutputFormat</returns>
        [DllImport(_libavdevice)] public static extern IntPtr av_output_audio_device_next(IntPtr AVOutputFormat);
        /// <summary>
        /// Video output devices iterator
        /// </summary>
        /// <param name="AVOutputFormat"></param>
        /// <returns>AVOutputFormat</returns>
        [DllImport(_libavdevice)] public static extern IntPtr av_output_video_device_next(IntPtr AVOutputFormat);

        [DllImport(_libavdevice)] public static extern void avdevice_app_to_dev_control_message();
        [DllImport(_libavdevice)] public static extern void avdevice_dev_to_app_control_message();

        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libavdevice)] public static extern string avdevice_configuration();

        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libavdevice)] public static extern string avdevice_license();

        [DllImport(_libavdevice)] public static extern int avdevice_list_devices(IntPtr AVFormatContext,ref IntPtr AVDeviceInfoList);
        [DllImport(_libavdevice)] public static extern void avdevice_free_list_devices(IntPtr* AVDeviceInfoList);

        [DllImport(_libavdevice)] public static extern int avdevice_list_input_sources(IntPtr AVInputFormat, [MarshalAs(UnmanagedType.LPStr)] string device_name, IntPtr AVDictionary,out IntPtr AVDeviceInfoList);
        [DllImport(_libavdevice)] public static extern void avdevice_list_output_sinks(IntPtr AVInputFormat, [MarshalAs(UnmanagedType.LPStr)] string device_name, IntPtr AVDictionary,ref IntPtr AVDeviceInfoList);
        /// <summary>
        /// Initialize libavdevice and register all the input and output devices
        /// </summary>
        [DllImport(_libavdevice)] public static extern void avdevice_register_all();

        [DllImport(_libavdevice)] public static extern uint avdevice_version();
    }
}