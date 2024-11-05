using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVDeviceInfoList : ProxyObject
    {
        internal AVDeviceInfoList(IntPtr handle):base(handle) { }

        public AVDeviceInfoList()
        {
            _handle=IntPtr.Zero;
        }

        public int DefaultDevice
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.default_device)).ToInt32());
        }

        public AVDeviceInfo[] Devices
        {
            get
            {
                var nb_devices = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.nb_devices)).ToInt32());
                var devices = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.devices)).ToInt32());

                var result = new AVDeviceInfo[nb_devices];
                for (int i = 0; i < nb_devices; i++)
                {
                    var ptr = Marshal.ReadIntPtr(devices, i * Marshal.SizeOf<IntPtr>());
                    result[i] = new AVDeviceInfo(ptr);
                }
                return result;
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public readonly struct Internal
        {
            /// <summary>
            /// list of autodetected devices,  
            /// </summary>

            [FieldOffset(0)] internal readonly IntPtr devices;

            /// <summary>
            ///  number of autodetected devices
            /// </summary>
            [FieldOffset(8)] internal readonly int nb_devices;

            /// <summary>
            ///  index of default device or -1 if no default
            /// </summary>
            [FieldOffset(12)] internal readonly int default_device;
        }
    }
}