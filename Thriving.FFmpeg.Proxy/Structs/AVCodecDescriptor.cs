using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVCodecDescriptor : ProxyObject
    {
        public AVCodecDescriptor(IntPtr handle):base(handle) { }

        public static AVCodecDescriptor GetById(AVCodecID codec_id)
        {
            var handle = Core.avcodec_descriptor_get(codec_id);
            return new AVCodecDescriptor(handle);
        }

        public static AVCodecDescriptor GetByName(string name)
        {
            var handle = Core.avcodec_descriptor_get_by_name(name);
            return new AVCodecDescriptor(handle);
        }

        public static bool Next(AVCodecDescriptor? prev, out AVCodecDescriptor descriptor)
        {
            var ptr = Core.avcodec_descriptor_next(prev == null ? IntPtr.Zero : prev._handle);
            descriptor = new AVCodecDescriptor(ptr);
            return ptr != IntPtr.Zero;
        }


        public AVCodecID Id
        {
            get
            {
                var id = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.id)).ToInt32());
                return (AVCodecID)id;
            }
        }

        public AVMediaType Type
        {
            get
            {
                var type = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.type)).ToInt32());
                return (AVMediaType)type;
            }
        }

        public AVCodecProperties Properties
        {
            get
            {
                var type = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.props)).ToInt32());
                return (AVCodecProperties)type;
            }
        }

        public string Name
        {
            get
            {
                var name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.name)).ToInt32());
                return Marshal.PtrToStringAnsi(name);
            }
        }

        public string LongName
        {
            get {
                var long_name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.long_name)).ToInt32());
                return Marshal.PtrToStringAnsi(long_name);
            } 
        }

        public AVProfile[] Profiles
        {
            get
            {
                var result = new List<AVProfile>();
                var profiles = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.profiles)).ToInt32());
                if (profiles != IntPtr.Zero)
                {
                    int i = 0;
                    while (true)
                    {
                        var data = new AVProfile(profiles + i * Marshal.SizeOf<AVProfile.Internal>());
                        if (data.Profile == -99) { break; }// AV_PROFILE_UNKNOWN
                        result.Add(data);
                        i++;
                    }
                }
                return result.ToArray();
            }
        }

        public string[] MimeTypes
        {
            get
            {
                var result = new List<string>();
                var mime_types = Marshal.ReadIntPtr(_handle + Marshal.OffsetOf<Internal>(nameof(Internal.mime_types)).ToInt32());
                if (mime_types != IntPtr.Zero)
                {
                    int i = 0;
                    while (true)
                    {
                        var ptr = Marshal.ReadIntPtr(mime_types + i * Marshal.SizeOf<IntPtr>());
                        if (ptr == IntPtr.Zero) break;
                        result.Add(Marshal.PtrToStringAnsi(ptr));
                        i++;
                    }
                }
                return result.ToArray();
            }
        }


        [StructLayout(LayoutKind.Explicit)]
        readonly struct Internal
        {
            [FieldOffset(0)]
            internal readonly AVCodecID id;
            [FieldOffset(4)]
            internal readonly AVMediaType type;
            /**
             * Name of the codec described by this descriptor. It is non-empty and
             * unique for each codec descriptor. It should contain alphanumeric
             * characters and '_' only.
             */
            [FieldOffset(8)]
            internal readonly IntPtr name;
            /**
             * A more descriptive name for this codec. May be NULL.
             */
            [FieldOffset(16)]
            internal readonly IntPtr long_name;

            /**
             * Codec properties, a combination of AV_CODEC_PROP_* flags.
             */
            [FieldOffset(24)]
            internal readonly AVCodecProperties props;
            /**
             * MIME type(s) associated with the codec.
             * May be NULL; if not, a NULL-terminated array of MIME types.
             * The first item is always non-NULL and is the preferred MIME type.
             */
            [FieldOffset(32)]
            internal readonly IntPtr mime_types;

            /**
             * If non-NULL, an array of profiles recognized for this codec.
             * Terminated with AV_PROFILE_UNKNOWN.
             */
            [FieldOffset(40)]
            internal readonly IntPtr profiles;
        }
    }
}