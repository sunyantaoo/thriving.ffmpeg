using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Thriving.FFmpeg.Proxy
{
    public class AVIODirEntry : ProxyObject
    {
        internal AVIODirEntry(IntPtr handle) : base(handle) { }

        public string Name
        {
            get
            {
                var name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.name)).ToInt32());
                return Marshal.PtrToStringAnsi(name);
            }
        }

        public AVIODirEntryType Type
        {
            get => (AVIODirEntryType)Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.type)).ToInt32());
        }

        public int Size
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.size)).ToInt32());
        }



        [StructLayout(LayoutKind.Explicit, Size = 72)]
        internal struct Internal
        {
            [FieldOffset(0)] internal IntPtr name;

            [FieldOffset(8)] internal AVIODirEntryType type;
            /// <summary>
            /// Set to 1 when name is encoded with UTF-8, 0 otherwise.
            ///   Name can be encoded with UTF-8 even though 0 is set.
            /// </summary>
            [FieldOffset(12)] internal int utf8;
            /// <summary>
            /// File size in bytes, -1 if unknown. 
            /// </summary>
            [FieldOffset(16)] internal long size;
            /// <summary>
            /// Time of last modification in microseconds since unix epoch, -1 if unknown
            /// </summary>
            [FieldOffset(24)] internal long modification_timestamp;
            /// <summary>
            /// Time of last access in microseconds since unix epoch, -1 if unknown
            /// </summary>
            [FieldOffset(32)] internal long access_timestamp;
            /// <summary>
            /// Time of last status change in microseconds since unix   epoch, -1 if unknown
            /// </summary>
            [FieldOffset(40)] internal long status_change_timestamp;
            /// <summary>
            /// User ID of owner, -1 if unknown
            /// </summary>
            [FieldOffset(48)] internal long user_id;
            /// <summary>
            /// Group ID of owner, -1 if unknown
            /// </summary>
            [FieldOffset(56)] internal long group_id;
            /// <summary>
            /// Unix file mode, -1 if unknown
            /// </summary>
            [FieldOffset(64)] internal long filemode;
        }
    }
}