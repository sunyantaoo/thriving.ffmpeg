using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct AVHWAccel
    {
        /**
         * Name of the hardware accelerated codec.
         * The name is globally unique among encoders and among decoders (but an
         * encoder and a decoder can share the same name).
         */
        [FieldOffset(0)]
      internal readonly   IntPtr name;

        public string Name
        {
            get => Marshal.PtrToStringAnsi(name);
        }

        /**
         * Type of codec implemented by the hardware accelerator.
         *
         * See AVMEDIA_TYPE_xxx
         */
        [FieldOffset(8)]
        internal readonly AVMediaType type;

        public AVMediaType Type
        {
            get=>type;
        }

        /**
         * Codec implemented by the hardware accelerator.
         *
         * See AV_CODEC_ID_xxx
         */
        [FieldOffset(12)]
        internal readonly AVCodecID id;

        /**
         * Supported pixel format.
         *
         * Only hardware accelerated formats are supported here.
         */
        [FieldOffset(16)]
        internal readonly AVPixelFormat pix_fmt;

        /**
         * Hardware accelerated codec capabilities.
         * see AV_HWACCEL_CODEC_CAP_*
         */
        [FieldOffset(20)]
        internal readonly int capabilities;
    }
}