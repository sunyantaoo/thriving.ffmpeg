using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class RcOverride : ProxyObject
    {
        internal RcOverride(IntPtr handle) : base(handle) { }

        public int StartFrame
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.start_frame)).ToInt32());
        }

        public int EndFrame
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.end_frame)).ToInt32());
        }

        public int QScale
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.qscale)).ToInt32());
        }

        public float QualityFactor
        {
            get
            {
                var quality_factor = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.quality_factor)).ToInt32();
                return Marshal.PtrToStructure<float>(quality_factor);
            }
        }

        [StructLayout(LayoutKind.Explicit,Size =16)]
        public readonly struct Internal
        {
            [FieldOffset(0)]
            internal readonly int start_frame;
            [FieldOffset(4)]
            internal readonly int end_frame;
            [FieldOffset(8)]
            internal readonly int qscale; // If this is 0 then quality_factor will be used instead.
            [FieldOffset(12)]
            internal readonly float quality_factor;
        }
    }
}