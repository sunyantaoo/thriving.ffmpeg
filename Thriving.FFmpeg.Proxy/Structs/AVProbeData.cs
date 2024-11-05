using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVProbeData : ProxyObject
    {
        internal AVProbeData(IntPtr handle) : base(handle) { }

        public string Filename
        {
            get
            {
                var filename = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.filename)).ToInt32());
                return Marshal.PtrToStringAnsi(filename);
            }
        }

        public string MimeType
        {
            get
            {
                var mime_type = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.mime_type)).ToInt32());
                return Marshal.PtrToStringAnsi(mime_type);
            }
        }

        public byte[] Buf
        {
            get
            {
                var size = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buf_size)).ToInt32());
                var buf = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.buf)).ToInt32());
                byte[] result = new byte[size];
                Marshal.Copy(buf, result, 0, size);
                return result;
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr filename;
            [FieldOffset(8)] internal IntPtr buf; /**< Buffer must have AVPROBE_PADDING_SIZE of extra allocated bytes filled with zero. */
            [FieldOffset(16)] internal int buf_size;       /**< Size of buf except extra allocated bytes */
            [FieldOffset(24)] internal IntPtr mime_type; /**< mime_type, when known. */
        }
    }
}