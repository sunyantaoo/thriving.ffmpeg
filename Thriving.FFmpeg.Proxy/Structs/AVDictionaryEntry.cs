using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public  class AVDictionaryEntry:ProxyObject
    {

        internal AVDictionaryEntry(IntPtr handle):base(handle) { }
        public  string Key
        {
            get
            {
                var key = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.key)).ToInt32());
                return Marshal.PtrToStringAnsi(key);
            }
        }

        public string Value
        {
            get
            {
                var value = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.value)).ToInt32());
                return Marshal.PtrToStringAnsi(value);
            }
        }


        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr key;
            [FieldOffset(8)] internal IntPtr value;
        }
    }
}