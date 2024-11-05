using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIndexEntry:ProxyObject
    {
        private const int AVINDEX_KEYFRAME = 0x01;
        private const int AVINDEX_DISCARD_FRAME = 0x02;

        internal AVIndexEntry(IntPtr handle):base(handle) { }

        public bool KeyFrame
        {
            get
            {
                var res = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.flags)).ToInt32());
                return ((res >> 30) & AVINDEX_KEYFRAME) == AVINDEX_KEYFRAME;
            }
        }

        public bool DiscardFrame
        {
            get
            {
                var res = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.flags)).ToInt32());
                return ((res >> 30) & AVINDEX_DISCARD_FRAME) == AVINDEX_DISCARD_FRAME;
            }
        }

        public int Size
        {
            get
            {
                var res = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.size)).ToInt32());
                return res & 0x3FFFFFFF; // 都为1时才为1
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 24)]
        internal struct Internal
        {
            [FieldOffset(0)] internal long pos;
            /// <summary>
            /// Timestamp in AVStream.time_base units,preferably the time from which on correctly decoded frames are available
            /// </summary>
            [FieldOffset(8)] internal long timestamp;
            /// <summary>
            /// 前2位
            /// Flag is used to indicate which frame should be discarded after decoding
            /// </summary>
            [FieldOffset(16)] internal int flags;
            /// <summary>
            /// 后30位
            /// Yeah, trying to keep the size of this small to reduce memory requirements (it is 24 vs. 32 bytes due to possible 8-byte alignment)
            /// </summary>
            [FieldOffset(16)] internal int size;
            /// <summary>
            /// Minimum distance between this and the previous keyframe, used to avoid unneeded searching
            /// </summary>
            [FieldOffset(20)] internal int min_distance;
        }
    }
}