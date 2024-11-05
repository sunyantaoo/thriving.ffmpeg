using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVCodecParserContext : ProxyObject
    {
        private const int AV_PARSER_PTS_NB = 4;


        internal AVCodecParserContext(IntPtr handle):base(handle) { }

        public AVCodecParserContext(AVCodecID codec_id)
        {
            _handle = Core.av_parser_init(codec_id);
        }


        public void Close()
        {
            Core.av_parser_close(_handle);
        }


        [StructLayout(LayoutKind.Explicit, Size = 336)]
        struct Internal
        {
            [FieldOffset(0)] IntPtr priv_data;
            [FieldOffset(8)] IntPtr parser;
            [FieldOffset(16)] long frame_offset; /* offset of the current frame */
            [FieldOffset(24)] long cur_offset; /* current offset                           (incremented by each av_parser_parse()) */
            [FieldOffset(32)] long next_frame_offset; /* offset of the next frame */
            /* video info */
            [FieldOffset(40)] int pict_type; /* XXX: Put it back in AVCodecContext. */
            /**
             * This field is used for proper frame duration computation in lavf.
             * It signals, how much longer the frame duration of the current frame
             * is compared to normal frame duration.
             *
             * frame_duration = (1 + repeat_pict) * time_base
             *
             * It is used by codecs like H.264 to display telecined material.
             */
            [FieldOffset(44)] int repeat_pict; /* XXX: Put it back in AVCodecContext. */
           
            [FieldOffset(48)] long pts;     /* pts of the current frame */
          
            [FieldOffset(56)] long dts;     /* dts of the current frame */

            /* private data */
            [FieldOffset(64)] long last_pts;

            [FieldOffset(72)] long last_dts;

            [FieldOffset(80)] int fetch_timestamp;


            [FieldOffset(84)] int cur_frame_start_index;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = AV_PARSER_PTS_NB)]
            [FieldOffset(88)] long[] cur_frame_offset;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = AV_PARSER_PTS_NB)]
            [FieldOffset(120)] long[] cur_frame_pts;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = AV_PARSER_PTS_NB)]
            [FieldOffset(152)] long[] cur_frame_dts;

            [FieldOffset(184)] int flags;
            /// <summary>
            /// byte offset from starting packet start
            /// </summary>
            [FieldOffset(192)] long offset;  
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = AV_PARSER_PTS_NB)]
            [FieldOffset(200)] long[] cur_frame_end;

            /**
             * Set by parser to 1 for key frames and 0 for non-key frames.
             * It is initialized to -1, so if the parser doesn't set this flag,
             * old-style fallback using AV_PICTURE_TYPE_I picture type as key frames
             * will be used.
             */
            [FieldOffset(232)] int key_frame;

            // Timestamp generation support:
            /**
             * Synchronization point for start of timestamp generation.
             *
             * Set to >0 for sync point, 0 for no sync point and <0 for undefined
             * (default).
             *
             * For example, this corresponds to presence of H.264 buffering period
             * SEI message.
             */
            [FieldOffset(236)] int dts_sync_point;

            /**
             * Offset of the current timestamp against last timestamp sync point in
             * units of AVCodecContext.time_base.
             *
             * Set to INT_MIN when dts_sync_point unused. Otherwise, it must
             * contain a valid timestamp offset.
             *
             * Note that the timestamp of sync point has usually a nonzero
             * dts_ref_dts_delta, which refers to the previous sync point. Offset of
             * the next frame after timestamp sync point will be usually 1.
             *
             * For example, this corresponds to H.264 cpb_removal_delay.
             */
            [FieldOffset(240)] int dts_ref_dts_delta;

            /**
             * Presentation delay of current frame in units of AVCodecContext.time_base.
             *
             * Set to INT_MIN when dts_sync_point unused. Otherwise, it must
             * contain valid non-negative timestamp delta (presentation time of a frame
             * must not lie in the past).
             *
             * This delay represents the difference between decoding and presentation
             * time of the frame.
             *
             * For example, this corresponds to H.264 dpb_output_delay.
             */
            [FieldOffset(244)] int pts_dts_delta;

            /**
             * Position of the packet in file.
             *
             * Analogous to cur_frame_pts/dts
             */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = AV_PARSER_PTS_NB)]
            [FieldOffset(248)] long cur_frame_pos;

            /**
             * Byte position of currently parsed frame in stream.
             */
            [FieldOffset(280)] long pos;

            /**
             * Previous frame byte position.
             */
            [FieldOffset(288)] long last_pos;

            /**
             * Duration of the current frame.
             * For audio, this is in units of 1 / AVCodecContext.sample_rate.
             * For all other types, this is in units of AVCodecContext.time_base.
             */
            [FieldOffset(296)] int duration;

            [FieldOffset(300)] AVFieldOrder field_order;

            /**
             * Indicate whether a picture is coded as a frame, top field or bottom field.
             *
             * For example, H.264 field_pic_flag equal to 0 corresponds to
             * AV_PICTURE_STRUCTURE_FRAME. An H.264 picture with field_pic_flag
             * equal to 1 and bottom_field_flag equal to 0 corresponds to
             * AV_PICTURE_STRUCTURE_TOP_FIELD.
             */
            [FieldOffset(304)] AVPictureStructure picture_structure;

            /**
             * Picture number incremented in presentation or output order.
             * This field may be reinitialized at the first picture of a new sequence.
             *
             * For example, this corresponds to H.264 PicOrderCnt.
             */
            [FieldOffset(308)] int output_picture_number;

            /**
             * Dimensions of the decoded video intended for presentation.
             */
            [FieldOffset(312)] int width;
            [FieldOffset(316)] int height;

            /**
             * Dimensions of the coded video.
             */
            [FieldOffset(320)] int coded_width;
            [FieldOffset(324)] int coded_height;

            /**
             * The format of the coded data, corresponds to enum AVPixelFormat for video
             * and for enum AVSampleFormat for audio.
             *
             * Note that a decoder can have considerable freedom in how exactly it
             * decodes the data, so the format reported here might be different from the
             * one returned by a decoder.
             */
            [FieldOffset(328)] int format;
        }

    }
}