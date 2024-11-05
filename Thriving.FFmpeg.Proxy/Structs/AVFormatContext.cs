using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVFormatContext : ProxyOptionObject
    {
        internal AVFormatContext(IntPtr handle) : base(handle) { }

        public AVFormatContext()
        {
            _handle = Core.avformat_alloc_context();
        }

        ~AVFormatContext()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.avformat_free_context(_handle);
            }
        }

        public static AVFormatContext OpenInput(AVInputFormat? inputFormat, string filePath, AVDictionary? dict=null)
        {
            var handle = IntPtr.Zero;
            var dictPtr = dict == null ? IntPtr.Zero : dict._handle;
            var ret = Core.avformat_open_input(ref handle, filePath, inputFormat == null ? IntPtr.Zero : inputFormat._handle, ref dictPtr);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
            return new AVFormatContext(handle);
        }

        public static AVFormatContext OpenOutput(AVOutputFormat? outputFormat, string format_name, string filename)
        {
            var handle = IntPtr.Zero;
            var res = Core.avformat_alloc_output_context2(ref handle, outputFormat == null ? IntPtr.Zero : outputFormat._handle, format_name, filename);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return new AVFormatContext(handle);
        }

        public AVRational GuessFrameRate(AVStream stream, AVFrame frame)
        {
            return Core.av_guess_frame_rate(Handle, stream._handle, frame._handle);
        }

        public void CloseInput()
        {
            Core.avformat_close_input(ref _handle);
        }

        /// <summary>
        /// 读取原始帧数据(AVPacket)
        /// <code>For video, the packet contains exactly one frame</code>
        /// <code>For audio, if each frame has a known fixed size(e.g. PCM or ADPCM data), it contains an integer number of frames;
        ///                  if frames have a variable size (e.g. MPEG audio), then it contains one frame
        /// </code>
        /// <code>pkt->pts, pkt->dts and pkt->duration are always set to correct values in AVStream.time_base units (and guessed if the format cannot provide them)</code>
        /// <code>pkt->pts can be AV_NOPTS_VALUE if the video format has B-frames, so it is better to rely on pkt->dts if you do not decompress the payload</code>
        /// </summary>
        /// <param name="pkt"></param>
        /// <returns></returns>
        public bool ReadFrame(AVPacket pkt)
        {
            // 0 if OK, < 0 on error or end of file. On error, pkt will be blank
            var ret = Core.av_read_frame(_handle, pkt._handle);
            // if (ret < 0) throw FFmpegException.FromErrorCode(ret);
            return ret == 0;
        }

        /// <summary>
        /// Allocate the stream private data and write the stream header to an output media file
        /// <code>"OutputFormat" field must be set to the desired output format</code>
        /// <code>"IOContext" field must be set to an already opened AVIOContext</code>
        /// </summary>
        /// <param name="dict"></param>
        public void WriteHeader(AVDictionary? dict = null)
        {
            var dictPtr = dict == null ? IntPtr.Zero : dict._handle;
            // 返回0 表示 在write_header函数内初始化 output
            // 返回1 表示 在init_output 函数初始化output
            var ret = Core.avformat_write_header(_handle, ref dictPtr);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void WriteFrame(AVPacket pkt)
        {
            var ret = Core.av_write_frame(_handle, pkt._handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }


        public void WriteFrameInterleaved(AVPacket pkt)
        {
            var ret = Core.av_interleaved_write_frame(_handle, pkt._handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void WriteTrailer()
        {
            var ret = Core.av_write_trailer(_handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void WriteUncodedFrame(int stream_index, AVFrame frame)
        {
            var ret = Core.av_write_uncoded_frame(_handle, stream_index, frame._handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void WriteUncodedFrameInterleaved(int stream_index, AVFrame frame)
        {
            var ret = Core.av_interleaved_write_uncoded_frame(_handle, stream_index, frame._handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void WriteUncodedFrameQuery(int stream_index)
        {
            var ret = Core.av_write_uncoded_frame_query(_handle, stream_index);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void SeekFrame(int stream_index, DateTime timestamp, int flags)
        {
            var ret = Core.av_seek_frame(_handle, stream_index, timestamp, flags);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }


        public void Flush()
        {
            int ret = Core.avformat_flush(_handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void InitOutput(AVDictionary? dict = null)
        {
            var dictPtr = dict == null ? IntPtr.Zero : dict._handle;
            var ret = Core.avformat_init_output(_handle, ref dictPtr);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public AVStreamGroup CreateStreamGroup(AVStreamGroupParamsType type, AVDictionary? options = null)
        {
            var dictPtr = options == null ? IntPtr.Zero : options._handle;
            var group = Core.avformat_stream_group_create(_handle, type, ref dictPtr);
            return new AVStreamGroup(group);
        }

        public AVStream AddStream(AVCodec codec)
        {
            var ptr = Core.avformat_new_stream(_handle, codec._handle);
            return new AVStream(ptr);
        }

        public int GetDefaultStream()
        {
            var res = Core.av_find_default_stream_index(_handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return res;
        }

        public int FindStream(AVDictionary? options = null)
        {
            var dictPtr = options == null ? IntPtr.Zero : options._handle;
            var res = Core.avformat_find_stream_info(_handle, ref dictPtr);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return res;
        }

        public int FindBestStream(AVMediaType type, int wanted_stream_nb, int related_stream, AVCodec decoder_ret)
        {
            var res = Core.av_find_best_stream(_handle, type, wanted_stream_nb, related_stream, ref decoder_ret._handle, 0);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return res;
        }

        public AVProgram CreateProgram(int id)
        {
            var ptr = Core.av_new_program(_handle, id);
            return new AVProgram(ptr);
        }

        public void MatchStreamSpecifier(AVStream stream,string spec)
        {
            var ret = Core.avformat_match_stream_specifier(_handle, stream._handle, spec);
            if(ret < 0)throw FFmpegException.FromErrorCode(ret);
        }

        public void QueueAttachedPictures()
        {
            var ret = Core.avformat_queue_attached_pictures(_handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void SeekFile(int stream_index, DateTime min_ts, DateTime ts, DateTime max_ts, int flags)
        {
            var ret = Core.avformat_seek_file(_handle, stream_index, min_ts, ts, max_ts, flags);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }


        public string Url
        {
            get
            {
                var url = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.url)).ToInt32());
                return Marshal.PtrToStringAnsi(url);
            }
        }

        public uint PacketSize
        {
            get => (uint)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.packet_size)).ToInt32());
        }

        public AVClass Class
        {
            get
            {
                var av_class = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.av_class)).ToInt32());
                return new AVClass(av_class);
            }
        }

        public AVInputFormat? InputFormat
        {
            get
            {
                var iformat = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.iformat)).ToInt32());
                return iformat == IntPtr.Zero ? null : new AVInputFormat(iformat);
            }
        }

        public AVOutputFormat? OutputFormat
        {
            get
            {
                var oformat = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.oformat)).ToInt32());
                return oformat == IntPtr.Zero ? null : new AVOutputFormat(oformat);
            }
        }

        public AVIOContext IOContext
        {
            get
            {
                var pb = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pb)).ToInt32());
                return new AVIOContext(pb);
            }
            set
            {
                Marshal.WriteIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pb)).ToInt32(), value._handle);
            }
        }

        public AVStream[] Streams
        {
            get
            {
                var nb_streams = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_streams)).ToInt32());
                var streams = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.streams)).ToInt32());

                AVStream[] data = new AVStream[nb_streams];
                for (int i = 0; i < nb_streams; i++)
                {
                    var ptr = Marshal.ReadIntPtr(streams, i * Marshal.SizeOf<IntPtr>());
                    data[i] = new AVStream(ptr);
                }
                return data;
            }
        }

        public AVProgram[] Programs
        {
            get
            {
                var nb_programs = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_programs)).ToInt32());
                var programs = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.programs)).ToInt32());
                var result = new AVProgram[nb_programs];
                for (int i = 0; i < nb_programs; i++)
                {
                    var ptr = Marshal.ReadIntPtr(programs, i * Marshal.SizeOf<IntPtr>());
                    result[i] = new AVProgram(ptr);
                }
                return result;
            }
        }

        public byte[] Keys
        {
            get
            {
                var keylen = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.keylen)).ToInt32());
                var key = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.key)).ToInt32());
                var data = new byte[keylen];
                for (int i = 0; i < keylen; i++)
                {
                    data[i] = Marshal.ReadByte(key, i);
                }
                return data;
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                var start_time = Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.start_time)).ToInt32());
                return DateTime.FromBinary(start_time);
            }
        }
        /// <summary>
        /// 持续时间
        /// </summary>
        public DateTime Duration
        {
            get
            {
                var duration = Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.duration)).ToInt32());
                return DateTime.FromBinary(duration);
            }
        }



        public string FormatWhitelist
        {
            get
            {
                var format_whitelist = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.format_whitelist)).ToInt32());
                return Marshal.PtrToStringAnsi(format_whitelist);
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

        public string ProtocolWhitelist
        {
            get
            {
                var protocol_whitelist = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.protocol_whitelist)).ToInt32());
                return Marshal.PtrToStringAnsi(protocol_whitelist);
            }
        }

        public string ProtocolBlacklist
        {
            get
            {
                var protocol_blacklist = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.protocol_blacklist)).ToInt32());
                return Marshal.PtrToStringAnsi(protocol_blacklist);
            }
        }

        public AVChapter[] Chapters
        {
            get
            {
                var nb_chapters = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_chapters)).ToInt32());
                var chapters = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.chapters)).ToInt32());
                var result = new AVChapter[nb_chapters];
                for (int i = 0; i < nb_chapters; i++)
                {
                    var ptr = Marshal.ReadIntPtr(chapters + i * Marshal.SizeOf<IntPtr>());
                    result[i] = new AVChapter(ptr);
                }
                return result;
            }
        }

        public AVCodec? VideoCodec
        {
            get
            {
                var video_codec = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.video_codec)).ToInt32());
                return video_codec == IntPtr.Zero ? null : new AVCodec(video_codec);
            }
        }

        public AVCodec? AudioCodec
        {
            get
            {
                var audio_codec = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.audio_codec)).ToInt32());
                return audio_codec == IntPtr.Zero ? null : new AVCodec(audio_codec);
            }
        }

        public AVCodec? SubtitleCodec
        {
            get
            {
                var subtitle_codec = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.subtitle_codec)).ToInt32());
                return subtitle_codec == IntPtr.Zero ? null : new AVCodec(subtitle_codec);
            }
        }

        public AVCodec? DataCodec
        {
            get
            {
                var data_codec = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.data_codec)).ToInt32());
                return data_codec == IntPtr.Zero ? null : new AVCodec(data_codec);
            }
        }

        public AVDictionary Metadata
        {
            get
            {
                var metadata = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.metadata)).ToInt32());
                return new AVDictionary(metadata);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFormatContext">AVFormatContext*</param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="data_size"></param>
        /// <returns></returns>
        public delegate int av_format_control_message(IntPtr AVFormatContext, int type, IntPtr data, int data_size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AVFormatContext">AVFormatContext*</param>
        /// <param name="AVIOContext">AVIOContext**</param>
        /// <param name="url"></param>
        /// <param name="flags"></param>
        /// <param name="AVDictionary">AVDictionary**</param>
        /// <returns></returns>
        public delegate int av_format_io_open(IntPtr AVFormatContext, IntPtr AVIOContext, [MarshalAs(UnmanagedType.LPStr)] string url, AVIOFlags flags, IntPtr AVDictionary);

        public delegate int av_format_io_close2(IntPtr AVFormatContext, IntPtr AVIOContext);

        [StructLayout(LayoutKind.Explicit, Size = 464)]
        internal struct Internal
        {
            /// <summary>
            /// AVClass
            /// </summary>
            [FieldOffset(0)]
            internal readonly IntPtr av_class;

            /// <summary>
            /// AVInputFormat
            /// </summary>
            [FieldOffset(8)]
            internal readonly IntPtr iformat;


            /// <summary>
            /// AVOutputFormat
            /// </summary>
            [FieldOffset(16)]
            internal readonly IntPtr oformat;



            [FieldOffset(24)]
            internal readonly IntPtr priv_data;
            /// <summary>
            /// AVIOContext
            /// </summary>
            [FieldOffset(32)]
            internal readonly IntPtr pb;



            [FieldOffset(40)]
            internal readonly AVFormatContextFlags ctx_flags;

            [FieldOffset(44)]
            internal readonly uint nb_streams;

            /// <summary>
            /// AVStream**
            /// </summary>
            [FieldOffset(48)]
            internal readonly IntPtr streams;




            [FieldOffset(52)]
            internal readonly uint nb_stream_groups;

            /// <summary>
            /// AVStreamGroup**
            /// </summary>
            [FieldOffset(64)]
            internal readonly IntPtr stream_groups;


            [FieldOffset(72)]
            internal readonly uint nb_chapters;

            /// <summary>
            /// AVChapter**
            /// </summary>
            [FieldOffset(80)]
            internal readonly IntPtr chapters;




            [FieldOffset(88)]
            internal readonly IntPtr url;


            [FieldOffset(96)]
            internal readonly long start_time;

            [FieldOffset(104)]
            internal readonly long duration;

            [FieldOffset(112)]
            internal readonly long bit_rate;

            [FieldOffset(120)]
            internal readonly uint packet_size;

            [FieldOffset(120)]
            internal readonly int max_delay;

            [FieldOffset(128)]
            internal readonly AVFormatFlags flags;

            [FieldOffset(136)]
            internal readonly long probesize;

            [FieldOffset(144)]
            internal readonly long max_analyze_duration;

            /// <summary>
            /// byte
            /// </summary>
            [FieldOffset(152)]
            internal readonly IntPtr key;

            [FieldOffset(160)]
            internal readonly int keylen;

            [FieldOffset(164)]
            internal readonly uint nb_programs;
            /// <summary>
            /// AVProgram**
            /// </summary>
            [FieldOffset(168)]
            internal readonly IntPtr programs;

            [FieldOffset(176)]
            internal readonly AVCodecID video_codec_id;

            [FieldOffset(180)]
            internal readonly AVCodecID audio_codec_id;

            [FieldOffset(184)]
            internal readonly AVCodecID subtitle_codec_id;

            [FieldOffset(188)]
            internal readonly AVCodecID data_codec_id;

            /// <summary>
            /// AVDictionary
            /// </summary>
            [FieldOffset(192)]
            internal readonly IntPtr metadata;

            [FieldOffset(200)]
            internal readonly long start_time_realtime;

            [FieldOffset(208)]
            internal readonly int fps_probe_size;

            [FieldOffset(212)]
            internal readonly int error_recognition;

            [FieldOffset(216)]
            internal readonly IntPtr interrupt_callback;

            [FieldOffset(232)]
            internal readonly int debug;

            [FieldOffset(236)]
            internal readonly int max_streams;

            [FieldOffset(240)]
            internal readonly uint max_index_size;
            [FieldOffset(244)]
            internal readonly uint max_picture_buffer;

            [FieldOffset(248)]
            internal readonly long max_interleave_delta;


            [FieldOffset(256)]
            internal readonly int max_ts_probe;

            [FieldOffset(260)]
            internal readonly int max_chunk_duration;

            [FieldOffset(264)]
            internal readonly int max_chunk_size;

            [FieldOffset(268)]
            internal readonly int max_probe_packets;

            [FieldOffset(272)]
            internal readonly int strict_std_compliance;

            [FieldOffset(276)]
            internal readonly int event_flags;

            [FieldOffset(280)]
            internal readonly int avoid_negative_ts;

            [FieldOffset(284)]
            internal readonly int audio_preload;

            [FieldOffset(288)]
            internal readonly int use_wallclock_as_timestamps;

            [FieldOffset(292)]
            internal readonly int skip_estimate_duration_from_pts;

            /**
             * avio flags, used to force AVIO_FLAG_DIRECT.
             * - encoding: unused
             * - decoding: Set by user
             */
            [FieldOffset(296)]
            internal readonly AVIOFlags avio_flags;

            [FieldOffset(300)]
            internal readonly AVDurationEstimationMethod duration_estimation_method;

            [FieldOffset(304)]
            internal readonly long skip_initial_bytes;

            [FieldOffset(312)]
            internal readonly uint corret_ts_overflow;

            [FieldOffset(316)]
            internal readonly int seek2any;

            [FieldOffset(320)]
            internal readonly int flush_packets;

            [FieldOffset(324)]
            internal readonly int probe_score;

            [FieldOffset(328)]
            internal readonly int format_probesize;

            /// <summary>
            /// char*
            /// </summary>
            [FieldOffset(336)]
            internal readonly IntPtr codec_whitelist;

            /// <summary>
            /// char*
            /// </summary>
            [FieldOffset(344)]
            internal readonly IntPtr format_whitelist;

            /// <summary>
            /// char*
            /// </summary>
            [FieldOffset(352)]
            internal readonly IntPtr protocol_whitelist;

            /// <summary>
            /// char*
            /// </summary>
            [FieldOffset(360)]
            internal readonly IntPtr protocol_blacklist;

            [FieldOffset(368)]
            internal readonly int io_repositioned;

            /// <summary>
            /// AVCodec
            /// </summary>
            [FieldOffset(376)]
            internal readonly IntPtr video_codec;

            /// <summary>
            /// AVCodec
            /// </summary>
            [FieldOffset(384)]
            internal readonly IntPtr audio_codec;

            /// <summary>
            /// AVCodec
            /// </summary>
            [FieldOffset(392)]
            internal readonly IntPtr subtitle_codec;

            /// <summary>
            /// AVCodec
            /// </summary>
            [FieldOffset(400)]
            internal readonly IntPtr data_codec;

            [FieldOffset(408)]
            internal readonly int metadata_header_padding;

            [FieldOffset(416)]
            internal readonly IntPtr opaque;

            [FieldOffset(424)]
            internal readonly av_format_control_message control_message_cb;

            [FieldOffset(432)]
            internal readonly long output_ts_offset;

            [FieldOffset(440)]
            internal readonly IntPtr dump_separator;

            [FieldOffset(448)]
            internal readonly av_format_io_open io_open;

            [FieldOffset(456)]
            internal readonly av_format_io_close2 io_close2;
        }
    }
}