using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{

    public class AVInputFormat : ProxyObject
    {
        internal AVInputFormat(IntPtr handle):base(handle) { }

        public static AVInputFormat FindInputFormat(string short_name)
        {
            var handle = Core.av_find_input_format(short_name);
            return new AVInputFormat(handle);
        }

        public static AVInputFormat ProbeInputFormat(AVProbeData data, int is_opend)
        {
            var handle = Core.av_probe_input_format(data.Handle, is_opend);
            return new AVInputFormat(handle);
        }

        public static AVInputFormat ProbeInputFormat(AVProbeData data, int is_opend, int[] score_max)
        {
            var handle = Core.av_probe_input_format2(data._handle, is_opend, score_max);
            return new AVInputFormat(handle);
        }

        public static AVInputFormat ProbeInputFormat3()
        {
          //  Core.av_probe_input_format3();
            return null;
        }

        /// <summary>
        ///  Iterate over all registered demuxers
        /// </summary>
        /// <returns></returns>
        public static IList<AVInputFormat> GetAll()
        {
            var result = new List<AVInputFormat>();
            IntPtr state = IntPtr.Zero;
            IntPtr data;
            while ((data = Core.av_demuxer_iterate(ref state)) != IntPtr.Zero)
            {
                result.Add(new AVInputFormat(data));
            }
            return result;
        }

        public string Name
        {
            get
            {
                var name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.name)).ToInt32());
                return Marshal.PtrToStringAnsi(name);
            }
        }
        public string LongName
        {
            get
            {
                var long_name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.long_name)).ToInt32());
                return Marshal.PtrToStringAnsi(long_name);
            }
        }
        public string Extensions
        {
            get
            {
                var extensions = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.extensions)).ToInt32());
                return Marshal.PtrToStringAnsi(extensions);
            }
        }
        public string MimeType
        {
            get
            {
                var mime_type = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.mime_type)).ToInt32());
                return Marshal.PtrToStringAnsi(mime_type);
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public readonly struct Internal
        {
            /**
             * A comma separated list of short names for the format. New names
             * may be appended with a minor bump.
             */
            [FieldOffset(0)]
            internal readonly IntPtr name;

            /**
             * Descriptive name for the format, meant to be more human-readable
             * than name. You should use the NULL_IF_CONFIG_SMALL() macro
             * to define it.
             */
            [FieldOffset(8)]
            internal readonly IntPtr long_name;

            /**
             * Can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER, AVFMT_SHOW_IDS,
             * AVFMT_NOTIMESTAMPS, AVFMT_GENERIC_INDEX, AVFMT_TS_DISCONT, AVFMT_NOBINSEARCH,
             * AVFMT_NOGENSEARCH, AVFMT_NO_BYTE_SEEK, AVFMT_SEEK_TO_PTS.
             */
            [FieldOffset(16)]
            internal readonly AVFormatFlags flags;

            /**
             * If extensions are defined, then no probe is done. You should
             * usually not use extension format guessing because it is not
             * reliable enough
             */
            [FieldOffset(24)]
            internal readonly IntPtr extensions;

            [FieldOffset(32)]
            internal readonly IntPtr codec_tag;

            [FieldOffset(40)]
            internal readonly IntPtr priv_class; ///< AVClass for the internal context

            /**
             * Comma-separated list of mime types.
             * It is used check for matching mime types while probing.
             * @see av_probe_input_format2
             */
            [FieldOffset(48)]
            internal readonly IntPtr mime_type;
        }
    }
}