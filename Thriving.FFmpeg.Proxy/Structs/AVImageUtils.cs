namespace Thriving.FFmpeg.Proxy
{
    public static class AVImageUtils
    {
        public static byte[] GetBuffer(AVFrame frame, int align = 1)
        {
            var dest_size = Core.av_image_get_buffer_size(frame.PixelFormat, frame.Width, frame.Height, align);
            var result = new byte[dest_size];
            Core.av_image_copy_to_buffer(result, dest_size, frame.Data, frame.Linesize, frame.PixelFormat, frame.Width, frame.Height, align);
            return result;
        }

        /// <summary>
        /// Check if the given dimension of an image is valid,meaning that all bytes of the image can be addressed with a signed int
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="log_offset"></param>
        /// <param name="log_ctx"></param>
        /// <returns></returns>
        public static bool CheckSize(uint width, uint height, int log_offset, IntPtr log_ctx)
        {
            var res = Core.av_image_check_size(width, height, log_offset, log_ctx);
            return res >= 0;
        }

        /// <summary>
        /// Check if the given dimension of an image is valid,meaning that all bytes of the image can be addressed with a signed int
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="max_pixels"></param>
        /// <param name="pix_fmt"></param>
        /// <param name="log_offset"></param>
        /// <param name="log_ctx"></param>
        /// <returns></returns>
        public static bool CheckSize(uint width, uint height, long max_pixels, AVPixelFormat pix_fmt, int log_offset, IntPtr log_ctx)
        {
            var res = Core.av_image_check_size2(width, height, max_pixels, pix_fmt, log_offset, log_ctx);
            return res >= 0;
        }

        /// <summary>
        ///  Check if the given sample aspect ratio of an image is valid 高宽比
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="sar"></param>
        /// <returns></returns>
        public static bool CheckSar(uint width, uint height, AVRational sar)
        {
            var res = Core.av_image_check_sar(width, height, sar);
            return res == 0;
        }

        /// <summary>
        /// Fill plane linesizes for an image with pixel format and width
        /// </summary>
        /// <param name="linesizes"></param>
        /// <param name="pixelFormat"></param>
        /// <param name="width"></param>
        public static void FillLinesizes(int[] linesizes, AVPixelFormat pixelFormat, int width)
        {
            Core.av_image_fill_linesizes(linesizes, pixelFormat, width);
        }

        public static void FillMaxPixsteps(int[] max_pixsteps, int[] max_pixstep_comps, AVPixFmtDescriptor pixdesc)
        {
            Core.av_image_fill_max_pixsteps(max_pixsteps, max_pixstep_comps, pixdesc._handle);
        }

        public static void FillPlaneSizes(long[] size, AVPixelFormat pix_fmt, int height, long[] linesize)
        {
            Core.av_image_fill_plane_sizes(size, pix_fmt, height, linesize);
        }

        public static void FillPointers(IntPtr[] data, AVPixelFormat pix_fmt, int height, IntPtr ptr, int[] linesize)
        {
            Core.av_image_fill_pointers(data, pix_fmt, height, ptr, linesize);
        }

        public static void CopyPlane(IntPtr dst, int dst_linesize, IntPtr src, int src_linesize, int bytewidth, int height)
        {
            Core.av_image_copy_plane(dst, dst_linesize, src, src_linesize, bytewidth, height);
        }

        public static void CopyPlaneUCFrom(IntPtr dest, long dst_linesize, IntPtr src, long src_linesize, long bytewidth, int height)
        {
            Core.av_image_copy_plane_uc_from(dest, dst_linesize, src, src_linesize, bytewidth, height);
        }


        public static void CopyUncacheableFrom(IntPtr[] dst_data, long[] dst_linesize, IntPtr[] src_data, long[] src_linesize, AVPixelFormat pix_fmt, int width, int height)
        {
            Core.av_image_copy_uc_from(dst_data, dst_linesize, src_data, src_linesize, pix_fmt, width, height);
        }
    }
}