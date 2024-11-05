using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVProfile : ProxyObject
    {
        internal AVProfile(IntPtr handle) : base(handle) { }

        public static string GetName(AVCodecID codec_id, AVProfileID profile)
        {
            var ptr = Core.avcodec_profile_name(codec_id, profile);
            return Marshal.PtrToStringAnsi(ptr);
        }

        public int Profile
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.profile)).ToInt32());
        }

        public string Name
        {
            get
            {
                var name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.name)).ToInt32());
                return Marshal.PtrToStringAnsi(name);
            }
        }


        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct Internal
        {
            [FieldOffset(0)] internal int profile;
            [FieldOffset(8)] internal IntPtr name;
        }
    }
}