using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{

    public class AVOutputFormat:ProxyObject
    {


        internal AVOutputFormat(IntPtr handle):base(handle) { }

        public static AVOutputFormat GuessFormat(string short_name, string filename, string mime_type)
        {
            var handle = Core.av_guess_format(short_name, filename, mime_type);
            return new AVOutputFormat(handle);
        }

        public AVCodecID GuessCodec(string short_name, string filename, string minme_type, AVMediaType type)
        {
            var ret = Core.av_guess_codec(_handle, short_name, filename, minme_type, type);
            return (AVCodecID)ret;
        }

        /// <summary>
        /// Iterate over all registered muxers
        /// </summary>
        /// <returns></returns>
        public static IList<AVOutputFormat> GetAll()
        {
            var result = new List<AVOutputFormat>();
            IntPtr state = IntPtr.Zero;
            IntPtr data;
            while ((data = Core.av_muxer_iterate(ref state)) != IntPtr.Zero)
            {
                result.Add(new AVOutputFormat(data));
            }
            return result;
        }


        /// <summary>
        /// Test if the given container can store a codec
        /// </summary>
        /// <param name="codec_id"></param>
        /// <param name="std_compliance"></param>
        /// <returns></returns>
        public bool QueryCodec(AVCodecID codec_id, AVCompliance std_compliance)
        {
            var ret = Core.avformat_query_codec(_handle, codec_id, std_compliance);
            return ret == 1;
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


      public AVCodecID AudioCodecID
        {
            get => (AVCodecID)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.audio_codec)).ToInt32());
        }


        public AVCodecID VideoCodecID
        {
            get => (AVCodecID)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.video_codec)).ToInt32());
        }


        public AVCodecID SubtitleCodecID
        {
            get => (AVCodecID)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.subtitle_codec)).ToInt32());
        }


        [StructLayout(LayoutKind.Explicit)]
        public readonly struct Internal
        {
            [FieldOffset(0)]
            internal readonly IntPtr name;

            [FieldOffset(8)]
            internal readonly IntPtr long_name;

            [FieldOffset(16)]
            internal readonly IntPtr mime_type;

            [FieldOffset(24)]
            internal readonly IntPtr extensions;

            [FieldOffset(32)]
            internal readonly AVCodecID audio_codec;

            [FieldOffset(36)]
            internal readonly AVCodecID video_codec;

            [FieldOffset(40)]
            internal readonly AVCodecID subtitle_codec;

            /**
             * can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER,
             * AVFMT_GLOBALHEADER, AVFMT_NOTIMESTAMPS, AVFMT_VARIABLE_FPS,
             * AVFMT_NODIMENSIONS, AVFMT_NOSTREAMS,
             * AVFMT_TS_NONSTRICT, AVFMT_TS_NEGATIVE
             */
            [FieldOffset(44)]
            internal readonly AVFormatFlags flags;

            /**
             * List of supported codec_id-codec_tag pairs, ordered by "better
             * choice first". The arrays are all terminated by AV_CODEC_ID_NONE.
             */
            [FieldOffset(48)]
            internal readonly IntPtr codec_tag;

            [FieldOffset(56)]
            internal readonly IntPtr priv_class; ///< AVClass for the internal context
        }
    }
}