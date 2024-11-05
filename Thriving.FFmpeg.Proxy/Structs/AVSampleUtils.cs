using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public static class AVSampleUtils
    {
        public static string GetName(AVSampleFormat sample_fmt)
        {
            var result = Core.av_get_sample_fmt_name(sample_fmt);
            return Marshal.PtrToStringAnsi(result);
        }

        public static AVSampleFormat GetSampleFormat(string name)
        {
            return Core.av_get_sample_fmt(name);
        }

        public static AVSampleFormat GetPlanarSampleFormat(AVSampleFormat sample_fmt)
        {
            return Core.av_get_planar_sample_fmt(sample_fmt);
        }

        public static AVSampleFormat GetAlternativeSampleFormat(AVSampleFormat sample_fmt, int planar)
        {
            return Core.av_get_alt_sample_fmt(sample_fmt, planar);
        }

        public static AVSampleFormat GetPackedSampleFormat(AVSampleFormat sample_fmt)
        {
            return Core.av_get_packed_sample_fmt(sample_fmt);
        }

        public static int GetBufferSizePerSample(AVSampleFormat sample_fmt)
        {
            return Core.av_get_bytes_per_sample(sample_fmt);
        }

        public static bool IsPlanar(AVSampleFormat sample_fmt)
        {
            var res = Core.av_sample_fmt_is_planar(sample_fmt);
            return res == 1;
        }

        public static int GetBufferSize(int nb_channels, int nb_samples, AVSampleFormat sample_fmt, int align)
        {
            return Core.av_samples_get_buffer_size(out int linesize, nb_channels, nb_samples, sample_fmt, align);
        }

        public static void FillSilence(IntPtr[] audio_data, int offset, int nb_samples, int nb_channels, AVSampleFormat sample_fmt)
        {
            Core.av_samples_set_silence(audio_data, offset, nb_samples, nb_channels, sample_fmt);
        }

    }

}