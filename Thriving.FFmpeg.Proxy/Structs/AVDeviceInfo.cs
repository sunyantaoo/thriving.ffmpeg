using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{

    public class AVDeviceInfo : ProxyObject
    {
        internal AVDeviceInfo(IntPtr handle):base(handle) { }


        public string DeviceName
        {
            get
            {
                var device_name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.device_name)).ToInt32());
                return Marshal.PtrToStringAnsi(device_name);
            }
        }

        public string DeviceDescription
        {
            get
            {
                var device_description = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.device_description)).ToInt32());
                return Marshal.PtrToStringAnsi(device_description);
            }
        }

        public AVMediaType[] MediaTypes
        {
            get
            {
                var nb_media_types = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_media_types)).ToInt32());
                var media_types = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.media_types)).ToInt32());

                var result = new AVMediaType[nb_media_types];
                for (int i = 0; i < nb_media_types; i++)
                {
                    result[i] = (AVMediaType)Marshal.ReadInt32(media_types, i * Marshal.SizeOf<int>());
                }
                return result;
            }
        }


        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public readonly struct Internal
        {
            /// <summary>
            /// device name, format depends on device
            /// </summary>
            [FieldOffset(0)] internal readonly IntPtr device_name;
            /// <summary>
            ///  human friendly name
            /// </summary>
            [FieldOffset(8)] internal readonly IntPtr device_description;
            /// <summary>
            /// array indicating what media types(s), if any, a device can provide. If null, cannot provide any
            /// </summary>
            [FieldOffset(16)] internal readonly IntPtr media_types;
            /// <summary>
            /// length of media_types array, 0 if device cannot provide any media types
            /// </summary>
            [FieldOffset(24)] internal readonly int nb_media_types;

       
        }
    }
}