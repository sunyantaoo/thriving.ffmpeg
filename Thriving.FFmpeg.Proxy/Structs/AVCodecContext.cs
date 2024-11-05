using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public unsafe class AVCodecContext : ProxyOptionObject
    {
        public AVCodecContext(AVCodec codec)
        {
            _handle = Core.avcodec_alloc_context3(codec._handle);
        }

        ~AVCodecContext()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.avcodec_free_context(ref _handle);
            }
        }

        public void Open(AVCodec codec, AVDictionary? dict = null)
        {
            var dictPtr = dict == null ? IntPtr.Zero : dict._handle;
            var ret = Core.avcodec_open2(_handle, codec._handle, ref dictPtr);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public bool IsOpen()
        {
            return Core.avcodec_is_open(_handle) > 0;
        }

        public void EncodeSubtitle(AVSubtitle subtitle, IntPtr buf, int buf_size)
        {
            var res = Core.avcodec_encode_subtitle(_handle, buf, buf_size, subtitle._handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }

        public AVSubtitle DecodeSubtitle(AVPacket packet)
        {
            IntPtr subtitle = IntPtr.Zero;
            var got_sub = 0;
            var res = Core.avcodec_decode_subtitle2(_handle, subtitle, ref got_sub, packet._handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return new AVSubtitle(subtitle);
        }




        public void Close()
        {
            Core.avcodec_close(_handle);
        }

        public void SetParameters(AVCodecParameters parameters)
        {
            var ret = Core.avcodec_parameters_to_context(_handle, parameters._handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public AVCodecParameters GetParameters()
        {
            var parameters = new AVCodecParameters();
            var ret = Core.avcodec_parameters_from_context(parameters._handle, _handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
            return parameters;
        }

        /// <summary>
        /// 编码并将数据写入AVPacket
        /// </summary>
        /// <param name="pkt"></param>
        /// <returns></returns>
        public int ReceivePacket(AVPacket pkt)
        {
            return Core.avcodec_receive_packet(_handle, pkt._handle);
        }

        /// <summary>
        ///  解码并将数据写入帧(AVFrame)
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public bool ReceiveFrame(AVFrame frame)
        {
            var ret = Core.avcodec_receive_frame(_handle, frame._handle);
            // if (ret < 0) throw FFmpegException.FromErrorCode(ret);
            return ret >= 0;
        }

        /// <summary>
        /// 将原始帧数据(AVPacket)发送到解码器
        /// </summary>
        /// <param name="pkt"></param>
        public void SendPacket(AVPacket pkt)
        {
            var ret = Core.avcodec_send_packet(_handle, pkt._handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        /// <summary>
        /// 将编码后的帧数据(AVFrame)发送到编码器
        /// </summary>
        /// <param name="frame"></param>
        public void SendFrame(AVFrame frame)
        {
            var ret = Core.avcodec_send_frame(_handle, frame._handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }


        #region 属性

        public AVClass Class
        {
            get
            {
                var av_class = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.av_class)).ToInt32());
                return new AVClass(av_class);
            }
        }

        public AVCodec Codec
        {
            get
            {
                var codec = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codec)).ToInt32());
                return new AVCodec(codec);
            }
        }

        public AVPixelFormat PixelFormat
        {
            get => (AVPixelFormat)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pix_fmt)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pix_fmt)).ToInt32(), (int)value);
        }

        public AVSampleFormat SampleFormat
        {
            get => (AVSampleFormat)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sample_fmt)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sample_fmt)).ToInt32(), (int)value);
        }

        public int SampleRate
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sample_rate)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sample_rate)).ToInt32(), value);
        }

        public long BitRate
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.bit_rate)).ToInt32());
            set => Marshal.WriteInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.bit_rate)).ToInt32(), value);
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

        public int MaxBFrames
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.max_b_frames)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.max_b_frames)).ToInt32(), value);
        }

        public int GopSize
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.gop_size)).ToInt32());
            set => Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.gop_size)).ToInt32(), value);
        }

        public AVRational FrameRate
        {
            get
            {
                var framerate = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.framerate)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(framerate);
            }
            set
            {
                var framerate = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.framerate)).ToInt32();
                Marshal.StructureToPtr<AVRational>(value, framerate, true);
            }
        }

        public long FrameNum
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.frame_num)).ToInt32());
        }

        public int FrameSize
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.frame_size)).ToInt32());
        }

        /// <summary>
        /// 1/FrameRate
        /// </summary>
        public AVRational TimeBase
        {
            get
            {
                var time_base = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.time_base)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(time_base);
            }
            set
            {
                var time_base = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.time_base)).ToInt32();
                Marshal.StructureToPtr<AVRational>(value, time_base, true);
            }
        }

        public AVRational PacketTimeBase
        {
            get
            {
                var pkt_timebase = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.pkt_timebase)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(pkt_timebase);
            }
            set
            {
                var pkt_timebase = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.pkt_timebase)).ToInt32();
                Marshal.StructureToPtr<AVRational>(value, pkt_timebase, true);
            }
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

        public string Stats_out
        {
            get
            {
                var stats_out = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.stats_out)).ToInt32());
                return Marshal.PtrToStringAnsi(stats_out);
            }
        }

        public string Stats_in
        {
            get
            {
                var stats_in = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.stats_in)).ToInt32());
                return Marshal.PtrToStringAnsi(stats_in);
            }
        }

        public RcOverride RcOverride
        {
            get
            {
                var rc_override = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.rc_override)).ToInt32());
                return new RcOverride(rc_override);
            }
        }

        public AVHWAccel? HWAccel
        {
            get
            {
                var hwaccel = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.hwaccel)).ToInt32());
                return hwaccel == IntPtr.Zero ? null : Marshal.PtrToStructure<AVHWAccel>(hwaccel);
            }
        }

        public AVBufferRef? Hw_Frames_ctx
        {
            get
            {
                var hw_frames_ctx = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.hw_frames_ctx)).ToInt32());
                return new AVBufferRef(hw_frames_ctx);
            }
        }

        public AVBufferRef? Hw_Device_ctx
        {
            get
            {
                var hw_device_ctx = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.hw_device_ctx)).ToInt32());
                return new AVBufferRef(hw_device_ctx);
            }
        }


        public AVCodecDescriptor CodecDescriptor
        {
            get
            {
                var codec_descriptor = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codec_descriptor)).ToInt32());
                return new AVCodecDescriptor(codec_descriptor);
            }
        }


        public string SubCharenc
        {
            get
            {
                var sub_charenc = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.sub_charenc)).ToInt32());
                return Marshal.PtrToStringAnsi(sub_charenc);
            }
        }


        public string CodecWhitelist
        {
            get
            {
                var codec_whitelist = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codec_whitelist)).ToInt32());
                return Marshal.PtrToStringAnsi(codec_whitelist);
            }
        }

        public AVCodecFlags Flags
        {
            get
            {
                var flags = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.flags)).ToInt32());
                return (AVCodecFlags)flags;
            }
        }

        public AVCodecFlags2 Flags2
        {
            get
            {
                var flags2 = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.flags2)).ToInt32());
                return (AVCodecFlags2)flags2;
            }
        }

        public AVCodecID CodecId
        {
            get
            {
                var codec_id = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codec_id)).ToInt32());
                return (AVCodecID)codec_id;
            }
        }

        public AVMediaType CodecType
        {
            get
            {
                var codec_type = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codec_type)).ToInt32());
                return (AVMediaType)codec_type;
            }
        }

        public AVChannelLayout ChannelLayout
        {
            get
            {
                var ch_layout = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.ch_layout)).ToInt32();
                return new AVChannelLayout(ch_layout);
            }
            set
            {
                var ch_layout = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.ch_layout)).ToInt32();
                Core.av_channel_layout_copy(ch_layout,ref value);
            }
        }






        #endregion

        public unsafe delegate AVPixelFormat getFormat(IntPtr AVCodecContext, AVPixelFormat fmt);

        public unsafe delegate int codecFunc(IntPtr AVCodecContext, IntPtr arg);

        public unsafe delegate int codecFunc2(IntPtr AVCodecContext, IntPtr arg, int jobnr, int threadnr);

        public unsafe delegate int executeCodec(IntPtr AVCodecContext, codecFunc func, IntPtr arg, IntPtr ret, int count, int size);

        public unsafe delegate int executeCodec2(IntPtr AVCodecContext, codecFunc2 func, IntPtr arg, IntPtr ret, int count);

        public unsafe delegate int getBuffer2(IntPtr AVCodecContext, IntPtr AVFrame, int flags);

        public unsafe delegate int get_encode_buffer(IntPtr AVCodecContext, IntPtr AVPacket, int flags);

        public unsafe delegate void draw_horiz_band(IntPtr AVCodecContext, IntPtr AVFrame, int[] offset, int y, int type, int height);


        [StructLayout(LayoutKind.Explicit, Size = 864)]
        readonly struct Internal
        {
            /**
             * information on struct for av_log
             * - set by avcodec_alloc_context3
             */
            [FieldOffset(0)] internal readonly IntPtr av_class;

            [FieldOffset(8)] internal readonly int log_level_offset;

            [FieldOffset(12)] internal readonly AVMediaType codec_type;

            [FieldOffset(16)] internal readonly IntPtr codec;

            [FieldOffset(24)] internal readonly AVCodecID codec_id;

            /**
             * fourcc (LSB first, so "ABCD" -> ('D'<<24) + ('C'<<16) + ('B'<<8) + 'A').
             * This is used to work around some encoder bugs.
             * A demuxer should set this to what is stored in the field used to identify the codec.
             * If there are multiple such fields in a container then the demuxer should choose the one
             * which maximizes the information about the used codec.
             * If the codec tag field in a container is larger than 32 bits then the demuxer should
             * remap the longer ID to 32 bits with a table or other structure. Alternatively a new
             * extra_codec_tag + size could be added but for this a clear advantage must be demonstrated
             * first.
             * - encoding: Set by user, if not then the default based on codec_id will be used.
             * - decoding: Set by user, will be converted to uppercase by libavcodec during init.
             */
            [FieldOffset(28)] internal readonly uint codec_tag;

            [FieldOffset(32)] internal readonly IntPtr priv_data;

            /**
             * internal context used for internal data.
             *
             * Unlike priv_data, this is not codec-specific. It is used in general
             * libavcodec functions.
             */
            [FieldOffset(40)] internal readonly IntPtr codec_internal;

            /**
             * internal data of the user, can be used to carry app specific stuff.
             * - encoding: Set by user.
             * - decoding: Set by user.
             */
            [FieldOffset(48)] internal readonly IntPtr opaque;

            /**
             * the average bitrate
             * - encoding: Set by user; unused for constant quantizer encoding.
             * - decoding: Set by user, may be overwritten by libavcodec
             *             if this info is available in the stream
             */
            [FieldOffset(56)] internal readonly long bit_rate;

            /**
             * AV_CODEC_FLAG_*.
             * - encoding: Set by user.
             * - decoding: Set by user.
             */
            [FieldOffset(64)] internal readonly AVCodecFlags flags;

            /**
             * AV_CODEC_FLAG2_*
             * - encoding: Set by user.
             * - decoding: Set by user.
             */
            [FieldOffset(68)] internal readonly AVCodecFlags2 flags2;

            /**
             * some codecs need / can use extradata like Huffman tables.
             * MJPEG: Huffman tables
             * rv10: additional flags
             * MPEG-4: global headers (they can be in the bitstream or here)
             * The allocated memory should be AV_INPUT_BUFFER_PADDING_SIZE bytes larger
             * than extradata_size to avoid problems if it is read with the bitstream reader.
             * The bytewise contents of extradata must not depend on the architecture or CPU endianness.
             * Must be allocated with the av_malloc() family of functions.
             * - encoding: Set/allocated/freed by libavcodec.
             * - decoding: Set/allocated/freed by user.
             */
            [FieldOffset(72)] internal readonly IntPtr extradata;
            [FieldOffset(80)] internal readonly int extradata_size;



            /**
             * This is the fundamental unit of time (in seconds) in terms
             * of which frame timestamps are represented. For fixed-fps content,
             * timebase should be 1/framerate and timestamp increments should be
             * identically 1.
             * This often, but not always is the inverse of the frame rate or field rate
             * for video. 1/time_base is not the average frame rate if the frame rate is not
             * constant.
             *
             * Like containers, elementary streams also can store timestamps, 1/time_base
             * is the unit in which these timestamps are specified.
             * As example of such codec time base see ISO/IEC 14496-2:2001(E)
             * vop_time_increment_resolution and fixed_vop_rate
             * (fixed_vop_rate == 0 implies that it is different from the framerate)
             *
             * - encoding: MUST be set by user.
             * - decoding: unused.
             */
            [FieldOffset(84)] internal readonly AVRational time_base;

            /**
             * Timebase in which pkt_dts/pts and AVPacket.dts/pts are expressed.
             * - encoding: unused.
             * - decoding: set by user.
             */
            [FieldOffset(92)] internal readonly AVRational pkt_timebase;

            /**
             * - decoding: For codecs that store a framerate value in the compressed
             *             bitstream, the decoder may export it here. { 0, 1} when
             *             unknown.
             * - encoding: May be used to signal the framerate of CFR content to an
             *             encoder.
             */
            [FieldOffset(100)] internal readonly AVRational framerate;


            /**
             * For some codecs, the time base is closer to the field rate than the frame rate.
             * Most notably, H.264 and MPEG-2 specify time_base as half of frame duration
             * if no telecine is used ...
             *
             * Set to time_base ticks per frame. Default 1, e.g., H.264/MPEG-2 set it to 2.
             *
             * @deprecated
             * - decoding: Use AVCodecDescriptor.props & AV_CODEC_PROP_FIELDS
             * - encoding: Set AVCodecContext.framerate instead
             *
             */

            [FieldOffset(108)] internal readonly int ticks_per_frame;


            /**
             * Codec delay.
             *
             * Encoding: Number of frames delay there will be from the encoder input to
             *           the decoder output. (we assume the decoder matches the spec)
             * Decoding: Number of frames delay in addition to what a standard decoder
             *           as specified in the spec would produce.
             *
             * Video:
             *   Number of frames the decoded output will be delayed relative to the
             *   encoded input.
             *
             * Audio:
             *   For encoding, this field is unused (see initial_padding).
             *
             *   For decoding, this is the number of samples the decoder needs to
             *   output before the decoder's output is valid. When seeking, you should
             *   start decoding this many samples prior to your desired seek point.
             *
             * - encoding: Set by libavcodec.
             * - decoding: Set by libavcodec.
             */
            [FieldOffset(112)] internal readonly int delay;


            /* video only */
            /**
             * picture width / height.
             *
             * @note Those fields may not match the values of the last
             * AVFrame output by avcodec_receive_frame() due frame
             * reordering.
             *
             * - encoding: MUST be set by user.
             * - decoding: May be set by the user before opening the decoder if known e.g.
             *             from the container. Some decoders will require the dimensions
             *             to be set by the caller. During decoding, the decoder may
             *             overwrite those values as required while parsing the data.
             */
            [FieldOffset(116)] internal readonly int width;

            [FieldOffset(120)] internal readonly int height;

            /**
             * Bitstream width / height, may be different from width/height e.g. when
             * the decoded frame is cropped before being output or lowres is enabled.
             *
             * @note Those field may not match the value of the last
             * AVFrame output by avcodec_receive_frame() due frame
             * reordering.
             *
             * - encoding: unused
             * - decoding: May be set by the user before opening the decoder if known
             *             e.g. from the container. During decoding, the decoder may
             *             overwrite those values as required while parsing the data.
             */
            [FieldOffset(124)] internal readonly int coded_width;
            [FieldOffset(128)] internal readonly int coded_height;

            /**
             * sample aspect ratio (0 if unknown)
             * That is the width of a pixel divided by the height of the pixel.
             * Numerator and denominator must be relatively prime and smaller than 256 for some video standards.
             * - encoding: Set by user.
             * - decoding: Set by libavcodec.
             */
            [FieldOffset(132)] internal readonly AVRational sample_aspect_ratio;

            /**
             * Pixel format, see AV_PIX_FMT_xxx.
             * May be set by the demuxer if known from headers.
             * May be overridden by the decoder if it knows better.
             *
             * @note This field may not match the value of the last
             * AVFrame output by avcodec_receive_frame() due frame
             * reordering.
             *
             * - encoding: Set by user.
             * - decoding: Set by user if known, overridden by libavcodec while
             *             parsing the data.
             */
            [FieldOffset(140)] internal readonly AVPixelFormat pix_fmt;

            /**
             * Nominal unaccelerated pixel format, see AV_PIX_FMT_xxx.
             * - encoding: unused.
             * - decoding: Set by libavcodec before calling get_format()
             */
            [FieldOffset(144)] internal readonly AVPixelFormat sw_pix_fmt;

            /**
             * Chromaticity coordinates of the source primaries.
             * - encoding: Set by user
             * - decoding: Set by libavcodec
             */
            [FieldOffset(148)] internal readonly AVColorPrimaries color_primaries;

            /**
             * Color Transfer Characteristic.
             * - encoding: Set by user
             * - decoding: Set by libavcodec
             */
            [FieldOffset(152)] internal readonly AVColorTransferCharacteristic color_trc;

            /**
             * YUV colorspace type.
             * - encoding: Set by user
             * - decoding: Set by libavcodec
             */
            [FieldOffset(156)] internal readonly AVColorSpace colorspace;

            /**
             * MPEG vs JPEG YUV range.
             * - encoding: Set by user to override the default output color range value,
             *   If not specified, libavcodec sets the color range depending on the
             *   output format.
             * - decoding: Set by libavcodec, can be set by the user to propagate the
             *   color range to components reading from the decoder context.
             */
            [FieldOffset(160)] internal readonly AVColorRange color_range;

            /**
             * This defines the location of chroma samples.
             * - encoding: Set by user
             * - decoding: Set by libavcodec
             */
            [FieldOffset(164)] internal readonly AVChromaLocation chroma_sample_location;

            /** Field order
             * - encoding: set by libavcodec
             * - decoding: Set by user.
             */
            [FieldOffset(168)] internal readonly AVFieldOrder field_order;

            /**
             * number of reference frames
             * - encoding: Set by user.
             * - decoding: Set by lavc.
             */
            [FieldOffset(172)] internal readonly int refs;

            /**
             * Size of the frame reordering buffer in the decoder.
             * For MPEG-2 it is 1 IPB or 0 low delay IP.
             * - encoding: Set by libavcodec.
             * - decoding: Set by libavcodec.
             */
            [FieldOffset(176)] internal readonly int has_b_frames;

            /**
             * slice flags
             * - encoding: unused
             * - decoding: Set by user.
             */
            [FieldOffset(180)] internal readonly int slice_flags;


            /**
             * If non NULL, 'draw_horiz_band' is called by the libavcodec
             * decoder to draw a horizontal band. It improves cache usage. Not
             * all codecs can do that. You must check the codec capabilities
             * beforehand.
             * When multithreading is used, it may be called from multiple threads
             * at the same time; threads might draw different parts of the same AVFrame,
             * or multiple AVFrames, and there is no guarantee that slices will be drawn
             * in order.
             * The function is also used by hardware acceleration APIs.
             * It is called at least once during frame decoding to pass
             * the data needed for hardware render.
             * In that mode instead of pixel data, AVFrame points to
             * a structure specific to the acceleration API. The application
             * reads the structure and can change some fields to indicate progress
             * or mark state.
             * - encoding: unused
             * - decoding: Set by user.
             * @param height the height of the slice
             * @param y the y position of the slice
             * @param type 1->top field, 2->bottom field, 3->frame
             * @param offset offset into the AVFrame.data from which the slice should be read
             */
            [FieldOffset(184)] internal readonly draw_horiz_band draw_horiz_band;

            /**
             * Callback to negotiate the pixel format. Decoding only, may be set by the
             * caller before avcodec_open2().
             *
             * Called by some decoders to select the pixel format that will be used for
             * the output frames. This is mainly used to set up hardware acceleration,
             * then the provided format list contains the corresponding hwaccel pixel
             * formats alongside the "software" one. The software pixel format may also
             * be retrieved from \ref sw_pix_fmt.
             *
             * This callback will be called when the coded frame properties (such as
             * resolution, pixel format, etc.) change and more than one output format is
             * supported for those new properties. If a hardware pixel format is chosen
             * and initialization for it fails, the callback may be called again
             * immediately.
             *
             * This callback may be called from different threads if the decoder is
             * multi-threaded, but not from more than one thread simultaneously.
             *
             * @param fmt list of formats which may be used in the current
             *            configuration, terminated by AV_PIX_FMT_NONE.
             * @warning Behavior is undefined if the callback returns a value other
             *          than one of the formats in fmt or AV_PIX_FMT_NONE.
             * @return the chosen format or AV_PIX_FMT_NONE
             */
            [FieldOffset(192)] internal readonly getFormat get_format;

            /**
             * maximum number of B-frames between non-B-frames
             * Note: The output will be delayed by max_b_frames+1 relative to the input.
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(200)] internal readonly int max_b_frames;

            /**
             * qscale factor between IP and B-frames
             * If > 0 then the last P-frame quantizer will be used (q= lastp_q*factor+offset).
             * If < 0 then normal ratecontrol will be done (q= -normal_q*factor+offset).
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(204)] internal readonly float b_quant_factor;

            /**
             * qscale offset between IP and B-frames
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(208)] internal readonly float b_quant_offset;

            /**
             * qscale factor between P- and I-frames
             * If > 0 then the last P-frame quantizer will be used (q = lastp_q * factor + offset).
             * If < 0 then normal ratecontrol will be done (q= -normal_q*factor+offset).
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(212)] internal readonly float i_quant_factor;

            /**
             * qscale offset between P and I-frames
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(216)] internal readonly float i_quant_offset;

            /**
             * luminance masking (0-> disabled)
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(220)] internal readonly float lumi_masking;

            /**
             * temporary complexity masking (0-> disabled)
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(224)] internal readonly float temporal_cplx_masking;

            /**
             * spatial complexity masking (0-> disabled)
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(228)] internal readonly float spatial_cplx_masking;

            /**
             * p block masking (0-> disabled)
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(232)] internal readonly float p_masking;

            /**
             * darkness masking (0-> disabled)
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(236)] internal readonly float dark_masking;

            /**
             * noise vs. sse weight for the nsse comparison function
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(240)] internal readonly int nsse_weight;

            /**
             * motion estimation comparison function
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(244)] internal readonly int me_cmp;
            /**
             * subpixel motion estimation comparison function
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(248)] internal readonly int me_sub_cmp;
            /**
             * macroblock comparison function (not supported yet)
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(252)] internal readonly int mb_cmp;
            /**
             * interlaced DCT comparison function
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(256)] internal readonly int ildct_cmp;

            /**
             * ME diamond size & shape
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(260)] internal readonly int dia_size;

            /**
             * amount of previous MV predictors (2a+1 x 2a+1 square)
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(264)] internal readonly int last_predictor_count;

            /**
             * motion estimation prepass comparison function
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(268)] internal readonly int me_pre_cmp;

            /**
             * ME prepass diamond size & shape
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(272)] internal readonly int pre_dia_size;

            /**
             * subpel ME quality
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(276)] internal readonly int me_subpel_quality;

            /**
             * maximum motion estimation search range in subpel units
             * If 0 then no limit.
             *
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(280)] internal readonly int me_range;

            /**
             * macroblock decision mode
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(284)] internal readonly int mb_decision;

            /**
             * custom intra quantization matrix
             * Must be allocated with the av_malloc() family of functions, and will be freed in
             * avcodec_free_context().
             * - encoding: Set/allocated by user, freed by libavcodec. Can be NULL.
             * - decoding: Set/allocated/freed by libavcodec.
             */
            [FieldOffset(288)] internal readonly IntPtr intra_matrix;//short*



            /**
             * custom inter quantization matrix
             * Must be allocated with the av_malloc() family of functions, and will be freed in
             * avcodec_free_context().
             * - encoding: Set/allocated by user, freed by libavcodec. Can be NULL.
             * - decoding: Set/allocated/freed by libavcodec.
             */
            [FieldOffset(296)] internal readonly IntPtr inter_matrix;//short*

            /**
             * custom intra quantization matrix
             * - encoding: Set by user, can be NULL.
             * - decoding: unused.
             */
            [FieldOffset(304)] internal readonly IntPtr chroma_intra_matrix; // short* 

            /**
             * precision of the intra DC coefficient - 8
             * - encoding: Set by user.
             * - decoding: Set by libavcodec
             */
            [FieldOffset(312)] internal readonly int intra_dc_precision;

            /**
             * minimum MB Lagrange multiplier
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(316)] internal readonly int mb_lmin;

            /**
             * maximum MB Lagrange multiplier
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(320)] internal readonly int mb_lmax;

            /**
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(324)] internal readonly int bidir_refine;

            /**
             * minimum GOP size
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(328)] internal readonly int keyint_min;

            /**
             * the number of pictures in a group of pictures, or 0 for intra_only
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(332)] internal readonly int gop_size;

            /**
             * Note: Value depends upon the compare function used for fullpel ME.
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(336)] internal readonly int mv0_threshold;

            /**
             * Number of slices.
             * Indicates number of picture subdivisions. Used for parallelized
             * decoding.
             * - encoding: Set by user
             * - decoding: unused
             */
            [FieldOffset(340)] internal readonly int slices;

            /* audio only */
            [FieldOffset(344)] internal readonly int sample_rate; ///< samples per second

            /**
             * audio sample format
             * - encoding: Set by user.
             * - decoding: Set by libavcodec.
             */
            [FieldOffset(348)] internal readonly AVSampleFormat sample_fmt;  ///< sample format

            /**
             * Audio channel layout.
             * - encoding: must be set by the caller, to one of AVCodec.ch_layouts.
             * - decoding: may be set by the caller if known e.g. from the container.
             *             The decoder can then override during decoding as needed.
             */
            [FieldOffset(352)] internal readonly AVChannelLayout ch_layout;

            /**
             * Number of samples per channel in an audio frame.
             *
             * - encoding: set by libavcodec in avcodec_open2(). Each submitted frame
             *   except the last must contain exactly frame_size samples per channel.
             *   May be 0 when the codec has AV_CODEC_CAP_VARIABLE_FRAME_SIZE set, then the
             *   frame size is not restricted.
             * - decoding: may be set by some decoders to indicate constant frame size
             */
            [FieldOffset(376)] internal readonly int frame_size;

            /**
             * number of bytes per packet if constant and known or 0
             * Used by some WAV based audio codecs.
             */
            [FieldOffset(380)] internal readonly int block_align;

            /**
             * Audio cutoff bandwidth (0 means "automatic")
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(384)] internal readonly int cutoff;

            /**
             * Type of service that the audio stream conveys.
             * - encoding: Set by user.
             * - decoding: Set by libavcodec.
             */
            [FieldOffset(388)] internal readonly AVAudioServiceType audio_service_type;

            /**
             * desired sample format
             * - encoding: Not used.
             * - decoding: Set by user.
             * Decoder will decode to this format if it can.
             */
            [FieldOffset(392)] internal readonly AVSampleFormat request_sample_fmt;

            /**
             * Audio only. The number of "priming" samples (padding) inserted by the
             * encoder at the beginning of the audio. I.e. this number of leading
             * decoded samples must be discarded by the caller to get the original audio
             * without leading padding.
             *
             * - decoding: unused
             * - encoding: Set by libavcodec. The timestamps on the output packets are
             *             adjusted by the encoder so that they always refer to the
             *             first sample of the data actually contained in the packet,
             *             including any added padding.  E.g. if the timebase is
             *             1/samplerate and the timestamp of the first input sample is
             *             0, the timestamp of the first output packet will be
             *             -initial_padding.
             */
            [FieldOffset(396)] internal readonly int initial_padding;

            /**
             * Audio only. The amount of padding (in samples) appended by the encoder to
             * the end of the audio. I.e. this number of decoded samples must be
             * discarded by the caller from the end of the stream to get the original
             * audio without any trailing padding.
             *
             * - decoding: unused
             * - encoding: unused
             */
            [FieldOffset(400)] internal readonly int trailing_padding;

            /**
             * Number of samples to skip after a discontinuity
             * - decoding: unused
             * - encoding: set by libavcodec
             */
            [FieldOffset(404)] internal readonly int seek_preroll;

            /**
             * This callback is called at the beginning of each frame to get data
             * buffer(s) for it. There may be one contiguous buffer for all the data or
             * there may be a buffer per each data plane or anything in between. What
             * this means is, you may set however many entries in buf[] you feel necessary.
             * Each buffer must be reference-counted using the AVBuffer API (see description
             * of buf[] below).
             *
             * The following fields will be set in the frame before this callback is
             * called:
             * - format
             * - width, height (video only)
             * - sample_rate, channel_layout, nb_samples (audio only)
             * Their values may differ from the corresponding values in
             * AVCodecContext. This callback must use the frame values, not the codec
             * context values, to calculate the required buffer size.
             *
             * This callback must fill the following fields in the frame:
             * - data[]
             * - linesize[]
             * - extended_data:
             *   * if the data is planar audio with more than 8 channels, then this
             *     callback must allocate and fill extended_data to contain all pointers
             *     to all data planes. data[] must hold as many pointers as it can.
             *     extended_data must be allocated with av_malloc() and will be freed in
             *     av_frame_unref().
             *   * otherwise extended_data must point to data
             * - buf[] must contain one or more pointers to AVBufferRef structures. Each of
             *   the frame's data and extended_data pointers must be contained in these. That
             *   is, one AVBufferRef for each allocated chunk of memory, not necessarily one
             *   AVBufferRef per data[] entry. See: av_buffer_create(), av_buffer_alloc(),
             *   and av_buffer_ref().
             * - extended_buf and nb_extended_buf must be allocated with av_malloc() by
             *   this callback and filled with the extra buffers if there are more
             *   buffers than buf[] can hold. extended_buf will be freed in
             *   av_frame_unref().
             *
             * If AV_CODEC_CAP_DR1 is not set then get_buffer2() must call
             * avcodec_default_get_buffer2() instead of providing buffers allocated by
             * some other means.
             *
             * Each data plane must be aligned to the maximum required by the target
             * CPU.
             *
             * @see avcodec_default_get_buffer2()
             *
             * Video:
             *
             * If AV_GET_BUFFER_FLAG_REF is set in flags then the frame may be reused
             * (read and/or written to if it is writable) later by libavcodec.
             *
             * avcodec_align_dimensions2() should be used to find the required width and
             * height, as they normally need to be rounded up to the next multiple of 16.
             *
             * Some decoders do not support linesizes changing between frames.
             *
             * If frame multithreading is used, this callback may be called from a
             * different thread, but not from more than one at once. Does not need to be
             * reentrant.
             *
             * @see avcodec_align_dimensions2()
             *
             * Audio:
             *
             * Decoders request a buffer of a particular size by setting
             * AVFrame.nb_samples prior to calling get_buffer2(). The decoder may,
             * however, utilize only part of the buffer by setting AVFrame.nb_samples
             * to a smaller value in the output frame.
             *
             * As a convenience, av_samples_get_buffer_size() and
             * av_samples_fill_arrays() in libavutil may be used by custom get_buffer2()
             * functions to find the required data size and to fill data pointers and
             * linesize. In AVFrame.linesize, only linesize[0] may be set for audio
             * since all planes must be the same size.
             *
             * @see av_samples_get_buffer_size(), av_samples_fill_arrays()
             *
             * - encoding: unused
             * - decoding: Set by libavcodec, user can override.
             */
            [FieldOffset(408)] internal readonly getBuffer2 get_buffer2;

            /* - encoding parameters */
            /**
             * number of bits the bitstream is allowed to diverge from the reference.
             *           the reference can be CBR (for CBR pass1) or VBR (for pass2)
             * - encoding: Set by user; unused for constant quantizer encoding.
             * - decoding: unused
             */
            [FieldOffset(416)] internal readonly int bit_rate_tolerance;

            /**
             * Global quality for codecs which cannot change it per frame.
             * This should be proportional to MPEG-1/2/4 qscale.
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(420)] internal readonly int global_quality;

            /**
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(424)] internal readonly int compression_level;


            [FieldOffset(428)] internal readonly float qcompress;  ///< amount of qscale change between easy & hard scenes (0.0-1.0)
            [FieldOffset(432)] internal readonly float qblur;      ///< amount of qscale smoothing over time (0.0-1.0)

            /**
             * minimum quantizer
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(436)] internal readonly int qmin;

            /**
             * maximum quantizer
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(440)] internal readonly int qmax;

            /**
             * maximum quantizer difference between frames
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(444)] internal readonly int max_qdiff;

            /**
             * decoder bitstream buffer size
             * - encoding: Set by user.
             * - decoding: May be set by libavcodec.
             */
            [FieldOffset(448)] internal readonly int rc_buffer_size;

            /**
             * ratecontrol override, see RcOverride
             * - encoding: Allocated/set/freed by user.
             * - decoding: unused
             */
            [FieldOffset(452)] internal readonly int rc_override_count;
            [FieldOffset(456)] internal readonly IntPtr rc_override;



            /**
             * maximum bitrate
             * - encoding: Set by user.
             * - decoding: Set by user, may be overwritten by libavcodec.
             */
            [FieldOffset(464)] internal readonly long rc_max_rate;

            /**
             * minimum bitrate
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(472)] internal readonly long rc_min_rate;

            /**
             * Ratecontrol attempt to use, at maximum, <value> of what can be used without an underflow.
             * - encoding: Set by user.
             * - decoding: unused.
             */
            [FieldOffset(480)] internal readonly float rc_max_available_vbv_use;

            /**
             * Ratecontrol attempt to use, at least, <value> times the amount needed to prevent a vbv overflow.
             * - encoding: Set by user.
             * - decoding: unused.
             */
            [FieldOffset(484)] internal readonly float rc_min_vbv_overflow_use;

            /**
             * Number of bits which should be loaded into the rc buffer before decoding starts.
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(488)] internal readonly int rc_initial_buffer_occupancy;

            /**
             * trellis RD quantization
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(492)] internal readonly int trellis;

            /**
             * pass1 encoding statistics output buffer
             * - encoding: Set by libavcodec.
             * - decoding: unused
             */
            [FieldOffset(496)] internal readonly IntPtr stats_out;

            /**
             * pass2 encoding statistics input buffer
             * Concatenated stuff from stats_out of pass1 should be placed here.
             * - encoding: Allocated/set/freed by user.
             * - decoding: unused
             */
            [FieldOffset(504)] internal readonly IntPtr stats_in;



            /**
             * Work around bugs in encoders which sometimes cannot be detected automatically.
             * - encoding: Set by user
             * - decoding: Set by user
             */
            [FieldOffset(512)] internal readonly int workaround_bugs;


            /**
             * strictly follow the standard (MPEG-4, ...).
             * - encoding: Set by user.
             * - decoding: Set by user.
             * Setting this to STRICT or higher means the encoder and decoder will
             * generally do stupid things, whereas setting it to unofficial or lower
             * will mean the encoder might produce output that is not supported by all
             * spec-compliant decoders. Decoders don't differentiate between normal,
             * unofficial and experimental (that is, they always try to decode things
             * when they can) unless they are explicitly asked to behave stupidly
             * (=strictly conform to the specs)
             * This may only be set to one of the FF_COMPLIANCE_* values in defs.h.
             */
            [FieldOffset(516)] internal readonly int strict_std_compliance;

            /**
             * error concealment flags
             * - encoding: unused
             * - decoding: Set by user.
             */
            [FieldOffset(520)] internal readonly int error_concealment;


            /**
             * debug
             * - encoding: Set by user.
             * - decoding: Set by user.
             */
            [FieldOffset(524)] internal readonly int debug;

            /**
             * Error recognition; may misdetect some more or less valid parts as errors.
             * This is a bitfield of the AV_EF_* values defined in defs.h.
             *
             * - encoding: Set by user.
             * - decoding: Set by user.
             */
            [FieldOffset(528)] internal readonly int err_recognition;

            /**
             * Hardware accelerator in use
             * - encoding: unused.
             * - decoding: Set by libavcodec
             */
            [FieldOffset(536)] internal readonly IntPtr hwaccel;


            /**
             * Legacy hardware accelerator context.
             *
             * For some hardware acceleration methods, the caller may use this field to
             * signal hwaccel-specific data to the codec. The struct pointed to by this
             * pointer is hwaccel-dependent and defined in the respective header. Please
             * refer to the FFmpeg HW accelerator documentation to know how to fill
             * this.
             *
             * In most cases this field is optional - the necessary information may also
             * be provided to libavcodec through @ref hw_frames_ctx or @ref
             * hw_device_ctx (see avcodec_get_hw_config()). However, in some cases it
             * may be the only method of signalling some (optional) information.
             *
             * The struct and its contents are owned by the caller.
             *
             * - encoding: May be set by the caller before avcodec_open2(). Must remain
             *             valid until avcodec_free_context().
             * - decoding: May be set by the caller in the get_format() callback.
             *             Must remain valid until the next get_format() call,
             *             or avcodec_free_context() (whichever comes first).
             */
            [FieldOffset(544)] internal readonly IntPtr hwaccel_context;

            /**
             * A reference to the AVHWFramesContext describing the input (for encoding)
             * or output (decoding) frames. The reference is set by the caller and
             * afterwards owned (and freed) by libavcodec - it should never be read by
             * the caller after being set.
             *
             * - decoding: This field should be set by the caller from the get_format()
             *             callback. The previous reference (if any) will always be
             *             unreffed by libavcodec before the get_format() call.
             *
             *             If the default get_buffer2() is used with a hwaccel pixel
             *             format, then this AVHWFramesContext will be used for
             *             allocating the frame buffers.
             *
             * - encoding: For hardware encoders configured to use a hwaccel pixel
             *             format, this field should be set by the caller to a reference
             *             to the AVHWFramesContext describing input frames.
             *             AVHWFramesContext.format must be equal to
             *             AVCodecContext.pix_fmt.
             *
             *             This field should be set before avcodec_open2() is called.
             */
            [FieldOffset(552)] internal readonly IntPtr hw_frames_ctx;



            /**
             * A reference to the AVHWDeviceContext describing the device which will
             * be used by a hardware encoder/decoder.  The reference is set by the
             * caller and afterwards owned (and freed) by libavcodec.
             *
             * This should be used if either the codec device does not require
             * hardware frames or any that are used are to be allocated internally by
             * libavcodec.  If the user wishes to supply any of the frames used as
             * encoder input or decoder output then hw_frames_ctx should be used
             * instead.  When hw_frames_ctx is set in get_format() for a decoder, this
             * field will be ignored while decoding the associated stream segment, but
             * may again be used on a following one after another get_format() call.
             *
             * For both encoders and decoders this field should be set before
             * avcodec_open2() is called and must not be written to thereafter.
             *
             * Note that some decoders may require this field to be set initially in
             * order to support hw_frames_ctx at all - in that case, all frames
             * contexts used must be created on the same device.
             */
            [FieldOffset(560)] internal readonly IntPtr hw_device_ctx;



            /**
             * Bit set of AV_HWACCEL_FLAG_* flags, which affect hardware accelerated
             * decoding (if active).
             * - encoding: unused
             * - decoding: Set by user (either before avcodec_open2(), or in the
             *             AVCodecContext.get_format callback)
             */
            [FieldOffset(568)] internal readonly int hwaccel_flags;

            /**
             * Video decoding only.  Sets the number of extra hardware frames which
             * the decoder will allocate for use by the caller.  This must be set
             * before avcodec_open2() is called.
             *
             * Some hardware decoders require all frames that they will use for
             * output to be defined in advance before decoding starts.  For such
             * decoders, the hardware frame pool must therefore be of a fixed size.
             * The extra frames set here are on top of any number that the decoder
             * needs internally in order to operate normally (for example, frames
             * used as reference pictures).
             */
            [FieldOffset(572)] internal readonly int extra_hw_frames;

            /**
             * error
             * - encoding: Set by libavcodec if flags & AV_CODEC_FLAG_PSNR.
             * - decoding: unused
             */
            [FieldOffset(576)] internal readonly long[] error;

            /**
             * DCT algorithm, see FF_DCT_* below
             * - encoding: Set by user.
             * - decoding: unused
             */
            [FieldOffset(640)] internal readonly int dct_algo;


            /**
             * IDCT algorithm, see FF_IDCT_* below.
             * - encoding: Set by user.
             * - decoding: Set by user.
             */
            [FieldOffset(644)] internal readonly int idct_algo;


            /**
             * bits per sample/pixel from the demuxer (needed for huffyuv).
             * - encoding: Set by libavcodec.
             * - decoding: Set by user.
             */
            [FieldOffset(648)] internal readonly int bits_per_coded_sample;

            /**
             * Bits per sample/pixel of internal libavcodec pixel/sample format.
             * - encoding: set by user.
             * - decoding: set by libavcodec.
             */
            [FieldOffset(652)] internal readonly int bits_per_raw_sample;

            /**
             * thread count
             * is used to decide how many independent tasks should be passed to execute()
             * - encoding: Set by user.
             * - decoding: Set by user.
             */
            [FieldOffset(656)] internal readonly int thread_count;

            /**
             * Which multithreading methods to use.
             * Use of FF_THREAD_FRAME will increase decoding delay by one frame per thread,
             * so clients which cannot provide future frames should not use it.
             *
             * - encoding: Set by user, otherwise the default is used.
             * - decoding: Set by user, otherwise the default is used.
             */
            [FieldOffset(660)] internal readonly int thread_type;


            /**
             * Which multithreading methods are in use by the codec.
             * - encoding: Set by libavcodec.
             * - decoding: Set by libavcodec.
             */
            [FieldOffset(664)] internal readonly int active_thread_type;

            /**
             * The codec may call this to execute several independent things.
             * It will return only after finishing all tasks.
             * The user may replace this with some multithreaded implementation,
             * the default implementation will execute the parts serially.
             * @param count the number of things to execute
             * - encoding: Set by libavcodec, user can override.
             * - decoding: Set by libavcodec, user can override.
             */
            [FieldOffset(672)] internal readonly executeCodec execute;

            /**
             * The codec may call this to execute several independent things.
             * It will return only after finishing all tasks.
             * The user may replace this with some multithreaded implementation,
             * the default implementation will execute the parts serially.
             * @param c context passed also to func
             * @param count the number of things to execute
             * @param arg2 argument passed unchanged to func
             * @param ret return values of executed functions, must have space for "count" values. May be NULL.
             * @param func function that will be called count times, with jobnr from 0 to count-1.
             *             threadnr will be in the range 0 to c->thread_count-1 < MAX_THREADS and so that no
             *             two instances of func executing at the same time will have the same threadnr.
             * @return always 0 currently, but code should handle a future improvement where when any call to func
             *         returns < 0 no further calls to func may be done and < 0 is returned.
             * - encoding: Set by libavcodec, user can override.
             * - decoding: Set by libavcodec, user can override.
             */
            [FieldOffset(680)] internal readonly executeCodec2 execute2;

            /**
             * profile
             * - encoding: Set by user.
             * - decoding: Set by libavcodec.
             * See the AV_PROFILE_* defines in defs.h.
             */
            [FieldOffset(688)] internal readonly int profile;

            /**
             * Encoding level descriptor.
             * - encoding: Set by user, corresponds to a specific level defined by the
             *   codec, usually corresponding to the profile level, if not specified it
             *   is set to FF_LEVEL_UNKNOWN.
             * - decoding: Set by libavcodec.
             * See AV_LEVEL_* in defs.h.
             */
            [FieldOffset(692)] internal readonly int level;



            /**
             * Properties of the stream that gets decoded
             * - encoding: unused
             * - decoding: set by libavcodec
             */
            [FieldOffset(696)] internal readonly uint properties;

            /**
             * Skip loop filtering for selected frames.
             * - encoding: unused
             * - decoding: Set by user.
             */
            [FieldOffset(700)] internal readonly AVDiscard skip_loop_filter;

            /**
             * Skip IDCT/dequantization for selected frames.
             * - encoding: unused
             * - decoding: Set by user.
             */
            [FieldOffset(704)] internal readonly AVDiscard skip_idct;

            /**
             * Skip decoding for selected frames.
             * - encoding: unused
             * - decoding: Set by user.
             */
            [FieldOffset(708)] internal readonly AVDiscard skip_frame;

            /**
             * Skip processing alpha if supported by codec.
             * Note that if the format uses pre-multiplied alpha (common with VP6,
             * and recommended due to better video quality/compression)
             * the image will look as if alpha-blended onto a black background.
             * However for formats that do not use pre-multiplied alpha
             * there might be serious artefacts (though e.g. libswscale currently
             * assumes pre-multiplied alpha anyway).
             *
             * - decoding: set by user
             * - encoding: unused
             */
            [FieldOffset(712)] internal readonly int skip_alpha;

            /**
             * Number of macroblock rows at the top which are skipped.
             * - encoding: unused
             * - decoding: Set by user.
             */
            [FieldOffset(716)] internal readonly int skip_top;

            /**
             * Number of macroblock rows at the bottom which are skipped.
             * - encoding: unused
             * - decoding: Set by user.
             */
            [FieldOffset(720)] internal readonly int skip_bottom;

            /**
             * low resolution decoding, 1-> 1/2 size, 2->1/4 size
             * - encoding: unused
             * - decoding: Set by user.
             */
            [FieldOffset(724)] internal readonly int lowres;

            /**
             * AVCodecDescriptor
             * - encoding: unused.
             * - decoding: set by libavcodec.
             */
            [FieldOffset(728)] internal readonly IntPtr codec_descriptor;


            /**
             * Character encoding of the input subtitles file.
             * - decoding: set by user
             * - encoding: unused
             */
            [FieldOffset(736)] internal readonly IntPtr sub_charenc;


            /**
             * Subtitles character encoding mode. Formats or codecs might be adjusting
             * this setting (if they are doing the conversion themselves for instance).
             * - decoding: set by libavcodec
             * - encoding: unused
             */
            [FieldOffset(744)] internal readonly int sub_charenc_mode;


            /**
             * Header containing style information for text subtitles.
             * For SUBTITLE_ASS subtitle type, it should contain the whole ASS
             * [Script Info] and [V4+ Styles] section, plus the [Events] line and
             * the Format line following. It shouldn't include any Dialogue line.
             * - encoding: Set/allocated/freed by user (before avcodec_open2())
             * - decoding: Set/allocated/freed by libavcodec (by avcodec_open2())
             */
            [FieldOffset(748)] internal readonly int subtitle_header_size;
            // byte*
            [FieldOffset(752)] internal readonly IntPtr subtitle_header;

            /**
             * dump format separator.
             * can be ", " or "\n      " or anything else
             * - encoding: Set by user.
             * - decoding: Set by user.
             */
            // byte*
            [FieldOffset(760)] internal readonly IntPtr dump_separator;

            /**
             * ',' separated list of allowed decoders.
             * If NULL then all are allowed
             * - encoding: unused
             * - decoding: set by user
             */
            [FieldOffset(768)] internal readonly IntPtr codec_whitelist;


            /**
             * Additional data associated with the entire coded stream.
             *
             * - decoding: may be set by user before calling avcodec_open2().
             * - encoding: may be set by libavcodec after avcodec_open2().
             */
            //AVPacketSideData*
            [FieldOffset(776)] internal readonly IntPtr coded_side_data;



            [FieldOffset(784)] internal readonly int nb_coded_side_data;

            /**
             * Bit set of AV_CODEC_EXPORT_DATA_* flags, which affects the kind of
             * metadata exported in frame, packet, or coded stream side data by
             * decoders and encoders.
             *
             * - decoding: set by user
             * - encoding: set by user
             */
            [FieldOffset(788)] internal readonly int export_side_data;

            /**
             * The number of pixels per image to maximally accept.
             *
             * - decoding: set by user
             * - encoding: set by user
             */
            [FieldOffset(792)] internal readonly long max_pixels;

            /**
             * Video decoding only. Certain video codecs support cropping, meaning that
             * only a sub-rectangle of the decoded frame is intended for display.  This
             * option controls how cropping is handled by libavcodec.
             *
             * When set to 1 (the default), libavcodec will apply cropping internally.
             * I.e. it will modify the output frame width/height fields and offset the
             * data pointers (only by as much as possible while preserving alignment, or
             * by the full amount if the AV_CODEC_FLAG_UNALIGNED flag is set) so that
             * the frames output by the decoder refer only to the cropped area. The
             * crop_* fields of the output frames will be zero.
             *
             * When set to 0, the width/height fields of the output frames will be set
             * to the coded dimensions and the crop_* fields will describe the cropping
             * rectangle. Applying the cropping is left to the caller.
             *
             * @warning When hardware acceleration with opaque output frames is used,
             * libavcodec is unable to apply cropping from the top/left border.
             *
             * @note when this option is set to zero, the width/height fields of the
             * AVCodecContext and output AVFrames have different meanings. The codec
             * context fields store display dimensions (with the coded dimensions in
             * coded_width/height), while the frame fields store the coded dimensions
             * (with the display dimensions being determined by the crop_* fields).
             */
            [FieldOffset(800)] internal readonly int apply_cropping;

            /**
             * The percentage of damaged samples to discard a frame.
             *
             * - decoding: set by user
             * - encoding: unused
             */
            [FieldOffset(804)] internal readonly int discard_damaged_percentage;

            /**
             * The number of samples per frame to maximally accept.
             *
             * - decoding: set by user
             * - encoding: set by user
             */
            [FieldOffset(808)] internal readonly long max_samples;

            /**
             * This callback is called at the beginning of each packet to get a data
             * buffer for it.
             *
             * The following field will be set in the packet before this callback is
             * called:
             * - size
             * This callback must use the above value to calculate the required buffer size,
             * which must padded by at least AV_INPUT_BUFFER_PADDING_SIZE bytes.
             *
             * In some specific cases, the encoder may not use the entire buffer allocated by this
             * callback. This will be reflected in the size value in the packet once returned by
             * avcodec_receive_packet().
             *
             * This callback must fill the following fields in the packet:
             * - data: alignment requirements for AVPacket apply, if any. Some architectures and
             *   encoders may benefit from having aligned data.
             * - buf: must contain a pointer to an AVBufferRef structure. The packet's
             *   data pointer must be contained in it. See: av_buffer_create(), av_buffer_alloc(),
             *   and av_buffer_ref().
             *
             * If AV_CODEC_CAP_DR1 is not set then get_encode_buffer() must call
             * avcodec_default_get_encode_buffer() instead of providing a buffer allocated by
             * some other means.
             *
             * The flags field may contain a combination of AV_GET_ENCODE_BUFFER_FLAG_ flags.
             * They may be used for example to hint what use the buffer may get after being
             * created.
             * Implementations of this callback may ignore flags they don't understand.
             * If AV_GET_ENCODE_BUFFER_FLAG_REF is set in flags then the packet may be reused
             * (read and/or written to if it is writable) later by libavcodec.
             *
             * This callback must be thread-safe, as when frame threading is used, it may
             * be called from multiple threads simultaneously.
             *
             * @see avcodec_default_get_encode_buffer()
             *
             * - encoding: Set by libavcodec, user can override.
             * - decoding: unused
             */
            [FieldOffset(816)] internal readonly get_encode_buffer get_encode_buffer;

            /**
             * Frame counter, set by libavcodec.
             *
             * - decoding: total number of frames returned from the decoder so far.
             * - encoding: total number of frames passed to the encoder so far.
             *
             *   @note the counter is not incremented if encoding/decoding resulted in
             *   an error.
             */
            [FieldOffset(824)] internal readonly long frame_num;

            /**
             * Decoding only. May be set by the caller before avcodec_open2() to an
             * av_malloc()'ed array (or via AVOptions). Owned and freed by the decoder
             * afterwards.
             *
             * Side data attached to decoded frames may come from several sources:
             * 1. coded_side_data, which the decoder will for certain types translate
             *    from packet-type to frame-type and attach to frames;
             * 2. side data attached to an AVPacket sent for decoding (same
             *    considerations as above);
             * 3. extracted from the coded bytestream.
             * The first two cases are supplied by the caller and typically come from a
             * container.
             *
             * This array configures decoder behaviour in cases when side data of the
             * same type is present both in the coded bytestream and in the
             * user-supplied side data (items 1. and 2. above). In all cases, at most
             * one instance of each side data type will be attached to output frames. By
             * default it will be the bytestream side data. Adding an
             * AVPacketSideDataType value to this array will flip the preference for
             * this type, thus making the decoder prefer user-supplied side data over
             * bytestream. In case side data of the same type is present both in
             * coded_data and attacked to a packet, the packet instance always has
             * priority.
             *
             * The array may also contain a single -1, in which case the preference is
             * switched for all side data types.
             */
            ///int* 
            [FieldOffset(832)] internal readonly IntPtr side_data_prefer_packet;
            /**
             * Number of entries in side_data_prefer_packet.
             */
            [FieldOffset(840)] internal readonly uint nb_side_data_prefer_packet;

            /**
             * Array containing static side data, such as HDR10 CLL / MDCV structures.
             * Side data entries should be allocated by usage of helpers defined in
             * libavutil/frame.h.
             *
             * - encoding: may be set by user before calling avcodec_open2() for
             *             encoder configuration. Afterwards owned and freed by the
             *             encoder.
             * - decoding: unused
             */

            ///AVFrameSideData**
            [FieldOffset(848)] internal readonly IntPtr decoded_side_data;
            [FieldOffset(856)] internal readonly int nb_decoded_side_data;
        }
    }
}