using System.Drawing;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVPacketSideData : ProxyObject
    {
        internal AVPacketSideData(IntPtr handle) : base(handle) { }

        public byte[] Data
        {
            get
            {
                var size = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.size)).ToInt32());
                var data = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.data)).ToInt32());
                byte[] result = new byte[size];
                Marshal.Copy(data, result, 0, size);
                return result;
            }
        }

        public AVPacketSideDataType Type
        {
            get => (AVPacketSideDataType)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.type)).ToInt32());
        }

        [StructLayout(LayoutKind.Explicit, Size = 24)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr data;

            [FieldOffset(8)] internal long size;

            [FieldOffset(16)] internal AVPacketSideDataType type;
        }
    }
}