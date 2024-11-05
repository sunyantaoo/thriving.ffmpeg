using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVStream : ProxyObject
    {
        internal AVStream(IntPtr handle) : base(handle) { }

        public AVIndexEntry GetEntryByIndex(int index)
        {
            var ptr = Core.avformat_index_get_entry(_handle, index);
            return new AVIndexEntry(ptr);
        }

        public AVIndexEntry GetEntryByTimestamp(long timestamp, int flags) 
        {
            var ptr = Core.avformat_index_get_entry_from_timestamp(_handle, timestamp, flags);
            return new AVIndexEntry(ptr);
        }

        public int EntriesCount()
        {
            return Core.avformat_index_get_entries_count(_handle);
        }

        public void AddEntry(long pos, long timestamp, int size, int distance, int flags)
        {
            var res = Core.av_add_index_entry(_handle, pos, timestamp, size, distance, flags);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }


        public AVClass Class
        {
            get
            {
                var av_class = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.av_class)).ToInt32());
                return new AVClass(av_class);
            }
        }

        public int Id
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.id)).ToInt32());
        }

        public int Index
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.index)).ToInt32());
        }

        public AVCodecParameters Codecpar
        {
            get
            {
                var codecpar = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codecpar)).ToInt32());
                return new AVCodecParameters(codecpar);
            }
            set
            {
                 Marshal.WriteIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.codecpar)).ToInt32(),value._handle);
            }
        }

        /// <summary>
        /// 单位为秒
        /// </summary>
        public AVRational TimeBase
        {
            get
            {
                var ptr = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.time_base)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(ptr);
            }
            set
            {
                var ptr = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.time_base)).ToInt32();
                Marshal.StructureToPtr<AVRational>(value, ptr, false);
            }
        }

        public AVPacket AttachedPic
        {
            get
            {
                var ptr = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.attached_pic)).ToInt32();
                return new AVPacket(ptr);
            }
        }

        /// <summary>
        /// 帧数
        /// </summary>
        public long NbFrames
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_frames)).ToInt32());
        }

        public long StartTime
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.start_time)).ToInt32());
        }

        public long Duration
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.duration)).ToInt32());
        }

        public AVRational SampleAspectRatio
        {
            get
            {
                var sample_aspect_ratio = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.sample_aspect_ratio)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(sample_aspect_ratio);
            }
        }

        /// <summary>
        /// 平均帧率
        /// </summary>
        public AVRational AverageFrameRate
        {
            get
            {
                var avg_frame_rate = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.avg_frame_rate)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(avg_frame_rate);
            }
        }

        public AVPacketSideData[] SideData
        {
            get
            {
                var nb_side_data = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_side_data)).ToInt32());
                var side_data = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.side_data)).ToInt32());

                var result = new AVPacketSideData[nb_side_data];
                for (var i = 0; i < nb_side_data; i++)
                {
                    result[i] = Marshal.PtrToStructure<AVPacketSideData>(side_data + i * Marshal.SizeOf<AVPacketSideData.Internal>());
                }
                return result;
            }
        }

        public AVRational RealFrameRate
        {
            get
            {
                var r_frame_rate = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.r_frame_rate)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(r_frame_rate);
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

        [StructLayout(LayoutKind.Explicit, Size = 232)]
        internal struct Internal
        {
            /**
             * A class for @ref avoptions. Set on stream creation.
             */
            [FieldOffset(0)]
            internal IntPtr av_class;

            [FieldOffset(8)]
            internal int index;    /**< stream index in AVFormatContext */

            /**
             * Format-specific stream ID.
             * decoding: set by libavformat
             * encoding: set by the user, replaced by libavformat if left unset
             */
            [FieldOffset(12)]
            internal int id;

            /**
             * Codec parameters associated with this stream. Allocated and freed by
             * libavformat in avformat_new_stream() and avformat_free_context()
             * respectively.
             *
             * - demuxing: filled by libavformat on stream creation or in
             *             avformat_find_stream_info()
             * - muxing: filled by the caller before avformat_write_header()
             */
            [FieldOffset(16)]
            internal IntPtr codecpar;


            [FieldOffset(24)]
            internal IntPtr priv_data;

            /**
             * This is the fundamental unit of time (in seconds) in terms
             * of which frame timestamps are represented.
             *
             * decoding: set by libavformat
             * encoding: May be set by the caller before avformat_write_header() to
             *           provide a hint to the muxer about the desired timebase. In
             *           avformat_write_header(), the muxer will overwrite this field
             *           with the timebase that will actually be used for the timestamps
             *           written into the file (which may or may not be related to the
             *           user-provided one, depending on the format).
             */
            [FieldOffset(32)]
            internal AVRational time_base;

            /**
             * Decoding: pts of the first frame of the stream in presentation order, in stream time base.
             * Only set this if you are absolutely 100% sure that the value you set
             * it to really is the pts of the first frame.
             * This may be undefined (AV_NOPTS_VALUE).
             * @note The ASF header does NOT contain a correct start_time the ASF
             * demuxer must NOT set this.
             */
            [FieldOffset(40)]
            internal long start_time;

            /**
             * Decoding: duration of the stream, in stream time base.
             * If a source file does not specify a duration, but does specify
             * a bitrate, this value will be estimated from bitrate and file size.
             *
             * Encoding: May be set by the caller before avformat_write_header() to
             * provide a hint to the muxer about the estimated duration.
             */
            [FieldOffset(48)]
            internal long duration;

            [FieldOffset(56)]
            internal long nb_frames;

            /**
             * Stream disposition - a combination of AV_DISPOSITION_* flags.
             * - demuxing: set by libavformat when creating the stream or in
             *             avformat_find_stream_info().
             * - muxing: may be set by the caller before avformat_write_header().
             */
            [FieldOffset(64)]
            internal int disposition;

            [FieldOffset(68)]
            internal AVDiscard discard; ///< Selects which packets can be discarded at will and do not need to be demuxed.

            /**
             * sample aspect ratio (0 if unknown)
             * - encoding: Set by user.
             * - decoding: Set by libavformat.
             */
            [FieldOffset(72)]
            internal AVRational sample_aspect_ratio;

            /// <summary>
            /// AVDictionary
            /// </summary>
            [FieldOffset(80)]
            internal IntPtr metadata;

            /**
             * Average framerate
             *
             * - demuxing: May be set by libavformat when creating the stream or in
             *             avformat_find_stream_info().
             * - muxing: May be set by the caller before avformat_write_header().
             */
            [FieldOffset(88)]
            internal AVRational avg_frame_rate;

            /**
             * For streams with AV_DISPOSITION_ATTACHED_PIC disposition, this packet
             * will contain the attached picture.
             *
             * decoding: set by libavformat, must not be modified by the caller.
             * encoding: unused
             */
            [FieldOffset(96)]
            internal AVPacket.Internal attached_pic;


            /**
             * An array of side data that applies to the whole stream (i.e. the
             * container does not allow it to change between packets).
             *
             * There may be no overlap between the side data in this array and side data
             * in the packets. I.e. a given side data is either exported by the muxer
             * (demuxing) / set by the caller (muxing) in this array, then it never
             * appears in the packets, or the side data is exported / sent through
             * the packets (always in the first packet where the value becomes known or
             * changes), then it does not appear in this array.
             *
             * - demuxing: Set by libavformat when the stream is created.
             * - muxing: May be set by the caller before avformat_write_header().
             *
             * Freed by libavformat in avformat_free_context().
             *
             * @deprecated use AVStream's @ref AVCodecParameters.coded_side_data
             *             "codecpar side data".
             */
            [FieldOffset(200)]
            internal IntPtr side_data;

            /**
             * The number of elements in the AVStream.side_data array.
             *
             * @deprecated use AVStream's @ref AVCodecParameters.nb_coded_side_data
             *             "codecpar side data".
             */
            [FieldOffset(208)]
            internal int nb_side_data;



            /**
             * Flags indicating events happening on the stream, a combination of
             * AVSTREAM_EVENT_FLAG_*.
             *
             * - demuxing: may be set by the demuxer in avformat_open_input(),
             *   avformat_find_stream_info() and av_read_frame(). Flags must be cleared
             *   by the user once the event has been handled.
             * - muxing: may be set by the user after avformat_write_header(). to
             *   indicate a user-triggered event.  The muxer will clear the flags for
             *   events it has handled in av_[interleaved]_write_frame().
             */
            [FieldOffset(212)]
            internal int event_flags;
            /**
             * - demuxing: the demuxer read new metadata from the file and updated
             *     AVStream.metadata accordingly
             * - muxing: the user updated AVStream.metadata and wishes the muxer to write
             *     it into the file
             */
            // AVSTREAM_EVENT_FLAG_METADATA_UPDATED 0x0001
            /**
             * - demuxing: new packets for this stream were read from the file. This
             *   event is informational only and does not guarantee that new packets
             *   for this stream will necessarily be returned from av_read_frame().
             */
            // AVSTREAM_EVENT_FLAG_NEW_PACKETS (1 << 1)

            /**
             * Real base framerate of the stream.
             * This is the lowest framerate with which all timestamps can be
             * represented accurately (it is the least common multiple of all
             * framerates in the stream). Note, this value is just a guess!
             * For example, if the time base is 1/90000 and all frames have either
             * approximately 3600 or 1800 timer ticks, then r_frame_rate will be 50/1.
             */
            [FieldOffset(216)]
            internal AVRational r_frame_rate;

            /**
             * Number of bits in timestamps. Used for wrapping control.
             *
             * - demuxing: set by libavformat
             * - muxing: set by libavformat
             *
             */
            [FieldOffset(224)]
            internal int pts_wrap_bits;
        }
    }
}