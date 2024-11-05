namespace Thriving.FFmpeg.Proxy
{
    public class AVImage
    {
        private readonly IntPtr[] _pointers = [IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero];
        private readonly int[] _linesizes = [0, 0, 0, 0];
        private readonly AVPixelFormat _pixelFormat;
        private readonly int _width;
        private readonly int _height;


        public AVImage(int width, int height, AVPixelFormat pix_fmt, int align = 1)
        {
            _pixelFormat = pix_fmt;
            _width = width;
            _height = height;

            Core.av_image_alloc(_pointers, _linesizes, width, height, pix_fmt, align);
        }

        /// <summary>
        /// TODO 复制不成功
        /// </summary>
        /// <param name="src_data"></param>
        /// <param name="src_linesize"></param>
        /// <param name="pix_fmt"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public AVImage(IntPtr[] src_data, int[] src_linesize, AVPixelFormat pix_fmt, int width, int height)
        {
            _pixelFormat = pix_fmt;
            _width = width;
            _height = height;

            Core.av_image_copy(_pointers, _linesizes, src_data, src_linesize, pix_fmt, width, height);
        }

        public AVImage(IntPtr data, AVPixelFormat pix_fmt, int width, int height, int align)
        {
            _pixelFormat = pix_fmt;
            _width = width;
            _height = height;

            Core.av_image_fill_arrays(_pointers, _linesizes, data, pix_fmt, width, height, align);
        }

        ~AVImage()
        {
            foreach (var item in _pointers)
            {
                if (item != IntPtr.Zero) Core.av_freep(item);
            }
        }

        public void FillColor(uint[] clolor)
        {
            long[] linesizes = new long[4];
            Array.Copy(_linesizes, 0, linesizes, 0, 4);
            Core.av_image_fill_color(_pointers, linesizes, _pixelFormat, clolor, _width, _height, 0);
        }

        public void FillBlack(AVColorRange range)
        {
            long[] linesizes = new long[4];
            Array.Copy(_linesizes, 0, linesizes, 0, 4);
            Core.av_image_fill_black(_pointers, linesizes, _pixelFormat, range, _width, _height);
        }

        /// <summary>
        /// Compute the size of an image line for the plane
        /// </summary>
        /// <param name="plane">0,1,2,3,4</param>
        /// <returns>the computed size in bytes</returns>
        public int GetLinesize(int plane)
        {
            return Core.av_image_get_linesize(_pixelFormat, _width, plane);
        }

        /// <summary>
        /// Return the size in bytes of the amount of data required to store an  image with the given parameters
        /// </summary>
        /// <param name="align"> the assumed linesize alignment</param>
        /// <returns></returns>
        public int GetBufferSize(int align)
        {
            return Core.av_image_get_buffer_size(_pixelFormat, _width, _height, align);
        }

        /// <summary>
        /// Copy image data into a buffer
        /// </summary>
        /// <param name="align">the assumed linesize alignment for dst</param>
        public byte[] GetBuffer(int align)
        {
            var size = GetBufferSize(align);
            var result = new byte[size];
            Core.av_image_copy_to_buffer(result, size, _pointers, _linesizes, _pixelFormat, _width, _height, align);
            return result;
        }
    }
}