using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Thriving.FFmpeg.Proxy
{

    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public readonly struct AVChannelCustom
    {
        public AVChannelCustom(IntPtr handle)
        {
            this.id = (AVChannel)Marshal.ReadInt32(handle, Marshal.OffsetOf<AVChannelCustom>(nameof(id)).ToInt32());
            this.name = Marshal.ReadIntPtr(handle, Marshal.OffsetOf<AVChannelCustom>(nameof(name)).ToInt32());
            this.opaque = Marshal.ReadIntPtr(handle, Marshal.OffsetOf<AVChannelCustom>(nameof(opaque)).ToInt32());
        }

        [FieldOffset(0)]
        internal readonly AVChannel id;

        [FieldOffset(4)]
        internal readonly IntPtr name;

        [FieldOffset(24)]
        internal readonly IntPtr opaque;

        public AVChannel Channel
        {
            get => id;
        }

        public string Name
        {
            get => Marshal.PtrToStringAnsi(name);
        }

    }
}