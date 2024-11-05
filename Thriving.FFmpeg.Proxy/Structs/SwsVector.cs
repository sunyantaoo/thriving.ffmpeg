using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class SwsVector : ProxyObject
    {
        internal SwsVector(IntPtr handle) : base(handle) { }

        public int Length
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.length)).ToInt32());
        }

        public double[] Coefficients
        {
            get
            {
                var length = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.length)).ToInt32());
                var coeff = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.coeff)).ToInt32());
                var result = new double[length];
                Marshal.Copy(coeff, result, 0, length);
                return result;
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct Internal
        {
            /// <summary>
            /// pointer to the list of coefficients
            /// </summary>
            [FieldOffset(0)] internal IntPtr coeff;
            /// <summary>
            /// number of coefficients in the vector
            /// </summary>
            [FieldOffset(8)] internal int length;
        }
    }
}