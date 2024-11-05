using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public unsafe class SwsContext : ProxyObject
    {
        public SwsContext()
        {
            _handle = Core.sws_alloc_context();
        }

        public SwsContext(int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, int flags, SwsFilter srcFilter, SwsFilter dstFilter, double[] param)
        {
            _handle = Core.sws_getContext(srcW, srcH, srcFormat, dstW, dstH, dstFormat, flags, srcFilter.Handle, dstFilter.Handle, param);
        }

        ~SwsContext()
        {
            if (_handle != IntPtr.Zero)
            {
                Core.sws_freeContext(_handle);
            }
        }

        public bool IsSupportedInput(AVPixelFormat pix_fmt)
        {
            var ret = Core.sws_isSupportedInput(pix_fmt);
            return ret > 0;
        }

        public bool IsSupportedOutput(AVPixelFormat pix_fmt)
        {
            var ret = Core.sws_isSupportedOutput(pix_fmt);
            return ret > 0;
        }

        public bool IsSupportedEndiannessConversion(AVPixelFormat pix_fmt)
        {
            var ret = Core.sws_isSupportedEndiannessConversion(pix_fmt);
            return ret > 0;
        }

        public int InitContext(IntPtr srcFilter, IntPtr dstFilter)
        {
            return Core.sws_init_context(_handle, srcFilter, dstFilter);
        }

        public int Scale(IntPtr[] srcSlice, int[] srcStride, int srcSliceY, int srcSliceH, IntPtr[] dst, int[] dstStride)
        {
            return Core.sws_scale(_handle, srcSlice, srcStride, srcSliceY, srcSliceH, dst, dstStride);
        }

        public int ScaleFrame(AVFrame dest, AVFrame src)
        {
            return Core.sws_scale_frame(_handle, dest.Handle, src.Handle);
        }

        public void FrameEnd()
        {
             Core.sws_frame_end(_handle);
        }

        public int FrameStart(AVFrame dest, AVFrame src)
        {
            return Core.sws_frame_start(_handle, dest.Handle, src.Handle);
        }

        public int SendSlice(uint slice_start, uint slice_height)
        {
            return Core.sws_send_slice(_handle, slice_start, slice_height);
        }


        public static AVClass Class
        {
            get
            {
                var av_class = Core.sws_get_class();
                return new AVClass(av_class);
            }
        }

        public static uint Version
        {
            get => Core.swscale_version();
        }

        public static string Configuration
        {
            get => Core.swscale_configuration();
        }

        public static string License
        {
            get => Core.swscale_license();
        }

    }
}