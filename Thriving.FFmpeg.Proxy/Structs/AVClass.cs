using System;
using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public class AVClass : ProxyObject
    {
        internal AVClass(IntPtr handle) : base(handle) { }

        public string ClassName
        {
            get
            {
                var class_name = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.class_name)).ToInt32());
                return Marshal.PtrToStringAnsi(class_name);
            }
        }

        public AVOption Option
        {
            get
            {
                var option = Marshal.ReadIntPtr(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.option)).ToInt32());
                return new AVOption(option);
            }
        }

        public int Version
        {
            get => Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.version)).ToInt32()); 
        }

        public AVClassCategory Category
        {
            get
            {
                var category = Marshal.ReadInt32(_handle, Marshal.OffsetOf<Internal>(nameof(Internal.category)).ToInt32());
                return (AVClassCategory)category;
            }
        }

        public delegate string getName(IntPtr ctx);

        public delegate AVClassCategory getCategory(IntPtr ctx);

        public unsafe delegate int queryRanges(IntPtr* AVOPtionsRanges, IntPtr obj, IntPtr key, int flags);

        public unsafe delegate IntPtr childNext(IntPtr obj, IntPtr prev);

        public unsafe delegate IntPtr childClassIterate(IntPtr iter);

        [StructLayout(LayoutKind.Explicit)]
        readonly struct Internal
        {
            /**
             * The name of the class; usually it is the same name as the
             * context structure type to which the AVClass is associated.
             */
            [FieldOffset(0)]
            internal readonly IntPtr class_name;



            /**
             * A pointer to a function which returns the name of a context
             * instance ctx associated with the class.
             */
            [FieldOffset(8)]
            internal readonly getName item_name;

            /**
             * a pointer to the first option specified in the class if any or NULL
             *
             * @see av_set_default_options()
             */
            [FieldOffset(16)]
            internal readonly IntPtr option;


            /**
             * LIBAVUTIL_VERSION with which this structure was created.
             * This is used to allow fields to be added without requiring major
             * version bumps everywhere.
             */
            [FieldOffset(24)]
            internal readonly int version;


            /**
             * Offset in the structure where log_level_offset is stored.
             * 0 means there is no such variable
             */
            [FieldOffset(28)]
            internal readonly int log_level_offset_offset;

            /**
             * Offset in the structure where a pointer to the parent context for
             * logging is stored. For example a decoder could pass its AVCodecContext
             * to eval as such a parent context, which an av_log() implementation
             * could then leverage to display the parent context.
             * The offset can be NULL.
             */
            [FieldOffset(32)]
            internal readonly int parent_log_context_offset;

            /**
             * Category used for visualization (like color)
             * This is only set if the category is equal for all objects using this class.
             * available since version (51 << 16 | 56 << 8 | 100)
             */
            [FieldOffset(36)]
            internal readonly AVClassCategory category;


            /**
             * Callback to return the category.
             * available since version (51 << 16 | 59 << 8 | 100)
             */
            [FieldOffset(40)]
            internal readonly getCategory get_category;

            /**
             * Callback to return the supported/allowed ranges.
             * available since version (52.12)
             */
            [FieldOffset(48)]
            internal readonly queryRanges query_ranges;

            /**
             * Return next AVOptions-enabled child or NULL
             */
            [FieldOffset(56)]
            internal readonly childNext child_next;

            /**
             * Iterate over the AVClasses corresponding to potential AVOptions-enabled
             * children.
             *
             * @param iter pointer to opaque iteration state. The caller must initialize
             *             *iter to NULL before the first call.
             * @return AVClass for the next AVOptions-enabled child or NULL if there are
             *         no more such children.
             *
             * @note The difference between child_next and this is that child_next
             *       iterates over _already existing_ objects, while child_class_iterate
             *       iterates over _all possible_ children.
             */
            [FieldOffset(64)]
            internal readonly childClassIterate child_class_iterate;
        }
    }
}