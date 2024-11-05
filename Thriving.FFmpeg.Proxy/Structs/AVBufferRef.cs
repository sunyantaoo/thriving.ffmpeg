using System.Drawing;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVBufferRef:ProxyObject
    {
        internal AVBufferRef(IntPtr handle):base(handle) {}

        public IntPtr Buffer
        {
            get => Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buffer)).ToInt32());
        }

        public byte[] GetData()
        {
            var size = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.size)).ToInt32());
            var data = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.data)).ToInt32());

            var result = new byte[size];
            for (var i = 0; i < size; i++)
            {
                result[i] = Marshal.ReadByte(data, i);
            }
            return result;
        }




        [StructLayout(LayoutKind.Explicit)]
        public readonly struct Internal
        {
            /// <summary>
            /// AVBuffer
            /// </summary>
            [FieldOffset(0)]
            internal readonly IntPtr buffer;

            /**
             * The data buffer. It is considered writable if and only if
             * this is the only reference to the buffer, in which case
             * av_buffer_is_writable() returns 1.
             */
            [FieldOffset(8)]
            internal readonly IntPtr data;
            /**
             * Size of data in bytes.
             */
            [FieldOffset(16)]
            internal readonly long size;
        }
    }
}