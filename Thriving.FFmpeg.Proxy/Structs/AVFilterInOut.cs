using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    /// <summary>
    /// A linked-list of the inputs/outputs of the filter chain
    /// </summary>
    public class AVFilterInOut : ProxyObject
    {
        public AVFilterInOut()
        {
            _handle = Core.avfilter_inout_alloc();
        }

        ~AVFilterInOut()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.avfilter_inout_free(ref _handle);
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        struct Internal
        {
            /** unique name for this input/output in the list */
            [FieldOffset(0)] internal IntPtr name;  // char*

            /** filter context associated to this input/output */
            [FieldOffset(8)] internal IntPtr filter_ctx; //  AVFilterContext*

            /** index of the filt_ctx pad to use for linking */
            [FieldOffset(16)] int pad_idx;

            /** next input/input in the list, NULL if this is the last */
            [FieldOffset(32)] IntPtr next; // AVFilterInOut *
        }
    }

}