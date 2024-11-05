using System.Drawing;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVFrameSideData : ProxyObject
    {
        internal AVFrameSideData(IntPtr handle) : base(handle) { }

        public AVFrameSideDataType Type
        {
            get => (AVFrameSideDataType)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.type)).ToInt32());
        }

        public byte[] Data
        {
            get
            {
                var size = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.size)).ToInt32());
                var data = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.data)).ToInt32());
                var result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public AVBufferRef Buf
        {
            get
            {
                var buf = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buf)).ToInt32());
                return new AVBufferRef(buf);
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public readonly struct Internal
        {
            [FieldOffset(0)]
            internal readonly AVFrameSideDataType type;

            [FieldOffset(8)]
            internal readonly IntPtr data;

            [FieldOffset(16)]
            internal readonly long size;

            /// <summary>
            /// AVDictionary
            /// </summary>
            [FieldOffset(24)]
            internal readonly IntPtr metadata;

            /// <summary>
            /// AVBufferRef
            /// </summary>
            [FieldOffset(32)]
            internal readonly IntPtr buf;
        }
    }
}