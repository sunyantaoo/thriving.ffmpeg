using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVOption : ProxyObject
    {
        internal AVOption(IntPtr handle) : base(handle) { }

        public string Name
        {
            get
            {
                var name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.name)).ToInt32());
                return Marshal.PtrToStringAnsi(name);
            }
        }
        public string Help
        {
            get
            {
                var help = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.help)).ToInt32());
                return Marshal.PtrToStringAnsi(help);
            }
        }

        public string Unit
        {
            get
            {
                var unit = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.unit)).ToInt32());
                return Marshal.PtrToStringAnsi(unit);
            }
        }

        public double Min
        {
            get
            {
                var min = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.min)).ToInt32();
                return Marshal.PtrToStructure<double>(min);
            }
        }

        public double Max
        {
            get
            {
                var max = _handle + Marshal.OffsetOf<Internal>(nameof(Internal.max)).ToInt32();
                return Marshal.PtrToStructure<double>(max);
            }
        }

        public int Offset
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.offset)).ToInt32());
        }

        public AVOptionFlags Flags
        {
            get => (AVOptionFlags)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.flags)).ToInt32());
        }

        public AVOptionType Type
        {
            get => (AVOptionType)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.type)).ToInt32());
        }

        [StructLayout(LayoutKind.Explicit)]
        struct Internal
        {
            [FieldOffset(0)]
            internal IntPtr name;

            /**
             * short English help text
             * @todo What about other languages?
             */
            [FieldOffset(8)]
            internal IntPtr help;

            /**
             * Native access only.
             *
             * The offset relative to the context structure where the option
             * value is stored. It should be 0 for named constants.
             */
            [FieldOffset(16)]
            internal int offset;

            [FieldOffset(20)]
            internal AVOptionType type;

            [FieldOffset(24)]
            internal IntPtr default_val;

            [FieldOffset(32)]
            internal double min;                 ///< minimum valid value for the option

            [FieldOffset(40)]
            internal double max;                 ///< maximum valid value for the option

            /**
             * A combination of AV_OPT_FLAG_*.
             */
            [FieldOffset(48)]
            internal AVOptionFlags flags;
            /**
             * The logical unit to which the option belongs. Non-constant
             * options and corresponding named constants share the same
             * unit. May be NULL.
             */
            [FieldOffset(56)]
            internal IntPtr unit;
        }
    }

}