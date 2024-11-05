using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public delegate int ReadPacket(IntPtr opaque, IntPtr buf, int buf_size);
    public delegate int WritePacket(IntPtr opaque, IntPtr buf, int buf_size);
    public delegate long SeekPacket(IntPtr opaque, long offset, int whence);
    public delegate int UpdateChecksum(ulong checksum, IntPtr buf, int buf_size);
    public delegate int ReadPause(IntPtr opaque, int pause);
    public delegate long ReadSeek(IntPtr opaque, int stream_index, long timestamp, int whence, int flags);
    public delegate int WriteDataType(IntPtr opaque, IntPtr buf, int buf_size, AVIODataMarkerType type, long time);

    public class AVIOContext : ProxyOptionObject
    {
        internal AVIOContext(IntPtr handle) : base(handle) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer">Memory block for input/output operations via AVIOContext</param>
        /// <param name="buffer_size">The buffer size is very important for performance</param>
        /// <param name="write_flag">Set to 1 if the buffer should be writable, 0 otherwise</param>
        /// <param name="opaque"> An opaque pointer to user-specific data</param>
        /// <param name="readPacket">A function for refilling the buffer, may be NULL</param>
        /// <param name="writePacket">A function for writing the buffer contents, may be NULL</param>
        /// <param name="seekPacket">A function for seeking to specified byte position, may be NULL</param>
        public AVIOContext(IntPtr buffer, int buffer_size, int write_flag, IntPtr opaque, ReadPacket? readPacket = null, WritePacket? writePacket = null, SeekPacket? seekPacket = null)
        {
            _handle = Core.avio_alloc_context(buffer, buffer_size, write_flag, opaque, readPacket, writePacket, seekPacket);
        }

        ~AVIOContext()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.avio_context_free(ref _handle);
            }
        }

        public static AVIOContext Open(string url, AVIOFlags flags)
        {
            var handle = IntPtr.Zero;
            var ret = Core.avio_open(ref handle, url, flags);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
            return new AVIOContext(handle);
        }

        public static AVIOContext Open(string url, AVIOFlags flags, AVIOInterruptCB callback, AVDictionary? dict = null)
        {
            var handle = IntPtr.Zero;
            var dictPtr = dict == null ? IntPtr.Zero : dict._handle;
            var res = Core.avio_open2(ref handle, url, flags, callback != null ? callback._handle : IntPtr.Zero, ref dictPtr);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return new AVIOContext(handle);
        }

        /// <summary>
        /// Accept and allocate a client context on a server context
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public static AVIOContext Accept(AVIOContext server)
        {
            var handle = IntPtr.Zero;
            var res = Core.avio_accept(server._handle, ref handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return new AVIOContext(handle);
        }


        public static IList<string> GetProtocols(bool output)
        {
            var result = new List<string>();
            IntPtr state = IntPtr.Zero;

            IntPtr protocol;
            while ((protocol = Core.avio_enum_protocols(ref state, Convert.ToInt32(output))) != IntPtr.Zero)
            {
                result.Add(Marshal.PtrToStringAnsi(protocol));
            }
            return result;
        }

        public static string FindProtocolName(string url)
        {
            var ptr = Core.avio_find_protocol_name(url);
            return Marshal.PtrToStringAnsi(ptr);
        }

        /// <summary>
        /// 握手
        /// </summary>
        /// <returns></returns>
        public bool HandShake()
        {
            var res = Core.avio_handshake(_handle);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            return res == 0;
        }

        public void Close()
        {
            var ret = Core.avio_close(_handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void OpenDir(string url, AVDictionary? dict=null)
        {
            var dictPtr = dict == null ? IntPtr.Zero : dict._handle;
            var ret = Core.avio_open_dir(ref _handle, url, ref dictPtr);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void CloseDir()
        {
            var ret = Core.avio_close_dir(ref _handle);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void Flush()
        {
            Core.avio_flush(_handle);
        }


        public long Size()
        {
            var ret = Core.avio_size(_handle);
            if (ret < 0) throw FFmpegException.FromErrorCode((int)ret);
            return ret;
        }

        public long Skip(long offset)
        {
            var ret = Core.avio_skip(_handle, offset);
            if (ret < 0) throw FFmpegException.FromErrorCode((int)ret);
            return ret;
        }

        public long Seek(long offset, int whence)
        {
            var res = Core.avio_seek(_handle, offset, whence);
            if (res < 0) throw FFmpegException.FromErrorCode((int)res);
            return res;
        }

        public byte[] Read(int size)
        {
            var ptr = Marshal.AllocHGlobal(size);
            var ret = Core.avio_read(_handle, ptr, size);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
            var bytes = new byte[ret];
            Marshal.Copy(ptr, bytes, 0, ret);
            Marshal.FreeHGlobal(ptr);
            return bytes;
        }

        public byte[] ReadPartial(int size)
        {
            var ptr = Marshal.AllocHGlobal(size);
            var ret = Core.avio_read_partial(_handle, ptr, size);
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
            var bytes = new byte[ret];
            Marshal.Copy(ptr, bytes, 0, ret);
            Marshal.FreeHGlobal(ptr);
            return bytes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pause">pause 1 for pause, 0 for resume</param>
        public void Pause(bool pause)
        {
            var ret = Core.avio_pause(_handle, Convert.ToInt32(pause));
            if (ret < 0) throw FFmpegException.FromErrorCode(ret);
        }

        public void PutString(string str)
        {
            var res = Core.avio_put_str(_handle, str);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }

        public string GetString(int maxlen, int buflen)
        {
            var ptr = Marshal.AllocHGlobal(buflen);
            var res = Core.avio_get_str(_handle, maxlen, ptr, buflen);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
            var result = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);
            return result;
        }

        public void Write(byte[] buf)
        {
            Core.avio_write(_handle, buf, buf.Length);
        }

        public void WriteMarker(long time, AVIODataMarkerType marker)
        {
            var ret = Core.avio_write_marker(_handle, time, marker);
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

        public IntPtr BufferStart
        {
            get => Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buffer)).ToInt32());
        }

        public int BufferSize
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buffer_size)).ToInt32());
        }

        public IntPtr BufferCurrent
        {
            get => Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buf_ptr)).ToInt32());
        }

        public IntPtr BufferEnd
        {
            get => Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buf_end)).ToInt32());
        }

        public long Position
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pos)).ToInt32());
        }

        public int Direct
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.direct)).ToInt32());
        }

        /// <summary>
        /// 已读取字节数
        /// </summary>
        public long Readed
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.bytes_read)).ToInt32());
        }

        /// <summary>
        /// 已写入字节数
        /// </summary>
        public long Writed
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.bytes_written)).ToInt32());
        }




        #endregion

        [StructLayout(LayoutKind.Explicit, Size = 200)]
        internal struct Internal
        {
            /**
             * A class for internal options.
             *
             * If this AVIOContext is created by avio_open2(), av_class is set and
             * passes the options down to protocols.
             *
             * If this AVIOContext is manually allocated, then av_class may be set by
             * the caller.
             *
             * warning -- this field can be NULL, be sure to not pass this AVIOContext
             * to any av_opt_* functions in that case.
             */
            [FieldOffset(0)] internal IntPtr av_class;

            /// <summary>
            /// Start of the buffer
            /// </summary>
            [FieldOffset(8)] internal IntPtr buffer;
            /// <summary>
            /// Maximum buffer size
            /// </summary>
            [FieldOffset(16)] internal int buffer_size;
            /// <summary>
            /// Current position in the buffer
            /// </summary>
            [FieldOffset(24)] internal IntPtr buf_ptr;
            /// <summary>
            /// End of the data, may be less than buffer+buffer_size if the read function returned        less data than requested
            /// e.g. for streams where                                 no more data has been received yet
            /// </summary>
            [FieldOffset(32)] internal IntPtr buf_end;

            /// <summary>
            /// A internal pointer, passed to the read/write/seek/... functions.
            /// </summary>
            [FieldOffset(40)] internal IntPtr opaque;



            [FieldOffset(48)] internal ReadPacket read_packet;
            [FieldOffset(56)] internal WritePacket write_packet;
            [FieldOffset(64)] internal SeekPacket seek;

            /// <summary>
            /// position in the file of the current buffer
            /// </summary>
            [FieldOffset(72)] internal long pos;
            /// <summary>
            /// true if was unable to read due to error or eof
            /// </summary>
            [FieldOffset(80)] internal int eof_reached;
            /// <summary>
            /// contains the error code or 0 if no error happened
            /// </summary>
            [FieldOffset(84)] internal int error;
            /// <summary>
            ///  true if open for writing
            /// </summary>
            [FieldOffset(88)] internal int write_flag;

            [FieldOffset(92)] internal int max_packet_size;

            /// <summary>
            /// Try to buffer at least this amount of data before flushing it
            /// </summary>
            [FieldOffset(96)] internal int min_packet_size;

            [FieldOffset(100)] internal uint checksum;
            [FieldOffset(104)] internal IntPtr checksum_ptr;



            [FieldOffset(112)] internal UpdateChecksum update_checksum;
            /**
             * Pause or resume playback for network streaming protocols - e.g. MMS.
             */
            [FieldOffset(120)] internal ReadPause read_pause;
            /**
             * Seek to a given timestamp in stream with the specified stream_index.
             * Needed for some network streaming protocols which don't support seeking
             * to byte position.
             */

            [FieldOffset(128)] internal ReadSeek read_seek;
            /**
             * A combination of AVIO_SEEKABLE_ flags or 0 when the stream is not seekable.
             */
            [FieldOffset(136)] internal int seekable;

            /**
             * avio_read and avio_write should if possible be satisfied directly
             * instead of going through a buffer, and avio_seek will always
             * call the underlying seek function directly.
             */
            [FieldOffset(140)] internal int direct;

            /**
             * ',' separated list of allowed protocols.
             */
            [FieldOffset(144)] internal IntPtr protocol_whitelist;



            /**
             * ',' separated list of disallowed protocols.
             */
            [FieldOffset(152)] internal IntPtr protocol_blacklist;


            /**
             * A callback that is used instead of write_packet.
             */


            [FieldOffset(160)] internal WriteDataType write_data_type;
            /**
             * If set, don't call write_data_type separately for AVIO_DATA_MARKER_BOUNDARY_POINT,
             * but ignore them and treat them as AVIO_DATA_MARKER_UNKNOWN (to avoid needlessly
             * small chunks of data returned from the callback).
             */
            [FieldOffset(168)] internal int ignore_boundary_point;

            /**
             * Maximum reached position before a backward seek in the write buffer,
             * used keeping track of already written data for a later flush.
             */
            [FieldOffset(176)] internal IntPtr buf_ptr_max;

            /**
             * Read-only statistic of bytes read for this AVIOContext.
             */
            [FieldOffset(184)] internal long bytes_read;

            /**
             * Read-only statistic of bytes written for this AVIOContext.
             */
            [FieldOffset(192)] internal long bytes_written;
        }
    }
}