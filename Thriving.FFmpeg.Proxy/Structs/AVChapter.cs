using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVChapter : ProxyObject
    {
        internal AVChapter(IntPtr handle) : base(handle) { }

        public long Id
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.id)).ToInt32());
        }

        public AVRational TimeBase
        {
            get
            {
                var time_base = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.time_base)).ToInt32();
                return Marshal.PtrToStructure<AVRational>(time_base);
            }
        }

        public long Start
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.start)).ToInt32());
        }

        public long End
        {
            get => Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.end)).ToInt32());
        }

        public AVDictionary Metadata
        {
            get
            {
                var metadata = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.metadata)).ToInt32());
                return new AVDictionary(metadata);
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public readonly struct Internal
        {
            [FieldOffset(0)]
            internal readonly long id;

            [FieldOffset(8)]
            internal readonly AVRational time_base;

            [FieldOffset(16)]
            internal readonly long start;

            [FieldOffset(24)]
            internal readonly long end;

            /// <summary>
            ///   AVDictionary
            /// </summary>
            [FieldOffset(32)]
            internal readonly IntPtr metadata;
        }
    }
}