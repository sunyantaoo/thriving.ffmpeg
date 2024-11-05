using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVCodec : ProxyObject
    {
        internal AVCodec(IntPtr handle) : base(handle) { }

        ~AVCodec()
        {
            if (_handle != IntPtr.Zero)
            {
                Marshal.DestroyStructure<Internal>(_handle);
            }
        }

        public bool IsDecoder
        {
            get
            {
                var ret = Core.av_codec_is_decoder(_handle);
                return ret != 0;
            }
        }

        public bool IsEncoder
        {
            get
            {
                var ret = Core.av_codec_is_encoder(_handle);
                return ret != 0;
            }
        }

        public static IList<AVCodec> GetAll()
        {
            var result = new List<AVCodec>();

            int state = 0;
            IntPtr data;
            while ((data = Core.av_codec_iterate(ref state)) != IntPtr.Zero)
            {
                result.Add(new AVCodec(data));
            }
            return result;
        }

        public static AVCodec FindDecoder(AVCodecID codecID)
        {
            var ptr = Core.avcodec_find_decoder(codecID);
            return new AVCodec(ptr);
        }

        public static AVCodec FindDecoderByName(string codecName)
        {
            var ptr = Core.avcodec_find_decoder_by_name(codecName);
            return new AVCodec(ptr);
        }

        public static AVCodec FindEncoder(AVCodecID codecID)
        {
            var ptr = Core.avcodec_find_encoder(codecID);
            return new AVCodec(ptr);
        }

        public static AVCodec FindEncoderByName(string codecName)
        {
            var ptr = Core.avcodec_find_encoder_by_name(codecName);
            return new AVCodec(ptr);
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

        public string WrapperName
        {
            get
            {
                var wrapper_name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.wrapper_name)).ToInt32());
                return Marshal.PtrToStringAnsi(wrapper_name);
            }
        }

        public AVMediaType Type
        {
            get
            {
                var type = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.type)).ToInt32());
                return (AVMediaType)type;
            }
        }

        public AVCodecID Id
        {
            get
            {
                var id = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.id)).ToInt32());
                return (AVCodecID)id;
            }
        }


        public AVRational[] Supported_framerates
        {
            get
            {
                var result = new List<AVRational>();
                var supported_framerates = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.supported_framerates)).ToInt32();
                if (supported_framerates != IntPtr.Zero)
                {
                    int i = 0;
                    while (true)
                    {
                        var data = Marshal.PtrToStructure<AVRational>(supported_framerates + i * Marshal.SizeOf<AVRational>());
                        if (data.Den == 0 && data.Num == 0) { break; }
                        result.Add(data);
                        i++;
                    }
                }
                return result.ToArray();
            }
        }

        public AVPixelFormat[] PixelFormats
        {
            get
            {
                var result = new List<AVPixelFormat>();
                var pix_fmts = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pix_fmts)).ToInt32());
                if (pix_fmts != IntPtr.Zero)
                {
                    int i = 0;
                    while (true)
                    {
                        var item = Marshal.ReadInt32(pix_fmts + i * Marshal.SizeOf<int>());
                        if (item == -1)
                        {
                            break;
                        }
                        result.Add((AVPixelFormat)item);
                        i++;
                    }
                }
                return result.ToArray();
            }
        }

        public int[] SupportedSamplerates
        {
            get
            {
                var result = new List<int>();
                var supported_samplerates = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.supported_samplerates)).ToInt32());
                if (supported_samplerates != IntPtr.Zero)
                {
                    int i = 0;
                    while (true)
                    {
                        var data = Marshal.ReadInt32(supported_samplerates + i * Marshal.SizeOf<int>());
                        if (data == 0) { break; }
                        result.Add(data);
                        i++;
                    }
                }
                return result.ToArray();
            }
        }

        public AVSampleFormat[] SampleFormats
        {
            get
            {
                var result = new List<AVSampleFormat>();
                var sample_fmts = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sample_fmts)).ToInt32());
                if (sample_fmts != IntPtr.Zero)
                {
                    int i = 0;
                    while (true)
                    {
                        var data = Marshal.ReadInt32(sample_fmts + i * Marshal.SizeOf<int>());
                        if (data == -1) { break; };
                        result.Add((AVSampleFormat)data);
                        i++;
                    }
                }
                return result.ToArray();
            }
        }

        public AVProfile[] Profiles
        {
            get
            {
                var result = new List<AVProfile>();
                var profiles = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.profiles)).ToInt32());
                if (profiles != IntPtr.Zero)
                {
                    int i = 0;
                    while (true)
                    {
                        var data = new AVProfile(profiles + i * Marshal.SizeOf<AVProfile.Internal>());
                        if (data.Profile == -99) { break; }// AV_PROFILE_UNKNOWN
                        result.Add(data);
                        i++;
                    }
                }
                return result.ToArray();
            }
        }

        public AVChannelLayout[] ChannelLayouts
        {
            get
            {
                var result = new List<AVChannelLayout>();
                var ch_layouts = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.ch_layouts)).ToInt32());
                if (ch_layouts != IntPtr.Zero)
                {
                    int i = 0;
                    while (true)
                    {
                        var data = new AVChannelLayout(ch_layouts + i * Marshal.SizeOf<AVChannelLayout>());
                        if (data.NbChannels == 0) { break; }
                        result.Add(data);
                        i++;
                    }
                }
                return result.ToArray();
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 96)]
        internal struct Internal
        {
            /**
             * Name of the codec implementation.
             * The name is globally unique among encoders and among decoders (but an
             * encoder and a decoder can share the same name).
             * This is the primary way to find a codec from the user perspective.
             */
            [FieldOffset(0)]
            internal IntPtr name;
            /**
             * Descriptive name for the codec, meant to be more human readable than name.
             * You should use the NULL_IF_CONFIG_SMALL() macro to define it.
             */
            [FieldOffset(8)]
            internal IntPtr long_name;
            [FieldOffset(16)]
            internal AVMediaType type;
            [FieldOffset(20)]
            internal AVCodecID id;
            [FieldOffset(24)]
            internal AVCodecCapability capabilities;
            /// <summary>
            /// maximum value for lowres supported by the decoder
            /// </summary>
            [FieldOffset(28)]
            internal byte max_lowres;
            /// <summary>
            /// array of supported framerates, or NULL if any, array is terminated by {0,0}
            /// </summary>
            [FieldOffset(32)]
            internal IntPtr supported_framerates;
            /// <summary>
            /// array of supported pixel formats, or NULL if unknown, array is terminated by -1
            /// </summary>
            [FieldOffset(40)]
            internal IntPtr pix_fmts;
            /// <summary>
            /// array of supported audio samplerates, or NULL if unknown, array is terminated by 0
            /// </summary>
            [FieldOffset(48)]
            internal IntPtr supported_samplerates;
            /// <summary>
            /// array of supported sample formats, or NULL if unknown, array is terminated by -1
            /// </summary>
            [FieldOffset(56)]
            internal IntPtr sample_fmts;
            /// <summary>
            /// AVClass for the internal context
            /// </summary>
            [FieldOffset(64)]
            internal IntPtr priv_class;
            /// <summary>
            /// array of recognized profiles, or NULL if unknown, array is terminated by {AV_PROFILE_UNKNOWN}
            /// </summary>
            [FieldOffset(72)]
            internal IntPtr profiles;
            /**
             * Group name of the codec implementation.
             * This is a short symbolic name of the wrapper backing this codec. A
             * wrapper uses some kind of external implementation for the codec, such
             * as an external library, or a codec implementation provided by the OS or
             * the hardware.
             * If this field is NULL, this is a builtin, libavcodec native codec.
             * If non-NULL, this will be the suffix in AVCodec.name in most cases
             * (usually AVCodec.name will be of the form "<codec_name>_<wrapper_name>").
             */
            [FieldOffset(80)]
            internal IntPtr wrapper_name;
            /**
             * Array of supported channel layouts, terminated with a zeroed layout.
             */
            [FieldOffset(88)]
            internal IntPtr ch_layouts;
        }
    }
}