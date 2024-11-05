using System.Runtime.InteropServices;

namespace Thriving.FFmpeg.Proxy
{
    public partial class Core
    {
        private const string _libswscale = "swscale-8.dll";

        /// <summary>
        /// 
        /// </summary>
        /// <returns>SwsVector*</returns>
        [DllImport(_libswscale)] public static extern IntPtr sws_allocVec(int length);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="variance"></param>
        /// <param name="quality"></param>
        /// <returns>SwsVector*</returns>
        [DllImport(_libswscale)] public static extern IntPtr sws_getGaussianVec(double variance, double quality);

        [DllImport(_libswscale)] public static extern void sws_freeVec(IntPtr SwsVector);

        [DllImport(_libswscale)] public static extern void sws_normalizeVec(IntPtr SwsVector, double height);


        /// <summary>
        /// 
        /// </summary>
        /// <returns>SwsFilter*</returns>
        [DllImport(_libswscale)]
        public static extern IntPtr sws_getDefaultFilter(float lumaGBlur, float chromaGBlur, float lumaSharpen, float chromaSharpen, float chromaHShift, float chromaVShift, int verbose);
        [DllImport(_libswscale)] public static extern void sws_freeFilter(IntPtr SwsFilter);


        [DllImport(_libswscale)] public static extern void sws_alloc_set_opts();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">byte*</param>
        /// <param name="dst">byte*</param>
        /// <param name="num_pixels"></param>
        /// <param name="palette">byte*</param>
        [DllImport(_libswscale)] public static extern void sws_convertPalette8ToPacked24(IntPtr src, IntPtr dst, int num_pixels, IntPtr palette);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="src">byte*</param>
        /// <param name="dst">byte*</param>
        /// <param name="num_pixels"></param>
        /// <param name="palette">byte*</param>
        [DllImport(_libswscale)] public static extern void sws_convertPalette8ToPacked32(IntPtr src, IntPtr dst, int num_pixels, IntPtr palette);

        [DllImport(_libswscale)] public static extern void sws_frame_end(IntPtr SwsContext);
        [DllImport(_libswscale)] public static extern int sws_frame_start(IntPtr SwsContext, IntPtr dstFrame, IntPtr srcFrame);

        [DllImport(_libswscale)] public static extern IntPtr sws_alloc_context();
        [DllImport(_libswscale)] public static extern void sws_freeContext(IntPtr SwsContext);

        [DllImport(_libswscale)]
        public static extern IntPtr sws_getCachedContext(IntPtr SwsContext,
                                        int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, int flags, IntPtr srcFilter, IntPtr dstFilter, IntPtr param);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colorspace"></param>
        /// <returns>int*</returns>
        [DllImport(_libswscale)] public static extern IntPtr sws_getCoefficients(int colorspace);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SwsContext"></param>
        /// <param name="inv_table">int**</param>
        /// <param name="srcRange"> int*</param>
        /// <param name="table">int**</param>
        /// <param name="dstRange">int*</param>
        /// <param name="brightness"> int*</param>
        /// <param name="contrast">int*</param>
        /// <param name="saturation"> int*</param>
        /// <returns></returns>
        [DllImport(_libswscale)] public static extern int sws_getColorspaceDetails(IntPtr SwsContext, IntPtr inv_table, IntPtr srcRange, IntPtr table, IntPtr dstRange, IntPtr brightness, IntPtr contrast, IntPtr saturation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SwsContext"></param>
        /// <param name="inv_table">4</param>
        /// <param name="srcRange"></param>
        /// <param name="table">4</param>
        /// <param name="dstRange"></param>
        /// <param name="brightness"></param>
        /// <param name="contrast"></param>
        /// <param name="saturation"></param>
        /// <returns></returns>
        [DllImport(_libswscale)] public static extern int sws_setColorspaceDetails(IntPtr SwsContext, int[] inv_table, int srcRange, int[] table, int dstRange, int brightness, int contrast, int saturation);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcW"></param>
        /// <param name="srcH"></param>
        /// <param name="srcFormat"></param>
        /// <param name="dstW"></param>
        /// <param name="dstH"></param>
        /// <param name="dstFormat"></param>
        /// <param name="flags"></param>
        /// <param name="srcFilter">SwsFilter *</param>
        /// <param name="dstFilter">SwsFilter *</param>
        /// <param name="param">double*</param>
        /// <returns></returns>
        [DllImport(_libswscale)] public static extern IntPtr sws_getContext(int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, int flags, IntPtr srcFilter, IntPtr dstFilter, double[] param);


        [DllImport(_libswscale)] public static extern int sws_init_context(IntPtr SwsContext, IntPtr srcFilter, IntPtr destFilter);
        [DllImport(_libswscale)] public static extern int sws_isSupportedEndiannessConversion(AVPixelFormat pixelFormat);
        [DllImport(_libswscale)] public static extern int sws_isSupportedInput(AVPixelFormat pixelFormat);
        [DllImport(_libswscale)] public static extern int sws_isSupportedOutput(AVPixelFormat pixelFormat);

        [DllImport(_libswscale)] public static extern int sws_scale(IntPtr SwsContext, IntPtr[] srcSlice, int[] srcStride, int srcSliceY, int srcSliceH, IntPtr[] dst, int[] dstStride);
        [DllImport(_libswscale)] public static extern void sws_scaleVec(IntPtr SwsVec, double scalar);
        [DllImport(_libswscale)] public static extern int sws_scale_frame(IntPtr SwsContext, IntPtr dstFrame, IntPtr srcFrame);

        [DllImport(_libswscale)] public static extern int sws_send_slice(IntPtr SwsContext, uint slice_start, uint slice_height);
        [DllImport(_libswscale)] public static extern int sws_receive_slice(IntPtr SwsContext, uint slice_start, uint slice_height);
        [DllImport(_libswscale)] public static extern uint sws_receive_slice_alignment(IntPtr SwsContext);


        [DllImport(_libswscale)] public static extern IntPtr sws_get_class();
        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libswscale)] public static extern string swscale_configuration();
        [return: MarshalAs(UnmanagedType.LPStr)]
        [DllImport(_libswscale)] public static extern string swscale_license();
        [DllImport(_libswscale)] public static extern uint swscale_version();
    }
}