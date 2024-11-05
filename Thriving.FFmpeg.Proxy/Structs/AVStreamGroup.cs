using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVStreamGroup : ProxyObject
    {
        internal AVStreamGroup(IntPtr handle) : base(handle) { }

        public static string GetName(AVStreamGroupParamsType type)
        {
            var ptr = Core.avformat_stream_group_name(type);
            return Marshal.PtrToStringAnsi(ptr);
        }


        public bool AddStream(AVStream stream)
        {
            var res = Core.avformat_stream_group_add_stream(_handle, stream._handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return res == 0;
        }


        [StructLayout(LayoutKind.Explicit, Size = 80)]
        internal struct Internal
        {
            /**
            * A class for @ref avoptions. Set by avformat_stream_group_create().
            */
            [FieldOffset(0)] internal IntPtr av_class;

            [FieldOffset(8)] internal IntPtr priv_data;

            /**
             * Group index in AVFormatContext.
             */
            [FieldOffset(16)] internal uint index;

            /**
             * Group type-specific group ID.
             *
             * decoding: set by libavformat
             * encoding: may set by the user
             */
            [FieldOffset(24)] internal long id;

            /**
             * Group type
             *
             * decoding: set by libavformat on group creation
             * encoding: set by avformat_stream_group_create()
             */
            [FieldOffset(32)] internal AVStreamGroupParamsType type;

            /**
             * Group type-specific parameters
             */
            [FieldOffset(40)] internal IntPtr parameters;

            /**
             * Metadata that applies to the whole group.
             *
             * - demuxing: set by libavformat on group creation
             * - muxing: may be set by the caller before avformat_write_header()
             *
             * Freed by libavformat in avformat_free_context().
             */
            [FieldOffset(48)] internal IntPtr metadata;

            /**
             * Number of elements in AVStreamGroup.streams.
             *
             * Set by avformat_stream_group_add_stream() must not be modified by any other code.
             */
            [FieldOffset(56)] internal uint nb_streams;

            /**
             * A list of streams in the group. New entries are created with
             * avformat_stream_group_add_stream().
             *
             * - demuxing: entries are created by libavformat on group creation.
             *             If AVFMTCTX_NOHEADER is set in ctx_flags, then new entries may also
             *             appear in av_read_frame().
             * - muxing: entries are created by the user before avformat_write_header().
             *
             * Freed by libavformat in avformat_free_context().
             */
            [FieldOffset(64)] internal IntPtr streams;

            /**
             * Stream group disposition - a combination of AV_DISPOSITION_* flags.
             * This field currently applies to all defined AVStreamGroupParamsType.
             *
             * - demuxing: set by libavformat when creating the group or in
             *             avformat_find_stream_info().
             * - muxing: may be set by the caller before avformat_write_header().
             */
            [FieldOffset(72)] internal int disposition;
        }
    }
}