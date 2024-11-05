using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct AVOptionArrayDef
    {
        /**
         * Native access only.
         *
         * Default value of the option, as would be serialized by av_opt_get() (i.e.
         * using the value of sep as the separator).
         */
        [FieldOffset(0)]
        internal readonly IntPtr def;

        public string Def
        {
            get => Marshal.PtrToStringAnsi(def);
        }

        /**
         * Minimum number of elements in the array. When this field is non-zero, def
         * must be non-NULL and contain at least this number of elements.
         */
        [FieldOffset(8)]
        internal readonly uint size_min;
        /**
         * Maximum number of elements in the array, 0 when unlimited.
         */
        [FieldOffset(12)]
        internal readonly uint size_max;

        /**
         * Separator between array elements in string representations of this
         * option, used by av_opt_set() and av_opt_get(). It must be a printable
         * ASCII character, excluding alphanumeric and the backslash. A comma is
         * used when sep=0.
         *
         * The separator and the backslash must be backslash-escaped in order to
         * appear in string representations of the option value.
         */
        [FieldOffset(16)]
        internal readonly char sep;
    }
}