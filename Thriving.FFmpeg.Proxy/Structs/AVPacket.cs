using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// 未解码前帧数据
    /// </summary>
    public class AVPacket : ProxyObject
    {
        internal AVPacket(IntPtr handle) : base(handle) { }

        public AVPacket()
        {
            _handle = Core.av_packet_alloc();
        }

        ~AVPacket()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.av_packet_free(ref _handle);
            }
        }

        public void Ref(AVPacket src)
        {
            Core.av_packet_ref(_handle, src.Handle);
        }

        public void UnRef()
        {
            Core.av_packet_unref(_handle);
        }

        public void NewSize(int size)
        {
            var res = Core.av_new_packet(_handle, size);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }

        public void ShrinkSize(int size)
        {
            Core.av_shrink_packet(_handle, size);
        }

        public void GrowSize(int grow_by)
        {
            var res = Core.av_grow_packet(_handle, grow_by);
            if (res < 0) throw FFmpegException.FromErrorCode(res);
        }

        public bool CopyProps(AVPacket src)
        {
            var res = Core.av_packet_copy_props(_handle, src.Handle);
            return res == 0;
        }

        public void RescaleTimebase(AVRational src,AVRational dest)
        {
            Core.av_packet_rescale_ts(_handle,src,dest);
        }

        public bool MakeWritable()
        {
            var res = Core.av_packet_make_writable(_handle);
            return res == 0;
        }

        public bool MakeRefcounted()
        {
            var res = Core.av_packet_make_refcounted(_handle);
            return res == 0;
        }

        public bool InitializeFromData(byte[] data)
        {
            var size = data.Length;
            var res = Core.av_packet_from_data(_handle, data, size);
            return (res == 0);
        }


        public int StreamIndex
        {
            get
            {
                return Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.stream_index)).ToInt32());
            }
            set
            {
                Marshal.WriteInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.stream_index)).ToInt32(),value);
            }
        }

        public int Size
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.size)).ToInt32());
        }
        

        public byte[] Data
        {
            get
            {
                var size = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.size)).ToInt32());
                var data = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.data)).ToInt32());

                var result = new byte[size];
                Marshal.Copy(data,result,0,size);
                return result;
            }
        }

        /// <summary>
        /// Decompression timestamp，以AVStream.TimeBase为准
        /// </summary>
        public long DTS
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.dts)).ToInt32());
            set => Marshal.WriteInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.dts)).ToInt32(), value);
        }
        /// <summary>
        /// Presentation timestamp，以AVStream.TimeBase为准
        /// </summary>
        public long PTS
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pts)).ToInt32());
            set => Marshal.WriteInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.pts)).ToInt32(), value);
        }

        public AVBufferRef Buf
        {
            get
            {
                var buf = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buf)).ToInt32());
                return new AVBufferRef(buf);
            }
        }

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
                Marshal.StructureToPtr<AVRational>(value, time_base, false);
            }
        }

        public AVPacketSideData[] SideData
        {
            get
            {
                var side_data_elems = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.side_data_elems)).ToInt32());
                var side_data = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.side_data)).ToInt32());

                var result = new AVPacketSideData[side_data_elems];
                for (int i = 0; i < side_data_elems; i++)
                {
                    result[i] = Marshal.PtrToStructure<AVPacketSideData>(side_data + i * Marshal.SizeOf<AVPacketSideData>());
                }
                return result;
            }
        }

        public long Duration
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.duration)).ToInt32());
            set => Marshal.WriteInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.duration)).ToInt32(), value);
        }

        [StructLayout(LayoutKind.Explicit, Size = 104)]
        internal struct Internal
        {
            /**
             * A reference to the reference-counted buffer where the packet data is
             * stored.
             * May be NULL, then the packet data is not reference-counted.
             */
            [FieldOffset(0)]
            internal IntPtr buf;

            /**
             * Presentation timestamp in AVStream->time_base units; the time at which
             * the decompressed packet will be presented to the user.
             * Can be AV_NOPTS_VALUE if it is not stored in the file.
             * pts MUST be larger or equal to dts as presentation cannot happen before
             * decompression, unless one wants to view hex dumps. Some formats misuse
             * the terms dts and pts/cts to mean something different. Such timestamps
             * must be converted to true pts/dts before they are stored in AVPacket.
             */
            [FieldOffset(8)]
            internal long pts;

            /**
             * Decompression timestamp in AVStream->time_base units; the time at which
             * the packet is decompressed.
             * Can be AV_NOPTS_VALUE if it is not stored in the file.
             */
            [FieldOffset(16)]
            internal long dts;

            [FieldOffset(24)]
            internal IntPtr data;

            [FieldOffset(32)]
            internal int size;

            [FieldOffset(36)]
            internal int stream_index;

            /**
             * A combination of AV_PKT_FLAG values
             */
            [FieldOffset(40)]
            internal int flags;
            /**
             * Additional packet data that can be provided by the container.
             * Packet can contain several types of side information.
             */
            [FieldOffset(48)]
            internal IntPtr side_data;

            [FieldOffset(56)]
            internal int side_data_elems;

            /**
             * Duration of this packet in AVStream->time_base units, 0 if unknown.
             * Equals next_pts - this_pts in presentation order.
             */
            [FieldOffset(64)]
            internal long duration;

            [FieldOffset(72)]
            internal long pos;                            ///< byte position in stream, -1 if unknown

            /**
             * for some internal data of the user
             */
            [FieldOffset(80)]
            internal IntPtr opaque;

            /**
             * AVBufferRef for free use by the API user. FFmpeg will never check the
             * contents of the buffer ref. FFmpeg calls av_buffer_unref() on it when
             * the packet is unreferenced. av_packet_copy_props() calls create a new
             * reference with av_buffer_ref() for the target packet's opaque_ref field.
             *
             * This is unrelated to the opaque field, although it serves a similar
             * purpose.
             */
            [FieldOffset(88)]
            internal IntPtr opaque_ref;

            /**
             * Time base of the packet's timestamps.
             * In the future, this field may be set on packets output by encoders or
             * demuxers, but its value will be by default ignored on input to decoders
             * or muxers.
             */
            [FieldOffset(96)]
            internal AVRational time_base;
        }
    }
}