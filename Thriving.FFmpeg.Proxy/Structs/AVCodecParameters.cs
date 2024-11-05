using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVCodecParameters : ProxyObject
    {

        internal AVCodecParameters(IntPtr handle):base(handle) { }


        public AVCodecParameters()
        {
            _handle = Core.avcodec_parameters_alloc();
        }

        public AVMediaType CodecType
        {
            get => (AVMediaType)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codec_type)).ToInt32());
        }

        public AVCodecID CodecId
        {
            get => (AVCodecID)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codec_id)).ToInt32());
        }


        public byte[] ExtraData
        {
            get
            {
                var extradata_size = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.extradata_size)).ToInt32());
                var extradata = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.extradata)).ToInt32());
                var result = new byte[extradata_size];
                for (int i = 0; i < extradata_size; i++)
                {
                    result[i] = Marshal.ReadByte(extradata, i);
                }
                return result;
            }
        }
        public AVPacketSideData[] Coded_side_data
        {
            get
            {
                var nb_coded_side_data = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_coded_side_data)).ToInt32());
                var coded_side_data = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.coded_side_data)).ToInt32());
                var result = new AVPacketSideData[nb_coded_side_data];
                for (int i = 0; i < nb_coded_side_data; i++)
                {
                    result[i] = Marshal.PtrToStructure<AVPacketSideData>(coded_side_data + i * Marshal.SizeOf<AVPacketSideData>());
                }
                return result;
            }
        }

        public long BitRate
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.bit_rate)).ToInt32());
            set => Marshal.WriteInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.bit_rate)).ToInt32(), value);
        }

        public int Profile
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.profile)).ToInt32());
        }


        public AVMediaType VideoFormat
        {
            get => (AVMediaType)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format)).ToInt32(), (int)value);
        }
        public AVSampleFormat AudioFormat
        {
            get => (AVSampleFormat)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format)).ToInt32(), (int)value);
        }


        public int Level
        {
            get
            {
                return Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.level)).ToInt32());
            }
        }

        public int Width
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.width)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.width)).ToInt32(), value);
        }
        public int Height
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.height)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.height)).ToInt32(), value);
        }

        /// <summary>
        /// 宽高比
        /// </summary>
        public AVRational SampleAspectRatio
        {
            get
            {
                var sample_aspect_ratio = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.sample_aspect_ratio)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(sample_aspect_ratio);
            }
        }
        /// <summary>
        /// 音频每帧大小
        /// </summary>
        public int FrameSize
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.frame_size)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.frame_size)).ToInt32(), value);
        }

        public AVColorTransferCharacteristic ColorTrc
        {
            get
            {
                var color_trc = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_trc)).ToInt32());
                return (AVColorTransferCharacteristic)color_trc;
            }
        }


        public AVColorSpace ColorSpace
        {
            get
            {
                var color_space = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_space)).ToInt32());
                return (AVColorSpace)color_space;
            }
        }

        public AVChromaLocation ChromaLocation
        {
            get
            {
                var chroma_location = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.chroma_location)).ToInt32());
                return (AVChromaLocation)chroma_location;
            }
        }


        /// <summary>
        /// 视频延迟帧数
        /// </summary>
        public int VideoDelay { get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.video_delay)).ToInt32()); }
      
        /// <summary>
        /// 音频采样率
        /// </summary>
        public int SampleRate { get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sample_rate)).ToInt32()); }

        /// <summary>
        /// 帧率
        /// </summary>
        public AVRational FrameRate
        {
            get
            {
                var framerate = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.framerate)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(framerate);
            }
        }
        public AVFieldOrder FieldOrder
        {
            get
            {
                var field_order = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.field_order)).ToInt32());
                return (AVFieldOrder)field_order;
            }
        }
        public AVColorRange ColorRange
        {
            get
            {
                var color_range = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_range)).ToInt32());
                return (AVColorRange)color_range;
            }
        }
        public AVColorPrimaries ColorPrimaries
        {
            get
            {
                var color_primaries = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.color_primaries)).ToInt32());
                return (AVColorPrimaries)color_primaries;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        readonly struct Internal
        {
            /**
             * General type of the encoded data.
             */
            [FieldOffset(0)]
            internal readonly AVMediaType codec_type;

            /**
             * Specific type of the encoded data (the codec used).
             */
            [FieldOffset(4)]
            internal readonly AVCodecID codec_id;

    
            /**
             * Additional information about the codec (corresponds to the AVI FOURCC).
             */
            [FieldOffset(8)]
            internal readonly int codec_tag;

            /**
             * Extra binary data needed for initializing the decoder, codec-dependent.
             *
             * Must be allocated with av_malloc() and will be freed by
             * avcodec_parameters_free(). The allocated size of extradata must be at
             * least extradata_size + AV_INPUT_BUFFER_PADDING_SIZE, with the padding
             * bytes zeroed.
             */
            [FieldOffset(16)]
            internal readonly IntPtr extradata;
            /**
             * Size of the extradata content in bytes.
             */
            [FieldOffset(24)]
            internal readonly int extradata_size;

          

            /**
             * Additional data associated with the entire stream.
             *
             * Should be allocated with av_packet_side_data_new() or
             * av_packet_side_data_add(), and will be freed by avcodec_parameters_free().
             */
            [FieldOffset(32)]
            internal readonly IntPtr coded_side_data;

            /**
             * Amount of entries in @ref coded_side_data.
             */
            [FieldOffset(40)]
            internal readonly int nb_coded_side_data;


      

            /**
             * - video: the pixel format, the value corresponds to enum AVPixelFormat.
             * - audio: the sample format, the value corresponds to enum AVSampleFormat.
             */
            [FieldOffset(44)]
            internal readonly int format;

    

            /**
             * The average bitrate of the encoded data (in bits per second).
             */
            [FieldOffset(48)]
            internal readonly long bit_rate;

        

            /**
             * The number of bits per sample in the codedwords.
             *
             * This is basically the bitrate per sample. It is mandatory for a bunch of
             * formats to actually decode them. It's the number of bits for one sample in
             * the actual coded bitstream.
             *
             * This could be for example 4 for ADPCM
             * For PCM formats this matches bits_per_raw_sample
             * Can be 0
             */
            [FieldOffset(56)]
            internal readonly int bits_per_coded_sample;

            /**
             * This is the number of valid bits in each output sample. If the
             * sample format has more bits, the least significant bits are additional
             * padding bits, which are always 0. Use right shifts to reduce the sample
             * to its actual size. For example, audio formats with 24 bit samples will
             * have bits_per_raw_sample set to 24, and format set to AV_SAMPLE_FMT_S32.
             * To get the original sample use "(int32_t)sample >> 8"."
             *
             * For ADPCM this might be 12 or 16 or similar
             * Can be 0
             */
            [FieldOffset(60)]
            internal readonly int bits_per_raw_sample;

            /**
             * Codec-specific bitstream restrictions that the stream conforms to.
             */
            [FieldOffset(64)]
            internal readonly int profile;
       

            [FieldOffset(68)]
            internal readonly int level;

            /**
             * Video only. The dimensions of the video frame in pixels.
             */
            [FieldOffset(72)]
            internal readonly int width;
          
            [FieldOffset(76)]
            internal readonly int height;
           

            /**
             * Video only. The aspect ratio (width / height) which a single pixel
             * should have when displayed.
             *
             * When the aspect ratio is unknown / undefined, the numerator should be
             * set to 0 (the denominator may have any value).
             */
            [FieldOffset(80)]
            internal readonly AVRational sample_aspect_ratio;




            /**
             * Video only. Number of frames per second, for streams with constant frame
             * durations. Should be set to { 0, 1 } when some frames have differing
             * durations or if the value is not known.
             *
             * @note This field correponds to values that are stored in codec-level
             * headers and is typically overridden by container/transport-layer
             * timestamps, when available. It should thus be used only as a last resort,
             * when no higher-level timing information is available.
             */
            [FieldOffset(88)]
            internal readonly AVRational framerate;

            /**
             * Video only. The order of the fields in interlaced video.
             */
            [FieldOffset(96)]
            internal readonly AVFieldOrder field_order;
        
            /**
             * Video only. Additional colorspace characteristics.
             */
            [FieldOffset(100)]
            internal readonly AVColorRange color_range;
         
            [FieldOffset(104)]
            internal readonly AVColorPrimaries color_primaries;
       

            [FieldOffset(108)]
            internal readonly AVColorTransferCharacteristic color_trc;
           

            [FieldOffset(112)]
            internal readonly AVColorSpace color_space;
           
            [FieldOffset(116)]
            internal readonly AVChromaLocation chroma_location;  
        
            /**
             * Video only. Number of delayed frames.
             */
            [FieldOffset(120)]
            internal readonly int video_delay;
          
            /**
             * Audio only. The channel layout and number of channels.
             */
            [FieldOffset(124)]
            internal readonly AVChannelLayout ch_layout;
            /**
             * Audio only. The number of audio samples per second.
             */
            [FieldOffset(152)]
            internal readonly int sample_rate;



            /**
             * Audio only. The number of bytes per coded audio frame, required by some
             * formats.
             *
             * Corresponds to nBlockAlign in WAVEFORMATEX.
             */
            [FieldOffset(156)]
            internal readonly int block_align;


            /**
             * Audio only. Audio frame size, if known. Required by some formats to be static.
             */
            [FieldOffset(160)]
            internal readonly int frame_size;



            /**
             * Audio only. The amount of padding (in samples) inserted by the encoder at
             * the beginning of the audio. I.e. this number of leading decoded samples
             * must be discarded by the caller to get the original audio without leading
             * padding.
             */
            [FieldOffset(164)]
            internal readonly int initial_padding;
            /**
             * Audio only. The amount of padding (in samples) appended by the encoder to
             * the end of the audio. I.e. this number of decoded samples must be
             * discarded by the caller from the end of the stream to get the original
             * audio without any trailing padding.
             */
            [FieldOffset(168)]
            internal readonly int trailing_padding;
            /**
             * Audio only. Number of samples to skip after a discontinuity.
             */
            [FieldOffset(172)]
            internal readonly int seek_preroll;
        }
    }
}