using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVProgram: ProxyObject
    {
        internal AVProgram(IntPtr handle) : base(handle) { }

        public int Id
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.id)).ToInt32());
        }

        public DateTime StartTime
        {
            get
            {
                var start_time = Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.start_time)).ToInt32());
                return DateTime.FromBinary(start_time);
            }
        }

        public DateTime EndTime
        {
            get
            {
                var end_time = Marshal.ReadInt64(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.end_time)).ToInt32());
                return DateTime.FromBinary(end_time);
            }
        }

        public AVDiscard Discard
        {
            get
            {
                var discard = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.discard)).ToInt32());
                return (AVDiscard)discard;
            }
        }

        public uint[] StreamIndexes
        {
            get
            {
                var nb_stream_indexes = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_stream_indexes)).ToInt32());
                var stream_index = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.stream_index)).ToInt32());

                var result = new uint[nb_stream_indexes];
                for (var i = 0; i < nb_stream_indexes; i++)
                {
                    result[i] = (uint)Marshal.ReadInt32(stream_index, i * Marshal.SizeOf<Int32>());
                }
                return result;
            }
        }

        public int ProgramNum
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.program_num)).ToInt32());
        }



        [StructLayout(LayoutKind.Explicit)]
        public readonly struct Internal
        {
            [FieldOffset(0)]
            internal readonly int id;

            [FieldOffset(4)]
            internal readonly int flags;

            [FieldOffset(8)]
            internal readonly AVDiscard discard;

            [FieldOffset(16)]
            internal readonly IntPtr stream_index;

            [FieldOffset(24)]
            internal readonly uint nb_stream_indexes;

            /// <summary>
            /// AVDictionary
            /// </summary>
            [FieldOffset(32)]
            internal readonly IntPtr metadata;

            [FieldOffset(40)]
            internal readonly int program_num;

            [FieldOffset(44)]
            internal readonly int pmt_pid;

            [FieldOffset(48)]
            internal readonly int pcr_pid;

            [FieldOffset(52)]
            internal readonly int pmt_version;

            [FieldOffset(56)]
            internal readonly long start_time;

            [FieldOffset(64)]
            internal readonly long end_time;

            [FieldOffset(72)]
            internal readonly long pts_wrap_reference;

            [FieldOffset(80)]
            internal readonly int pts_wrap_behavior;
        }
    }
}